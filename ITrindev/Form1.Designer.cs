namespace ITrindev
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
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
            this.enterDataButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.displayButton = new System.Windows.Forms.Button();
            this.summaryButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.exemptionTextBox = new System.Windows.Forms.TextBox();
            this.investmentTextBox = new System.Windows.Forms.TextBox();
            this.salaryTextBox = new System.Windows.Forms.TextBox();
            this.marriedCheckBox = new System.Windows.Forms.CheckBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.marriedLabel = new System.Windows.Forms.Label();
            this.exemptionLabel = new System.Windows.Forms.Label();
            this.investmentLabel = new System.Windows.Forms.Label();
            this.salaryLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // enterDataButton
            // 
            this.enterDataButton.Location = new System.Drawing.Point(40, 13);
            this.enterDataButton.Name = "enterDataButton";
            this.enterDataButton.Size = new System.Drawing.Size(75, 23);
            this.enterDataButton.TabIndex = 0;
            this.enterDataButton.Text = "Enter Data";
            this.enterDataButton.UseVisualStyleBackColor = true;
            this.enterDataButton.Click += new System.EventHandler(this.enterDataButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(149, 13);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(258, 13);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // displayButton
            // 
            this.displayButton.Location = new System.Drawing.Point(367, 13);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(75, 23);
            this.displayButton.TabIndex = 3;
            this.displayButton.Text = "Display";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // summaryButton
            // 
            this.summaryButton.Location = new System.Drawing.Point(476, 13);
            this.summaryButton.Name = "summaryButton";
            this.summaryButton.Size = new System.Drawing.Size(75, 23);
            this.summaryButton.TabIndex = 4;
            this.summaryButton.Text = "Summary";
            this.summaryButton.UseVisualStyleBackColor = true;
            this.summaryButton.Click += new System.EventHandler(this.summaryButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(694, 13);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(585, 13);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(149, 84);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 7;
            this.nameTextBox.Visible = false;
            // 
            // exemptionTextBox
            // 
            this.exemptionTextBox.Location = new System.Drawing.Point(560, 84);
            this.exemptionTextBox.Name = "exemptionTextBox";
            this.exemptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.exemptionTextBox.TabIndex = 10;
            this.exemptionTextBox.Visible = false;
            // 
            // investmentTextBox
            // 
            this.investmentTextBox.Location = new System.Drawing.Point(423, 84);
            this.investmentTextBox.Name = "investmentTextBox";
            this.investmentTextBox.Size = new System.Drawing.Size(100, 20);
            this.investmentTextBox.TabIndex = 9;
            this.investmentTextBox.Visible = false;
            // 
            // salaryTextBox
            // 
            this.salaryTextBox.Location = new System.Drawing.Point(286, 84);
            this.salaryTextBox.Name = "salaryTextBox";
            this.salaryTextBox.Size = new System.Drawing.Size(100, 20);
            this.salaryTextBox.TabIndex = 8;
            this.salaryTextBox.Visible = false;
            // 
            // marriedCheckBox
            // 
            this.marriedCheckBox.AutoSize = true;
            this.marriedCheckBox.Location = new System.Drawing.Point(367, 123);
            this.marriedCheckBox.Name = "marriedCheckBox";
            this.marriedCheckBox.Size = new System.Drawing.Size(61, 17);
            this.marriedCheckBox.TabIndex = 11;
            this.marriedCheckBox.Text = "Married";
            this.marriedCheckBox.UseVisualStyleBackColor = true;
            this.marriedCheckBox.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(149, 65);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 13;
            this.nameLabel.Text = "Name:";
            this.nameLabel.Visible = false;
            // 
            // marriedLabel
            // 
            this.marriedLabel.AutoSize = true;
            this.marriedLabel.Location = new System.Drawing.Point(364, 107);
            this.marriedLabel.Name = "marriedLabel";
            this.marriedLabel.Size = new System.Drawing.Size(86, 13);
            this.marriedLabel.TabIndex = 17;
            this.marriedLabel.Text = "Check if married:";
            this.marriedLabel.Visible = false;
            // 
            // exemptionLabel
            // 
            this.exemptionLabel.AutoSize = true;
            this.exemptionLabel.Location = new System.Drawing.Point(557, 65);
            this.exemptionLabel.Name = "exemptionLabel";
            this.exemptionLabel.Size = new System.Drawing.Size(94, 13);
            this.exemptionLabel.TabIndex = 16;
            this.exemptionLabel.Text = "Exemptions (0 - 3):";
            this.exemptionLabel.Visible = false;
            // 
            // investmentLabel
            // 
            this.investmentLabel.AutoSize = true;
            this.investmentLabel.Location = new System.Drawing.Point(420, 65);
            this.investmentLabel.Name = "investmentLabel";
            this.investmentLabel.Size = new System.Drawing.Size(100, 13);
            this.investmentLabel.TabIndex = 15;
            this.investmentLabel.Text = "Investment Income:";
            this.investmentLabel.Visible = false;
            // 
            // salaryLabel
            // 
            this.salaryLabel.AutoSize = true;
            this.salaryLabel.Location = new System.Drawing.Point(283, 65);
            this.salaryLabel.Name = "salaryLabel";
            this.salaryLabel.Size = new System.Drawing.Size(39, 13);
            this.salaryLabel.TabIndex = 14;
            this.salaryLabel.Text = "Salary:";
            this.salaryLabel.Visible = false;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(367, 146);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 12;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Visible = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(679, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Created by Ivan Trindev";
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(41, 175);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(620, 266);
            this.outputTextBox.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.salaryLabel);
            this.Controls.Add(this.investmentLabel);
            this.Controls.Add(this.exemptionLabel);
            this.Controls.Add(this.marriedLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.marriedCheckBox);
            this.Controls.Add(this.salaryTextBox);
            this.Controls.Add(this.investmentTextBox);
            this.Controls.Add(this.exemptionTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.summaryButton);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.enterDataButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterDataButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.Button summaryButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox exemptionTextBox;
        private System.Windows.Forms.TextBox investmentTextBox;
        private System.Windows.Forms.TextBox salaryTextBox;
        private System.Windows.Forms.CheckBox marriedCheckBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label marriedLabel;
        private System.Windows.Forms.Label exemptionLabel;
        private System.Windows.Forms.Label investmentLabel;
        private System.Windows.Forms.Label salaryLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox outputTextBox;
    }
}

