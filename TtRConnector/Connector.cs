using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TtRConnector
{
    public partial class Connector : Form
    {
        readonly string fileName = "USA.csv";
        readonly Graph graph;
        bool cityNameChanged = false;
        List<string> resultsList = new();
        readonly bool hasFileOpened = false;

        public Connector()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            while (!hasFileOpened)
            {
                try
                {
                    Task.Run(() => OpenFile());
                    graph = OpenFile().Result;
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
                    hasFileOpened = false;
                }
            }
            LoadList(graph);
            SetTable();
        }
        async Task<Graph> OpenFile()
        {
            System.IO.StreamReader file = new(fileName);
            Graph graph = new(file);
            file.Close();
            return graph;
        }

        void LoadList(Graph graph)
        {
            List<string> nazwy = new();
            foreach (Vertex city in graph.Vertices)
            {
                nazwy.Add(city.name);
            }
            nazwy.Sort();
            foreach (string item in nazwy)
            {
                CityList.Items.Add(item);
            }
        }

        void SetTable()
        {
            ResultsTable.CancelEdit();
            ResultsTable.Columns.Clear();
            ResultsTable.DataSource = null;
            ResultsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            ResultsTable.ColumnCount = 2;
            ResultsTable.Columns[0].HeaderText = "Połączenie";
            ResultsTable.Columns[1].HeaderText = "Punkty:";
            ResultsTable.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            ResultsTable.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            ResultsTable.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Btn_ReturnToMenu_Click(object sender, EventArgs e)
        {
            Menu menu = new();
            this.Dispose();
            menu.Show();
        }

        private void Btn_CheckNeighbours_Click(object sender, EventArgs e)
        {
            if (cityNameChanged == false)
            {
                MessageBox.Show("Wybierz miasto!", "Błąd");
                return;
            }
            else
            {
                SetTable();                  //Wyczyszczenie tabeli

                int tableIndex = 0;
                int targetId;                 //Pomocnicza zmienna pobierająca id miasta celu
                int id = graph.Load(CityList.Text);
                Vertex city = graph.Vertices[id];
                foreach (int j in city.connections)
                {
                    ResultsTable.Rows.Add();
                    ResultsTable.Rows[tableIndex].Cells[0].Value = (graph.Vertices[id].name + " - " + graph.Vertices[j].name);
                    targetId = graph.Vertices[id].connections.IndexOf(graph.Vertices[j].id);
                    ResultsTable.Rows[tableIndex].Cells[1].Value = (graph.Vertices[id].distances[targetId]);
                    tableIndex++;
                }
            }
        }

        private void CityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cityNameChanged = true;
        }

        private void Btn_DrawTicket_Click(object sender, EventArgs e)
        {
            Random rnd = new();
            bool condition = false;               //Warunek sprawdzający czy wylosowane miasto jako meta nie koliduje z warunkami wyszukiwania
            int start;
            int finish;
            List<string> etapy;
            if (chkbx_DrawFromList.Checked == true)           //Jeśli zaznaczono startową stację to pobiera jej id z listy
            {
                if (cityNameChanged == false)
                {
                    MessageBox.Show("Wybierz miasto!", "Błąd");
                    return;
                }
                else start = graph.Load(CityList.Text);
            }
            else start = rnd.Next(graph.Vertices.Count);
 
            SetTable();
            while (condition != true)
            {
                finish = rnd.Next(graph.Vertices.Count);
                if (!graph.Vertices[start].CheckConnection(finish) && start != finish)
                {
                    //Wypisanie nazw miasta wylosowanego połączenia
                    ResultsTable.Rows.Add();
                    ResultsTable.Rows[0].Cells[0].Value = (graph.Vertices[start].name + " - " + graph.Vertices[finish].name);
                    //Wywołanie metody wyszukiwania drogi i jej wypisanie
                    etapy = graph.Droga(start, finish, 0);
                    resultsList = etapy;
                    ResultsTable.Rows[0].Cells[1].Value = (graph.len.ToString());
                    condition = true;
                }
            }
            Btn_ShowShortestPath.Enabled = true;
        }

        private void Btn_ShowShortestPath_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < resultsList.Count; i++)
            {
                ResultsTable.Rows.Add();
                ResultsTable.Rows[i + 1].Cells[0].Value = (resultsList[i]);
            }
            resultsList.Clear();
        }
    }
}
