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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.CityList.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CityList.FormattingEnabled = true;
            this.CityList.Location = new System.Drawing.Point(43, 38);
            this.CityList.Name = "CityList";
            this.CityList.Size = new System.Drawing.Size(205, 39);
            this.CityList.TabIndex = 0;
            this.CityList.Text = "-Wybierz miasto-";
            this.CityList.SelectedIndexChanged += new System.EventHandler(this.CityList_SelectedIndexChanged);
            // 
            // Btn_ReturnToMenu
            // 
            this.Btn_ReturnToMenu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_ReturnToMenu.Location = new System.Drawing.Point(547, 363);
            this.Btn_ReturnToMenu.Name = "Btn_ReturnToMenu";
            this.Btn_ReturnToMenu.Size = new System.Drawing.Size(210, 54);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ResultsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ResultsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ResultsTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.ResultsTable.EnableHeadersVisualStyles = false;
            this.ResultsTable.Location = new System.Drawing.Point(306, 38);
            this.ResultsTable.MultiSelect = false;
            this.ResultsTable.Name = "ResultsTable";
            this.ResultsTable.ReadOnly = true;
            this.ResultsTable.RowHeadersVisible = false;
            this.ResultsTable.RowHeadersWidth = 51;
            this.ResultsTable.RowTemplate.Height = 38;
            this.ResultsTable.Size = new System.Drawing.Size(451, 261);
            this.ResultsTable.TabIndex = 3;
            // 
            // Btn_CheckNeighbours
            // 
            this.Btn_CheckNeighbours.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_CheckNeighbours.Location = new System.Drawing.Point(43, 390);
            this.Btn_CheckNeighbours.Name = "Btn_CheckNeighbours";
            this.Btn_CheckNeighbours.Size = new System.Drawing.Size(205, 48);
            this.Btn_CheckNeighbours.TabIndex = 4;
            this.Btn_CheckNeighbours.Text = "Sprawdź sąsiadów";
            this.Btn_CheckNeighbours.UseVisualStyleBackColor = true;
            this.Btn_CheckNeighbours.Click += new System.EventHandler(this.Btn_CheckNeighbours_Click);
            // 
            // Btn_DrawTicket
            // 
            this.Btn_DrawTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Btn_DrawTicket.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_DrawTicket.Location = new System.Drawing.Point(43, 127);
            this.Btn_DrawTicket.Name = "Btn_DrawTicket";
            this.Btn_DrawTicket.Size = new System.Drawing.Size(205, 50);
            this.Btn_DrawTicket.TabIndex = 5;
            this.Btn_DrawTicket.Text = "Losuj połączenie";
            this.Btn_DrawTicket.UseVisualStyleBackColor = false;
            this.Btn_DrawTicket.Click += new System.EventHandler(this.Btn_DrawTicket_Click);
            // 
            // chkbx_DrawFromList
            // 
            this.chkbx_DrawFromList.AutoSize = true;
            this.chkbx_DrawFromList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkbx_DrawFromList.Location = new System.Drawing.Point(43, 183);
            this.chkbx_DrawFromList.Name = "chkbx_DrawFromList";
            this.chkbx_DrawFromList.Size = new System.Drawing.Size(214, 32);
            this.chkbx_DrawFromList.TabIndex = 6;
            this.chkbx_DrawFromList.Text = "Wybierz stację z listy";
            this.chkbx_DrawFromList.UseVisualStyleBackColor = true;
            // 
            // Btn_ShowShortestPath
            // 
            this.Btn_ShowShortestPath.Enabled = false;
            this.Btn_ShowShortestPath.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_ShowShortestPath.Location = new System.Drawing.Point(43, 324);
            this.Btn_ShowShortestPath.Name = "Btn_ShowShortestPath";
            this.Btn_ShowShortestPath.Size = new System.Drawing.Size(205, 50);
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