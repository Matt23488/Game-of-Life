namespace SDL_Game_of_Life_CS_Port
{
	partial class SelectStructureDialog
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
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.spaceShipListBox = new System.Windows.Forms.ListBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.oscillatorListBox = new System.Windows.Forms.ListBox();
			this.stillLifeListBox = new System.Windows.Forms.ListBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(94, 257);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 0;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(12, 257);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// spaceShipListBox
			// 
			this.spaceShipListBox.FormattingEnabled = true;
			this.spaceShipListBox.Items.AddRange(new object[] {
            "Glider (B3/S23)",
            "LWSS (B3/S23)"});
			this.spaceShipListBox.Location = new System.Drawing.Point(0, 0);
			this.spaceShipListBox.Name = "spaceShipListBox";
			this.spaceShipListBox.Size = new System.Drawing.Size(244, 225);
			this.spaceShipListBox.TabIndex = 2;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(252, 251);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.spaceShipListBox);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(244, 225);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Spaceships";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.oscillatorListBox);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(244, 225);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Oscillators";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.stillLifeListBox);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(244, 225);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Still Lifes";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// oscillatorListBox
			// 
			this.oscillatorListBox.FormattingEnabled = true;
			this.oscillatorListBox.Items.AddRange(new object[] {
            "Blinker (B3/S23)",
            "Toad (B3/S23)",
            "Beacon (B3/S23)",
            "Pulsar (B3/S23)",
            "Glider Gun (B3/S23)"});
			this.oscillatorListBox.Location = new System.Drawing.Point(0, 0);
			this.oscillatorListBox.Name = "oscillatorListBox";
			this.oscillatorListBox.Size = new System.Drawing.Size(244, 225);
			this.oscillatorListBox.TabIndex = 0;
			// 
			// stillLifeListBox
			// 
			this.stillLifeListBox.FormattingEnabled = true;
			this.stillLifeListBox.Items.AddRange(new object[] {
            "Block (B3/S23)",
            "Beehive (B3/S23)",
            "Loaf (B3/S23)",
            "Boat (B3/S23)"});
			this.stillLifeListBox.Location = new System.Drawing.Point(0, 0);
			this.stillLifeListBox.Name = "stillLifeListBox";
			this.stillLifeListBox.Size = new System.Drawing.Size(244, 225);
			this.stillLifeListBox.TabIndex = 0;
			// 
			// SelectStructureDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(252, 287);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "SelectStructureDialog";
			this.Text = "Choose a Structure";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		public System.Windows.Forms.ListBox spaceShipListBox;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.TabControl tabControl1;
		public System.Windows.Forms.ListBox oscillatorListBox;
		public System.Windows.Forms.ListBox stillLifeListBox;
	}
}