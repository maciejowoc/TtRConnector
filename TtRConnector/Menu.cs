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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;           

        }

        private void Btn_Menu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Menu_Generate_Click(object sender, EventArgs e)
        {
            Connector connector = new();
            connector.Show();
            connector.FormClosed += new(Menu_FormClosed);
            this.Hide();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Btn_Menu_Play_Click(object sender, EventArgs e)
        {
            Game game = new();
            game.Show();
            game.FormClosed += new(Menu_FormClosed);
            this.Hide();
        }
    }
}