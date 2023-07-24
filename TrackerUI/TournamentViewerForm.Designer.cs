namespace TrackerUI
{
    partial class TournamentViewerForm
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
            this.tournamentName = new System.Windows.Forms.Label();
            this.roundLabel = new System.Windows.Forms.Label();
            this.roundDropDown = new System.Windows.Forms.ComboBox();
            this.unplayedOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.matchListBox = new System.Windows.Forms.ListBox();
            this.team1NameLabel = new System.Windows.Forms.Label();
            this.team1ScoreLabel = new System.Windows.Forms.Label();
            this.team1ScoreText = new System.Windows.Forms.TextBox();
            this.team2ScoreText = new System.Windows.Forms.TextBox();
            this.team2ScoreLabel = new System.Windows.Forms.Label();
            this.team2NameLabel = new System.Windows.Forms.Label();
            this.versusLabel = new System.Windows.Forms.Label();
            this.submitScoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.headerLabel.Location = new System.Drawing.Point(166, 42);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(233, 47);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Tournament : ";
            this.headerLabel.Click += new System.EventHandler(this.headerLabel_Click);
            // 
            // tournamentName
            // 
            this.tournamentName.AutoSize = true;
            this.tournamentName.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournamentName.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.tournamentName.Location = new System.Drawing.Point(380, 42);
            this.tournamentName.Name = "tournamentName";
            this.tournamentName.Size = new System.Drawing.Size(147, 47);
            this.tournamentName.TabIndex = 1;
            this.tournamentName.Text = "<none>";
            // 
            // roundLabel
            // 
            this.roundLabel.AutoSize = true;
            this.roundLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.roundLabel.Location = new System.Drawing.Point(40, 138);
            this.roundLabel.Name = "roundLabel";
            this.roundLabel.Size = new System.Drawing.Size(83, 32);
            this.roundLabel.TabIndex = 2;
            this.roundLabel.Text = "Round";
            // 
            // roundDropDown
            // 
            this.roundDropDown.FormattingEnabled = true;
            this.roundDropDown.Location = new System.Drawing.Point(129, 137);
            this.roundDropDown.Name = "roundDropDown";
            this.roundDropDown.Size = new System.Drawing.Size(144, 33);
            this.roundDropDown.TabIndex = 3;
            this.roundDropDown.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // unplayedOnlyCheckBox
            // 
            this.unplayedOnlyCheckBox.AutoSize = true;
            this.unplayedOnlyCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unplayedOnlyCheckBox.ForeColor = System.Drawing.Color.Coral;
            this.unplayedOnlyCheckBox.Location = new System.Drawing.Point(129, 176);
            this.unplayedOnlyCheckBox.Name = "unplayedOnlyCheckBox";
            this.unplayedOnlyCheckBox.Size = new System.Drawing.Size(152, 29);
            this.unplayedOnlyCheckBox.TabIndex = 4;
            this.unplayedOnlyCheckBox.Text = "Unplayed Only";
            this.unplayedOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchListBox
            // 
            this.matchListBox.ForeColor = System.Drawing.Color.Maroon;
            this.matchListBox.FormattingEnabled = true;
            this.matchListBox.ItemHeight = 25;
            this.matchListBox.Location = new System.Drawing.Point(46, 211);
            this.matchListBox.Name = "matchListBox";
            this.matchListBox.Size = new System.Drawing.Size(353, 279);
            this.matchListBox.TabIndex = 5;
            // 
            // team1NameLabel
            // 
            this.team1NameLabel.AutoSize = true;
            this.team1NameLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team1NameLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.team1NameLabel.Location = new System.Drawing.Point(445, 138);
            this.team1NameLabel.Name = "team1NameLabel";
            this.team1NameLabel.Size = new System.Drawing.Size(123, 32);
            this.team1NameLabel.TabIndex = 6;
            this.team1NameLabel.Text = "<Team 1>";
            // 
            // team1ScoreLabel
            // 
            this.team1ScoreLabel.AutoSize = true;
            this.team1ScoreLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team1ScoreLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.team1ScoreLabel.Location = new System.Drawing.Point(445, 183);
            this.team1ScoreLabel.Name = "team1ScoreLabel";
            this.team1ScoreLabel.Size = new System.Drawing.Size(73, 32);
            this.team1ScoreLabel.TabIndex = 7;
            this.team1ScoreLabel.Text = "Score";
            // 
            // team1ScoreText
            // 
            this.team1ScoreText.Location = new System.Drawing.Point(524, 182);
            this.team1ScoreText.Name = "team1ScoreText";
            this.team1ScoreText.Size = new System.Drawing.Size(113, 33);
            this.team1ScoreText.TabIndex = 8;
            // 
            // team2ScoreText
            // 
            this.team2ScoreText.BackColor = System.Drawing.SystemColors.Window;
            this.team2ScoreText.Location = new System.Drawing.Point(524, 357);
            this.team2ScoreText.Name = "team2ScoreText";
            this.team2ScoreText.Size = new System.Drawing.Size(113, 33);
            this.team2ScoreText.TabIndex = 11;
            // 
            // team2ScoreLabel
            // 
            this.team2ScoreLabel.AutoSize = true;
            this.team2ScoreLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team2ScoreLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.team2ScoreLabel.Location = new System.Drawing.Point(445, 358);
            this.team2ScoreLabel.Name = "team2ScoreLabel";
            this.team2ScoreLabel.Size = new System.Drawing.Size(73, 32);
            this.team2ScoreLabel.TabIndex = 10;
            this.team2ScoreLabel.Text = "Score";
            // 
            // team2NameLabel
            // 
            this.team2NameLabel.AutoSize = true;
            this.team2NameLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team2NameLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.team2NameLabel.Location = new System.Drawing.Point(445, 313);
            this.team2NameLabel.Name = "team2NameLabel";
            this.team2NameLabel.Size = new System.Drawing.Size(123, 32);
            this.team2NameLabel.TabIndex = 9;
            this.team2NameLabel.Text = "<Team 2>";
            // 
            // versusLabel
            // 
            this.versusLabel.AutoSize = true;
            this.versusLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versusLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.versusLabel.Location = new System.Drawing.Point(506, 253);
            this.versusLabel.Name = "versusLabel";
            this.versusLabel.Size = new System.Drawing.Size(62, 32);
            this.versusLabel.TabIndex = 12;
            this.versusLabel.Text = "-VS-";
            // 
            // submitScoreButton
            // 
            this.submitScoreButton.BackColor = System.Drawing.Color.Beige;
            this.submitScoreButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.submitScoreButton.FlatAppearance.BorderSize = 2;
            this.submitScoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cornsilk;
            this.submitScoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.submitScoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitScoreButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitScoreButton.ForeColor = System.Drawing.Color.Olive;
            this.submitScoreButton.Location = new System.Drawing.Point(497, 421);
            this.submitScoreButton.Margin = new System.Windows.Forms.Padding(5);
            this.submitScoreButton.Name = "submitScoreButton";
            this.submitScoreButton.Padding = new System.Windows.Forms.Padding(2);
            this.submitScoreButton.Size = new System.Drawing.Size(122, 69);
            this.submitScoreButton.TabIndex = 13;
            this.submitScoreButton.Text = "SUBMIT Score";
            this.submitScoreButton.UseVisualStyleBackColor = false;
            // 
            // TournamentViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(685, 530);
            this.Controls.Add(this.submitScoreButton);
            this.Controls.Add(this.versusLabel);
            this.Controls.Add(this.team2ScoreText);
            this.Controls.Add(this.team2ScoreLabel);
            this.Controls.Add(this.team2NameLabel);
            this.Controls.Add(this.team1ScoreText);
            this.Controls.Add(this.team1ScoreLabel);
            this.Controls.Add(this.team1NameLabel);
            this.Controls.Add(this.matchListBox);
            this.Controls.Add(this.unplayedOnlyCheckBox);
            this.Controls.Add(this.roundDropDown);
            this.Controls.Add(this.roundLabel);
            this.Controls.Add(this.tournamentName);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "TournamentViewerForm";
            this.Text = "Tournament Viewer";
            this.Load += new System.EventHandler(this.TournamentViewerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label tournamentName;
        private System.Windows.Forms.Label roundLabel;
        private System.Windows.Forms.ComboBox roundDropDown;
        private System.Windows.Forms.CheckBox unplayedOnlyCheckBox;
        private System.Windows.Forms.ListBox matchListBox;
        private System.Windows.Forms.Label team1NameLabel;
        private System.Windows.Forms.Label team1ScoreLabel;
        private System.Windows.Forms.TextBox team1ScoreText;
        private System.Windows.Forms.TextBox team2ScoreText;
        private System.Windows.Forms.Label team2ScoreLabel;
        private System.Windows.Forms.Label team2NameLabel;
        private System.Windows.Forms.Label versusLabel;
        private System.Windows.Forms.Button submitScoreButton;
    }
}

