using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace TtRConnector
{
    public partial class Game : Form
    {
        readonly string fileName = "USA.csv";
        bool activeGame = false;
        protected Graph map;
        readonly bool hasFileOpened = false;
        
        int carts = 0;
        int score = 0;
        int start = -1;
        int meta = -1;
        Opponent opponent = null;

        public Game()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            while (!hasFileOpened)
            {
                try
                {
                    Task.Run(() => OpenFile());
                    map = OpenFile().Result;
                    hasFileOpened = true;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Nie można odnaleźć pliku " + fileName, "Brak pliku!");
                    Application.Exit();
                    Environment.Exit(1);
                }
                catch (AggregateException)
                {
                    MessageBox.Show("Zamknij najpierw plik " + fileName, "Błąd dostępu do danych");
                    hasFileOpened=false;
                }
            }
            PbxInit();
            SetButtons(false);
        }

        async Task<Graph> OpenFile()
        {
            System.IO.StreamReader file = new(fileName);
            Graph map = new(file);
            file.Close();
            return map;
        }

        /* Board initialization */
        void PbxInit()
        {
            Pbx_Board.SendToBack();
            Pbx_Board.Image = Image.FromFile(
                          Path.Combine(
                             Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                             "Resources/Board.png"));
            Pbx_Board.Size = new Size(1214, 754);
            Pbx_Board.Location = new Point(0, 0);
        }

        private void Btn_ReturnToMenu_Click(object sender, EventArgs e)
        {
            if (activeGame == true)
            {
                DialogResult dialogResult = MessageBox.Show("Opuścić grę?", "Opuść grę", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) return;
                activeGame = false;
            }
            Menu menu = new();
            this.Dispose();
            menu.Show();
        }

        private void SetButtons(bool status)
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (btn.Name == "Btn_NewGame" || btn.Name == "Btn_ReturnToMenu" || btn.Name == "Btn_DrawTicket") continue;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.White;
                btn.FlatAppearance.BorderSize = 1;
                btn.Enabled = status;
            }
        }

        /* Method disabling proper button */
        protected void DisableButton(int x, int y)
        {
            string btnName = "Btn_" + x + y;
            if (Controls.Find(btnName,true).FirstOrDefault() == null) btnName = "Btn_" + y + x;
            Controls[btnName].Enabled = false;
            Controls[btnName].BackColor = Color.FromArgb(255, 175, 175);
        }

        protected void EndGame()
        {
            MessageBox.Show("Twój wynik: " + Lbl_Score.Text, "Koniec gry!");
            activeGame = false;
            SetButtons(false);
            Btn_DrawTicket.Enabled = false;
        }


        /* Method that claims connection */

        void ClaimConnection(int x, int y, int owner, object sender)
        {
            int cost = map.Vertices[x].distances[map.Vertices[x].connections.IndexOf(y)];
            if (carts >= cost)
            {
                map.Vertices[x].owner[map.Vertices[x].connections.IndexOf(y)] = owner;
                map.Vertices[y].owner[map.Vertices[y].connections.IndexOf(x)] = owner;
                carts -= cost;
                Lbl_RemainingCarts.Text = Convert.ToString(carts);
                (sender as Button).Enabled = false;
                (sender as Button).BackColor = Color.FromArgb(175, 255, 175);
                switch (cost){
                    case 1:
                        score++;
                        break;
                    case 2:
                        score += 2;
                        break;
                    case 3:
                        score += 4;
                        break;
                    case 4:
                        score += 7;
                        break;
                    case 5:
                        score += 10;
                        break;
                    case 6:
                        score += 15;
                        break;

                }
                Lbl_Score.Text = Convert.ToString(score);
                CheckRealisation(start,meta,owner);
                if (carts < 4)
                {
                    EndGame();
                }
                if (activeGame)
                {
                    var moveResults = opponent.MakeMove();
                    Lbl_EnemyCarts.Text = Convert.ToString(moveResults.Item2);
                    Lbl_EnemyScore.Text = Convert.ToString(moveResults.Item1);
                    Lbl_OpponentHeader.Text = Convert.ToString(map.Vertices[opponent.start].name);
                    Lbl_EnemyScoreHeader.Text = Convert.ToString(map.Vertices[opponent.end].name);
                    DisableButton(moveResults.Item3, moveResults.Item4);
                    if(moveResults.Item5 == true) EndGame();
                }
            }
            else MessageBox.Show("Nie masz wystarczającej liczby wagonów!","Nie stać Cię!");         
        }

        /* Loop to insert events to game buttons */
        bool methodsInserted = false;
        void InsertMethods()
        {
            if (!methodsInserted)
            {
                foreach (Button btn in this.Controls.OfType<Button>())
                {
                    btn.TabStop = false;
                    methodsInserted = true;
                    if (btn.Name == "Btn_NewGame" || btn.Name == "Btn_ReturnToMenu" || btn.Name == "Btn_DrawTicket") continue;
                    string data = btn.Name[(btn.Name.IndexOf("_") + 1)..];
                    int x = Convert.ToInt32(data[..(data.Length / 2)]);
                    int y = Convert.ToInt32(data[(data.Length / 2)..]);
                    btn.Click += (sender, e) => ClaimConnection(x, y, 1, sender);
                }               
            }
        }

        void SetTable()
        {
            Dgv_TicketList.CancelEdit();
            Dgv_TicketList.Columns.Clear();
            Dgv_TicketList.DataSource = null;
            Dgv_TicketList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            Dgv_TicketList.ColumnCount = 2;
            Dgv_TicketList.Columns[0].HeaderText = "Połączenie";
            Dgv_TicketList.Columns[1].HeaderText = "Punkty:";
            Dgv_TicketList.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            Dgv_TicketList.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            Dgv_TicketList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        void DrawTicket(int owner)
        {
            Random rnd = new();
            bool condition = false;               //Warunek sprawdzający czy wylosowane miasto jako meta nie koliduje z warunkami wyszukiwania
            start = rnd.Next(map.Vertices.Count);
            List<string> checkpoints;
            while (condition != true)
            {
                meta = rnd.Next(map.Vertices.Count);
                if (!map.Vertices[start].CheckConnection(meta) && start != meta)
                {
                    //Wypisanie nazw miasta wylosowanego połączenia
                    Dgv_TicketList.Rows.Add();
                    int rowsCount = Dgv_TicketList.RowCount - 1;
                    Dgv_TicketList.Rows[rowsCount].Cells[0].Value = (map.Vertices[start].name + " - " + map.Vertices[meta].name);
                    //Wywołanie metody wyszukiwania drogi i jej wypisanie
                    map.Droga(start, meta, 0);
                    Dgv_TicketList.Rows[rowsCount].Cells[1].Value = (map.len.ToString());
                    condition = true;
                }
            }
            CheckRealisation(start, meta, owner);
        }

        void CheckRealisation(int start, int meta, int owner)
        {
            map.Droga(meta, start, owner);
            if (map.IsConnected(start, meta, owner) && owner == 1)
            {
                Dgv_TicketList.Rows[Dgv_TicketList.RowCount - 1].DefaultCellStyle.BackColor = Color.FromArgb(120, 200, 100);
                score += Convert.ToInt32(Dgv_TicketList.Rows[Dgv_TicketList.RowCount - 1].Cells[1].Value);
                Lbl_Score.Text = Convert.ToString(score);
                DrawTicket(1);
            }
            else if(map.IsConnected(start, meta, owner))
            {
                opponent.DrawTicket(owner);
            }
        }

        /* Start game */
        private void Btn_NewGame_Click(object sender, EventArgs e)
        {
            if (activeGame == true)
            {
                var dialogResult = MessageBox.Show("Czy na pewno chcesz rozpocząć nową grę?", "Nowa gra", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) EndGame();
                else return;
            }
            carts = 45;
            score = 0;
            if(!activeGame) InsertMethods();
            activeGame = true;
            SetButtons(true);
            //_______________________________DO SPRAWDZENIA___________________-
            if(opponent == null)
            {
                opponent = new Opponent(2, ref map);
                Lbl_EnemyCarts.Text = Convert.ToString(opponent.opponentCarts);
                Lbl_EnemyScore.Text = Convert.ToString(opponent.opponentScore);
            }
            else
            {
                opponent.opponentScore = 0;
                opponent.opponentCarts = 45;
                opponent.DrawTicket();
                Lbl_EnemyCarts.Text = Convert.ToString(opponent.opponentCarts);
                Lbl_EnemyScore.Text = Convert.ToString(opponent.opponentScore);
            }
            Dgv_TicketList.Visible = true;
            TLP_LabelGroup.Visible = true;
            Lbl_RemainingCarts.Text = Convert.ToString(carts);
            Lbl_Score.Text = Convert.ToString(score);
            SetTable();
            DrawTicket(1);
            Btn_DrawTicket.Enabled = true;
        }

        private void Btn_DrawTicket_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Wylosować nową trasę?\n\nSpowoduje to odjęcie punktów za wymieniane zlecenie.", "Zmienić trasę?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;
            int rowsCount = Dgv_TicketList.RowCount - 1;
            score -= Convert.ToInt32(Dgv_TicketList.Rows[rowsCount].Cells[1].Value);
            Dgv_TicketList.Rows[Dgv_TicketList.RowCount - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 175, 175);
            Lbl_Score.Text = score.ToString();
            DrawTicket(1);
        }
    }

    
}
