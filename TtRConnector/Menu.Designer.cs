namespace TtRConnector
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Menu_Generate = new System.Windows.Forms.Button();
            this.Btn_Menu_Play = new System.Windows.Forms.Button();
            this.Btn_Menu_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Menu_Generate
            // 
            this.Btn_Menu_Generate.Font = new System.Drawing.Font("Sitka Banner", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_Menu_Generate.Location = new System.Drawing.Point(150, 95);
            this.Btn_Menu_Generate.Name = "Btn_Menu_Generate";
            this.Btn_Menu_Generate.Size = new System.Drawing.Size(300, 50);
            this.Btn_Menu_Generate.TabIndex = 0;
            this.Btn_Menu_Generate.Text = "Losuj połączenia";
            this.Btn_Menu_Generate.UseVisualStyleBackColor = true;
            this.Btn_Menu_Generate.Click += new System.EventHandler(this.Btn_Menu_Generate_Click);
            // 
            // Btn_Menu_Play
            // 
            this.Btn_Menu_Play.Font = new System.Drawing.Font("Sitka Banner", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_Menu_Play.Location = new System.Drawing.Point(150, 169);
            this.Btn_Menu_Play.Name = "Btn_Menu_Play";
            this.Btn_Menu_Play.Size = new System.Drawing.Size(300, 50);
            this.Btn_Menu_Play.TabIndex = 1;
            this.Btn_Menu_Play.Text = "Graj z SI";
            this.Btn_Menu_Play.UseVisualStyleBackColor = true;
            this.Btn_Menu_Play.Click += new System.EventHandler(this.Btn_Menu_Play_Click);
            // 
            // Btn_Menu_Exit
            // 
            this.Btn_Menu_Exit.Font = new System.Drawing.Font("Sitka Banner", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Btn_Menu_Exit.Location = new System.Drawing.Point(150, 302);
            this.Btn_Menu_Exit.Name = "Btn_Menu_Exit";
            this.Btn_Menu_Exit.Size = new System.Drawing.Size(300, 50);
            this.Btn_Menu_Exit.TabIndex = 2;
            this.Btn_Menu_Exit.Text = "Wyjście";
            this.Btn_Menu_Exit.UseVisualStyleBackColor = true;
            this.Btn_Menu_Exit.Click += new System.EventHandler(this.Btn_Menu_Exit_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.Btn_Menu_Exit);
            this.Controls.Add(this.Btn_Menu_Play);
            this.Controls.Add(this.Btn_Menu_Generate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.Text = "Generator Połączeń";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private Button Btn_Menu_Generate;
        private Button Btn_Menu_Play;
        private Button Btn_Menu_Exit;
    }
}