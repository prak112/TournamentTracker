namespace TrackerUI
{
    partial class TournamentDashboardForm
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.loadTournamentLabel = new System.Windows.Forms.Label();
            this.loadTournamentDropDown = new System.Windows.Forms.ComboBox();
            this.LoadTournamentButton = new System.Windows.Forms.Button();
            this.createTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.headerLabel.Location = new System.Drawing.Point(161, 38);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(386, 47);
            this.headerLabel.TabIndex = 4;
            this.headerLabel.Text = "Tournament Dashboard";
            // 
            // loadTournamentLabel
            // 
            this.loadTournamentLabel.AutoSize = true;
            this.loadTournamentLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadTournamentLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.loadTournamentLabel.Location = new System.Drawing.Point(29, 121);
            this.loadTournamentLabel.Name = "loadTournamentLabel";
            this.loadTournamentLabel.Size = new System.Drawing.Size(289, 32);
            this.loadTournamentLabel.TabIndex = 5;
            this.loadTournamentLabel.Text = "Load Existing Tournament";
            // 
            // loadTournamentDropDown
            // 
            this.loadTournamentDropDown.FormattingEnabled = true;
            this.loadTournamentDropDown.Location = new System.Drawing.Point(35, 156);
            this.loadTournamentDropDown.Name = "loadTournamentDropDown";
            this.loadTournamentDropDown.Size = new System.Drawing.Size(283, 33);
            this.loadTournamentDropDown.TabIndex = 6;
            // 
            // LoadTournamentButton
            // 
            this.LoadTournamentButton.BackColor = System.Drawing.Color.Beige;
            this.LoadTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.LoadTournamentButton.FlatAppearance.BorderSize = 2;
            this.LoadTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cornsilk;
            this.LoadTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.LoadTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadTournamentButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadTournamentButton.ForeColor = System.Drawing.Color.Olive;
            this.LoadTournamentButton.Location = new System.Drawing.Point(373, 136);
            this.LoadTournamentButton.Margin = new System.Windows.Forms.Padding(5);
            this.LoadTournamentButton.Name = "LoadTournamentButton";
            this.LoadTournamentButton.Padding = new System.Windows.Forms.Padding(2);
            this.LoadTournamentButton.Size = new System.Drawing.Size(227, 53);
            this.LoadTournamentButton.TabIndex = 25;
            this.LoadTournamentButton.Text = "Load Tournament";
            this.LoadTournamentButton.UseVisualStyleBackColor = false;
            // 
            // createTournamentButton
            // 
            this.createTournamentButton.BackColor = System.Drawing.Color.Beige;
            this.createTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.createTournamentButton.FlatAppearance.BorderSize = 2;
            this.createTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cornsilk;
            this.createTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.createTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTournamentButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTournamentButton.ForeColor = System.Drawing.Color.Olive;
            this.createTournamentButton.Location = new System.Drawing.Point(169, 247);
            this.createTournamentButton.Margin = new System.Windows.Forms.Padding(5);
            this.createTournamentButton.Name = "createTournamentButton";
            this.createTournamentButton.Padding = new System.Windows.Forms.Padding(2);
            this.createTournamentButton.Size = new System.Drawing.Size(329, 73);
            this.createTournamentButton.TabIndex = 26;
            this.createTournamentButton.Text = "Create Tournament";
            this.createTournamentButton.UseVisualStyleBackColor = false;
            // 
            // TournamentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(655, 371);
            this.Controls.Add(this.createTournamentButton);
            this.Controls.Add(this.LoadTournamentButton);
            this.Controls.Add(this.loadTournamentDropDown);
            this.Controls.Add(this.loadTournamentLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "TournamentDashboardForm";
            this.Text = "Tournament Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label loadTournamentLabel;
        private System.Windows.Forms.ComboBox loadTournamentDropDown;
        private System.Windows.Forms.Button LoadTournamentButton;
        private System.Windows.Forms.Button createTournamentButton;
    }
}