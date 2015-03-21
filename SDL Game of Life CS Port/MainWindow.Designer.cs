namespace SDL_Game_of_Life_CS_Port
{
    partial class MainWindow
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.rulesTextBox = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.loadFileButton = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.hlComboBox = new System.Windows.Forms.ComboBox();
			this.glComboBox = new System.Windows.Forms.ComboBox();
			this.startButton = new System.Windows.Forms.Button();
			this.loadFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.widthTextBox = new System.Windows.Forms.TextBox();
			this.heightTextBox = new System.Windows.Forms.TextBox();
			this.tabControl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage1);
			this.tabControl.Controls.Add(this.tabPage2);
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(348, 146);
			this.tabControl.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.heightTextBox);
			this.tabPage1.Controls.Add(this.widthTextBox);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.rulesTextBox);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(340, 120);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "New Game";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Rules String:";
			// 
			// rulesTextBox
			// 
			this.rulesTextBox.Location = new System.Drawing.Point(187, 60);
			this.rulesTextBox.Name = "rulesTextBox";
			this.rulesTextBox.Size = new System.Drawing.Size(143, 20);
			this.rulesTextBox.TabIndex = 4;
			this.rulesTextBox.Text = "B3/S23";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.loadFileButton);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.hlComboBox);
			this.tabPage2.Controls.Add(this.glComboBox);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(340, 120);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Presets";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// loadFileButton
			// 
			this.loadFileButton.Location = new System.Drawing.Point(11, 91);
			this.loadFileButton.Name = "loadFileButton";
			this.loadFileButton.Size = new System.Drawing.Size(75, 23);
			this.loadFileButton.TabIndex = 4;
			this.loadFileButton.Text = "Custom...";
			this.loadFileButton.UseVisualStyleBackColor = true;
			this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 45);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "High Life (B36/S23):";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 18);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(116, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Game of Life (B3/S23):";
			// 
			// hlComboBox
			// 
			this.hlComboBox.FormattingEnabled = true;
			this.hlComboBox.Items.AddRange(new object[] {
            "Replicator"});
			this.hlComboBox.Location = new System.Drawing.Point(187, 42);
			this.hlComboBox.Name = "hlComboBox";
			this.hlComboBox.Size = new System.Drawing.Size(143, 21);
			this.hlComboBox.TabIndex = 1;
			this.hlComboBox.SelectedIndexChanged += new System.EventHandler(this.hlComboBox_SelectedIndexChanged);
			// 
			// glComboBox
			// 
			this.glComboBox.FormattingEnabled = true;
			this.glComboBox.Items.AddRange(new object[] {
            "Glider Gun Synthesis",
            "X",
            "Cross",
            "Horizontal Line",
            "Vertical Line",
            "Vortex",
            "Vortex Fail"});
			this.glComboBox.Location = new System.Drawing.Point(187, 15);
			this.glComboBox.Name = "glComboBox";
			this.glComboBox.Size = new System.Drawing.Size(143, 21);
			this.glComboBox.TabIndex = 0;
			this.glComboBox.SelectedIndexChanged += new System.EventHandler(this.glComboBox_SelectedIndexChanged);
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(15, 152);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 4;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// loadFileDialog
			// 
			this.loadFileDialog.DefaultExt = "gol";
			this.loadFileDialog.Filter = "GOL Files (*.gol)|*.gol";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Grid Width:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Grid Height:";
			// 
			// widthTextBox
			// 
			this.widthTextBox.Location = new System.Drawing.Point(187, 7);
			this.widthTextBox.Name = "widthTextBox";
			this.widthTextBox.Size = new System.Drawing.Size(143, 20);
			this.widthTextBox.TabIndex = 10;
			this.widthTextBox.Text = "75";
			// 
			// heightTextBox
			// 
			this.heightTextBox.Location = new System.Drawing.Point(187, 34);
			this.heightTextBox.Name = "heightTextBox";
			this.heightTextBox.Size = new System.Drawing.Size(143, 20);
			this.heightTextBox.TabIndex = 11;
			this.heightTextBox.Text = "75";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 184);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.tabControl);
			this.Name = "MainWindow";
			this.Text = "SDL Game of Life";
			this.tabControl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox rulesTextBox;
        private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox hlComboBox;
		private System.Windows.Forms.ComboBox glComboBox;
		private System.Windows.Forms.Button loadFileButton;
		private System.Windows.Forms.OpenFileDialog loadFileDialog;
		private System.Windows.Forms.TextBox heightTextBox;
		private System.Windows.Forms.TextBox widthTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
    }
}

