namespace TtRConnector
{
    partial class Connector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CityList = new System.Windows.Forms.ComboBox();
            this.Btn_ReturnToMenu = new System.Windows.Forms.Button();
            this.ResultsTable = new System.Windows.Forms.DataGridView();
            this.Btn_CheckNeighbours = new System.Windows.Forms.Button();
            this.Btn_DrawTicket = new System.Windows.Forms.Button();
            this.chkbx_DrawFromList = new System.Windows.Forms.CheckBox();
            this.Btn_ShowShortestPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // CityList
            // 
            this.CityList.FormattingEnabled = true;
            this.CityList.Location = new System.Drawing.Point(48, 38);
            this.CityList.Name = "CityList";
            this.CityList.Size = new System.Drawing.Size(151, 28);
            this.CityList.TabIndex = 0;
            this.CityList.Text = "-Wybierz miasto-";
            this.CityList.SelectedIndexChanged += new System.EventHandler(this.CityList_SelectedIndexChanged);
            // 
            // Btn_ReturnToMenu
            // 
            this.Btn_ReturnToMenu.Location = new System.Drawing.Point(607, 363);
            this.Btn_ReturnToMenu.Name = "Btn_ReturnToMenu";
            this.Btn_ReturnToMenu.Size = new System.Drawing.Size(150, 54);
            this.Btn_ReturnToMenu.TabIndex = 1;
            this.Btn_ReturnToMenu.Text = "Powrót do menu";
            this.Btn_ReturnToMenu.UseVisualStyleBackColor = true;
            this.Btn_ReturnToMenu.Click += new System.EventHandler(this.Btn_ReturnToMenu_Click);
            // 
            // ResultsTable
            // 
            this.ResultsTable.AllowUserToAddRows = false;
            this.ResultsTable.AllowUserToDeleteRows = false;
            this.ResultsTable.AllowUserToResizeColumns = false;
            this.ResultsTable.AllowUserToResizeRows = false;
            this.ResultsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ResultsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsTable.Location = new System.Drawing.Point(306, 38);
            this.ResultsTable.MultiSelect = false;
            this.ResultsTable.Name = "ResultsTable";
            this.ResultsTable.ReadOnly = true;
            this.ResultsTable.RowHeadersVisible = false;
            this.ResultsTable.RowHeadersWidth = 51;
            this.ResultsTable.RowTemplate.Height = 29;
            this.ResultsTable.Size = new System.Drawing.Size(451, 261);
            this.ResultsTable.TabIndex = 3;
            // 
            // Btn_CheckNeighbours
            // 
            this.Btn_CheckNeighbours.Location = new System.Drawing.Point(48, 151);
            this.Btn_CheckNeighbours.Name = "Btn_CheckNeighbours";
            this.Btn_CheckNeighbours.Size = new System.Drawing.Size(156, 42);
            this.Btn_CheckNeighbours.TabIndex = 4;
            this.Btn_CheckNeighbours.Text = "Sprawdź sąsiadów";
            this.Btn_CheckNeighbours.UseVisualStyleBackColor = true;
            this.Btn_CheckNeighbours.Click += new System.EventHandler(this.Btn_CheckNeighbours_Click);
            // 
            // Btn_DrawTicket
            // 
            this.Btn_DrawTicket.Location = new System.Drawing.Point(48, 247);
            this.Btn_DrawTicket.Name = "Btn_DrawTicket";
            this.Btn_DrawTicket.Size = new System.Drawing.Size(156, 41);
            this.Btn_DrawTicket.TabIndex = 5;
            this.Btn_DrawTicket.Text = "Losuj połączenie";
            this.Btn_DrawTicket.UseVisualStyleBackColor = true;
            this.Btn_DrawTicket.Click += new System.EventHandler(this.Btn_DrawTicket_Click);
            // 
            // chkbx_DrawFromList
            // 
            this.chkbx_DrawFromList.AutoSize = true;
            this.chkbx_DrawFromList.Location = new System.Drawing.Point(48, 294);
            this.chkbx_DrawFromList.Name = "chkbx_DrawFromList";
            this.chkbx_DrawFromList.Size = new System.Drawing.Size(168, 24);
            this.chkbx_DrawFromList.TabIndex = 6;
            this.chkbx_DrawFromList.Text = "Wybierz stację z listy";
            this.chkbx_DrawFromList.UseVisualStyleBackColor = true;
            // 
            // Btn_ShowShortestPath
            // 
            this.Btn_ShowShortestPath.Enabled = false;
            this.Btn_ShowShortestPath.Location = new System.Drawing.Point(48, 351);
            this.Btn_ShowShortestPath.Name = "Btn_ShowShortestPath";
            this.Btn_ShowShortestPath.Size = new System.Drawing.Size(151, 35);
            this.Btn_ShowShortestPath.TabIndex = 7;
            this.Btn_ShowShortestPath.Text = "Pokaż trasę";
            this.Btn_ShowShortestPath.UseVisualStyleBackColor = true;
            this.Btn_ShowShortestPath.Click += new System.EventHandler(this.Btn_ShowShortestPath_Click);
            // 
            // Connector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_ShowShortestPath);
            this.Controls.Add(this.chkbx_DrawFromList);
            this.Controls.Add(this.Btn_DrawTicket);
            this.Controls.Add(this.Btn_CheckNeighbours);
            this.Controls.Add(this.ResultsTable);
            this.Controls.Add(this.Btn_ReturnToMenu);
            this.Controls.Add(this.CityList);
            this.Name = "Connector";
            this.Text = "Connector";
            ((System.ComponentModel.ISupportInitialize)(this.ResultsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox CityList;
        private Button Btn_ReturnToMenu;
        private DataGridView ResultsTable;
        private Button Btn_CheckNeighbours;
        private Button Btn_DrawTicket;
        private CheckBox chkbx_DrawFromList;
        private Button Btn_ShowShortestPath;
    }
}