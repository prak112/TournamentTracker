namespace TrackerUI
{
    partial class CreateTeamForm
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
            this.teamNameText = new System.Windows.Forms.TextBox();
            this.teamNameLabel = new System.Windows.Forms.Label();
            this.selectTeamMemberLabel = new System.Windows.Forms.Label();
            this.teamMemberDropDown = new System.Windows.Forms.ComboBox();
            this.addTeamMemberButton = new System.Windows.Forms.Button();
            this.addNewMemberGroupBox = new System.Windows.Forms.GroupBox();
            this.createMemberButton = new System.Windows.Forms.Button();
            this.emailText = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.phoneText = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.lastNameText = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameText = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.teamMembersListBox = new System.Windows.Forms.ListBox();
            this.deleteTeamMemberButton = new System.Windows.Forms.Button();
            this.createTeamButton = new System.Windows.Forms.Button();
            this.addNewMemberGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.headerLabel.Location = new System.Drawing.Point(325, 30);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(210, 47);
            this.headerLabel.TabIndex = 2;
            this.headerLabel.Text = "Create Team";
            // 
            // teamNameText
            // 
            this.teamNameText.Location = new System.Drawing.Point(67, 143);
            this.teamNameText.Name = "teamNameText";
            this.teamNameText.Size = new System.Drawing.Size(339, 33);
            this.teamNameText.TabIndex = 12;
            // 
            // teamNameLabel
            // 
            this.teamNameLabel.AutoSize = true;
            this.teamNameLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamNameLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.teamNameLabel.Location = new System.Drawing.Point(61, 108);
            this.teamNameLabel.Name = "teamNameLabel";
            this.teamNameLabel.Size = new System.Drawing.Size(142, 32);
            this.teamNameLabel.TabIndex = 11;
            this.teamNameLabel.Text = "Team Name";
            // 
            // selectTeamMemberLabel
            // 
            this.selectTeamMemberLabel.AutoSize = true;
            this.selectTeamMemberLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTeamMemberLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.selectTeamMemberLabel.Location = new System.Drawing.Point(61, 204);
            this.selectTeamMemberLabel.Name = "selectTeamMemberLabel";
            this.selectTeamMemberLabel.Size = new System.Drawing.Size(240, 32);
            this.selectTeamMemberLabel.TabIndex = 13;
            this.selectTeamMemberLabel.Text = "Select Team Member";
            // 
            // teamMemberDropDown
            // 
            this.teamMemberDropDown.FormattingEnabled = true;
            this.teamMemberDropDown.Location = new System.Drawing.Point(67, 240);
            this.teamMemberDropDown.Name = "teamMemberDropDown";
            this.teamMemberDropDown.Size = new System.Drawing.Size(339, 33);
            this.teamMemberDropDown.TabIndex = 14;
            // 
            // addTeamMemberButton
            // 
            this.addTeamMemberButton.BackColor = System.Drawing.Color.Beige;
            this.addTeamMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.addTeamMemberButton.FlatAppearance.BorderSize = 2;
            this.addTeamMemberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cornsilk;
            this.addTeamMemberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.addTeamMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeamMemberButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeamMemberButton.ForeColor = System.Drawing.Color.Olive;
            this.addTeamMemberButton.Location = new System.Drawing.Point(126, 281);
            this.addTeamMemberButton.Margin = new System.Windows.Forms.Padding(5);
            this.addTeamMemberButton.Name = "addTeamMemberButton";
            this.addTeamMemberButton.Padding = new System.Windows.Forms.Padding(2);
            this.addTeamMemberButton.Size = new System.Drawing.Size(206, 55);
            this.addTeamMemberButton.TabIndex = 17;
            this.addTeamMemberButton.Text = "Add Member";
            this.addTeamMemberButton.UseVisualStyleBackColor = false;
            // 
            // addNewMemberGroupBox
            // 
            this.addNewMemberGroupBox.Controls.Add(this.createMemberButton);
            this.addNewMemberGroupBox.Controls.Add(this.emailText);
            this.addNewMemberGroupBox.Controls.Add(this.emailLabel);
            this.addNewMemberGroupBox.Controls.Add(this.phoneText);
            this.addNewMemberGroupBox.Controls.Add(this.phoneLabel);
            this.addNewMemberGroupBox.Controls.Add(this.lastNameText);
            this.addNewMemberGroupBox.Controls.Add(this.lastNameLabel);
            this.addNewMemberGroupBox.Controls.Add(this.firstNameText);
            this.addNewMemberGroupBox.Controls.Add(this.firstNameLabel);
            this.addNewMemberGroupBox.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewMemberGroupBox.ForeColor = System.Drawing.Color.OrangeRed;
            this.addNewMemberGroupBox.Location = new System.Drawing.Point(67, 381);
            this.addNewMemberGroupBox.Name = "addNewMemberGroupBox";
            this.addNewMemberGroupBox.Size = new System.Drawing.Size(339, 271);
            this.addNewMemberGroupBox.TabIndex = 18;
            this.addNewMemberGroupBox.TabStop = false;
            this.addNewMemberGroupBox.Text = "Add New Member";
            // 
            // createMemberButton
            // 
            this.createMemberButton.BackColor = System.Drawing.Color.Beige;
            this.createMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.createMemberButton.FlatAppearance.BorderSize = 2;
            this.createMemberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cornsilk;
            this.createMemberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.createMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createMemberButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createMemberButton.ForeColor = System.Drawing.Color.Olive;
            this.createMemberButton.Location = new System.Drawing.Point(59, 216);
            this.createMemberButton.Margin = new System.Windows.Forms.Padding(5);
            this.createMemberButton.Name = "createMemberButton";
            this.createMemberButton.Padding = new System.Windows.Forms.Padding(2);
            this.createMemberButton.Size = new System.Drawing.Size(206, 47);
            this.createMemberButton.TabIndex = 19;
            this.createMemberButton.Text = "Create Member";
            this.createMemberButton.UseVisualStyleBackColor = false;
            this.createMemberButton.Click += new System.EventHandler(this.createMemberButton_Click);
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(152, 164);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(181, 39);
            this.emailText.TabIndex = 16;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.emailLabel.Location = new System.Drawing.Point(17, 165);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(92, 32);
            this.emailLabel.TabIndex = 15;
            this.emailLabel.Text = "E-Mail*";
            // 
            // phoneText
            // 
            this.phoneText.Location = new System.Drawing.Point(152, 121);
            this.phoneText.Name = "phoneText";
            this.phoneText.Size = new System.Drawing.Size(181, 39);
            this.phoneText.TabIndex = 14;
            this.phoneText.Text = "+358";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.phoneLabel.Location = new System.Drawing.Point(17, 121);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(82, 32);
            this.phoneLabel.TabIndex = 13;
            this.phoneLabel.Text = "Phone";
            // 
            // lastNameText
            // 
            this.lastNameText.Location = new System.Drawing.Point(152, 81);
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.Size = new System.Drawing.Size(181, 39);
            this.lastNameText.TabIndex = 12;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.lastNameLabel.Location = new System.Drawing.Point(17, 82);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(136, 32);
            this.lastNameLabel.TabIndex = 11;
            this.lastNameLabel.Text = "Last Name*";
            // 
            // firstNameText
            // 
            this.firstNameText.Location = new System.Drawing.Point(152, 42);
            this.firstNameText.Name = "firstNameText";
            this.firstNameText.Size = new System.Drawing.Size(181, 39);
            this.firstNameText.TabIndex = 10;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.firstNameLabel.Location = new System.Drawing.Point(17, 43);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(139, 32);
            this.firstNameLabel.TabIndex = 9;
            this.firstNameLabel.Text = "First Name*";
            // 
            // teamMembersListBox
            // 
            this.teamMembersListBox.FormattingEnabled = true;
            this.teamMembersListBox.ItemHeight = 25;
            this.teamMembersListBox.Location = new System.Drawing.Point(471, 143);
            this.teamMembersListBox.Name = "teamMembersListBox";
            this.teamMembersListBox.Size = new System.Drawing.Size(360, 429);
            this.teamMembersListBox.TabIndex = 19;
            // 
            // deleteTeamMemberButton
            // 
            this.deleteTeamMemberButton.BackColor = System.Drawing.Color.Beige;
            this.deleteTeamMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.deleteTeamMemberButton.FlatAppearance.BorderSize = 2;
            this.deleteTeamMemberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cornsilk;
            this.deleteTeamMemberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.deleteTeamMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteTeamMemberButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteTeamMemberButton.ForeColor = System.Drawing.Color.Olive;
            this.deleteTeamMemberButton.Location = new System.Drawing.Point(529, 597);
            this.deleteTeamMemberButton.Margin = new System.Windows.Forms.Padding(5);
            this.deleteTeamMemberButton.Name = "deleteTeamMemberButton";
            this.deleteTeamMemberButton.Padding = new System.Windows.Forms.Padding(2);
            this.deleteTeamMemberButton.Size = new System.Drawing.Size(206, 47);
            this.deleteTeamMemberButton.TabIndex = 20;
            this.deleteTeamMemberButton.Text = "Delete Member";
            this.deleteTeamMemberButton.UseVisualStyleBackColor = false;
            // 
            // createTeamButton
            // 
            this.createTeamButton.BackColor = System.Drawing.Color.Beige;
            this.createTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.createTeamButton.FlatAppearance.BorderSize = 2;
            this.createTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cornsilk;
            this.createTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.createTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTeamButton.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTeamButton.ForeColor = System.Drawing.Color.Olive;
            this.createTeamButton.Location = new System.Drawing.Point(333, 678);
            this.createTeamButton.Margin = new System.Windows.Forms.Padding(5);
            this.createTeamButton.Name = "createTeamButton";
            this.createTeamButton.Padding = new System.Windows.Forms.Padding(2);
            this.createTeamButton.Size = new System.Drawing.Size(208, 63);
            this.createTeamButton.TabIndex = 21;
            this.createTeamButton.Text = "Create Team";
            this.createTeamButton.UseVisualStyleBackColor = false;
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(877, 771);
            this.Controls.Add(this.createTeamButton);
            this.Controls.Add(this.deleteTeamMemberButton);
            this.Controls.Add(this.teamMembersListBox);
            this.Controls.Add(this.addNewMemberGroupBox);
            this.Controls.Add(this.addTeamMemberButton);
            this.Controls.Add(this.teamMemberDropDown);
            this.Controls.Add(this.selectTeamMemberLabel);
            this.Controls.Add(this.teamNameText);
            this.Controls.Add(this.teamNameLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CreateTeamForm";
            this.Text = "Create Team";
            this.addNewMemberGroupBox.ResumeLayout(false);
            this.addNewMemberGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox teamNameText;
        private System.Windows.Forms.Label teamNameLabel;
        private System.Windows.Forms.Label selectTeamMemberLabel;
        private System.Windows.Forms.ComboBox teamMemberDropDown;
        private System.Windows.Forms.Button addTeamMemberButton;
        private System.Windows.Forms.GroupBox addNewMemberGroupBox;
        private System.Windows.Forms.TextBox firstNameText;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox phoneText;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox lastNameText;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Button createMemberButton;
        private System.Windows.Forms.ListBox teamMembersListBox;
        private System.Windows.Forms.Button deleteTeamMemberButton;
        private System.Windows.Forms.Button createTeamButton;
    }
}