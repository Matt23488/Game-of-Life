namespace SDL_Game_of_Life_CS_Port
{
	partial class ToolBoxWindow
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBoxWindow));
			this.saveStateDialog = new System.Windows.Forms.SaveFileDialog();
			this.form2ToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.quitButton = new System.Windows.Forms.Button();
			this.startButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.stopButton = new System.Windows.Forms.Button();
			this.clearButton = new System.Windows.Forms.Button();
			this.advanceButton = new System.Windows.Forms.Button();
			this.insertStructureButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cellSizeSelector = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.delaySelector = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.wrapCheckBox = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.cellSizeSelector)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.delaySelector)).BeginInit();
			this.SuspendLayout();
			// 
			// saveStateDialog
			// 
			this.saveStateDialog.DefaultExt = "gol";
			this.saveStateDialog.Filter = "GOL Files (*.gol)|*.gol";
			// 
			// quitButton
			// 
			this.quitButton.Image = ((System.Drawing.Image)(resources.GetObject("quitButton.Image")));
			this.quitButton.Location = new System.Drawing.Point(104, 71);
			this.quitButton.Name = "quitButton";
			this.quitButton.Size = new System.Drawing.Size(40, 40);
			this.quitButton.TabIndex = 5;
			this.form2ToolTip.SetToolTip(this.quitButton, "Return back to the main application window");
			this.quitButton.UseVisualStyleBackColor = true;
			this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
			// 
			// startButton
			// 
			this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
			this.startButton.Location = new System.Drawing.Point(12, 25);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(40, 40);
			this.startButton.TabIndex = 0;
			this.form2ToolTip.SetToolTip(this.startButton, "Begin the simulation");
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.startButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.Image = global::SDL_Game_of_Life_CS_Port.Properties.Resources.saveIcon;
			this.saveButton.Location = new System.Drawing.Point(58, 71);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(40, 40);
			this.saveButton.TabIndex = 4;
			this.form2ToolTip.SetToolTip(this.saveButton, "Save this grid state to a file");
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// stopButton
			// 
			this.stopButton.Enabled = false;
			this.stopButton.Image = global::SDL_Game_of_Life_CS_Port.Properties.Resources.stopIcon;
			this.stopButton.Location = new System.Drawing.Point(58, 25);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(40, 40);
			this.stopButton.TabIndex = 1;
			this.form2ToolTip.SetToolTip(this.stopButton, "Stop the simulation");
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// clearButton
			// 
			this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
			this.clearButton.Location = new System.Drawing.Point(12, 71);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(40, 40);
			this.clearButton.TabIndex = 3;
			this.form2ToolTip.SetToolTip(this.clearButton, "Clear the entire grid");
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// advanceButton
			// 
			this.advanceButton.Image = ((System.Drawing.Image)(resources.GetObject("advanceButton.Image")));
			this.advanceButton.Location = new System.Drawing.Point(104, 25);
			this.advanceButton.Name = "advanceButton";
			this.advanceButton.Size = new System.Drawing.Size(40, 40);
			this.advanceButton.TabIndex = 2;
			this.form2ToolTip.SetToolTip(this.advanceButton, "Advance the simulation by one generation");
			this.advanceButton.UseVisualStyleBackColor = true;
			this.advanceButton.Click += new System.EventHandler(this.advanceButton_Click);
			// 
			// insertStructureButton
			// 
			this.insertStructureButton.Image = global::SDL_Game_of_Life_CS_Port.Properties.Resources.gliderIcon;
			this.insertStructureButton.Location = new System.Drawing.Point(12, 254);
			this.insertStructureButton.Name = "insertStructureButton";
			this.insertStructureButton.Size = new System.Drawing.Size(40, 40);
			this.insertStructureButton.TabIndex = 8;
			this.form2ToolTip.SetToolTip(this.insertStructureButton, "Insert structure");
			this.insertStructureButton.UseVisualStyleBackColor = true;
			this.insertStructureButton.Click += new System.EventHandler(this.insertStructureButton_Click);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Simulation Controls";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 238);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Tools";
			// 
			// cellSizeSelector
			// 
			this.cellSizeSelector.Location = new System.Drawing.Point(86, 117);
			this.cellSizeSelector.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.cellSizeSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.cellSizeSelector.Name = "cellSizeSelector";
			this.cellSizeSelector.Size = new System.Drawing.Size(58, 20);
			this.cellSizeSelector.TabIndex = 9;
			this.cellSizeSelector.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.cellSizeSelector.ValueChanged += new System.EventHandler(this.cellSizeSelector_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 119);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Cell Size (px):";
			// 
			// delaySelector
			// 
			this.delaySelector.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.delaySelector.Location = new System.Drawing.Point(86, 144);
			this.delaySelector.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.delaySelector.Name = "delaySelector";
			this.delaySelector.Size = new System.Drawing.Size(58, 20);
			this.delaySelector.TabIndex = 11;
			this.delaySelector.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
			this.delaySelector.ValueChanged += new System.EventHandler(this.delaySelector_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 146);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Delay (ms):";
			// 
			// wrapCheckBox
			// 
			this.wrapCheckBox.AutoSize = true;
			this.wrapCheckBox.Location = new System.Drawing.Point(12, 170);
			this.wrapCheckBox.Name = "wrapCheckBox";
			this.wrapCheckBox.Size = new System.Drawing.Size(74, 17);
			this.wrapCheckBox.TabIndex = 13;
			this.wrapCheckBox.Text = "Grid Wrap";
			this.wrapCheckBox.UseVisualStyleBackColor = true;
			this.wrapCheckBox.CheckedChanged += new System.EventHandler(this.wrapCheckBox_CheckedChanged);
			// 
			// ToolBoxWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(156, 306);
			this.Controls.Add(this.wrapCheckBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.delaySelector);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cellSizeSelector);
			this.Controls.Add(this.insertStructureButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.quitButton);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.clearButton);
			this.Controls.Add(this.advanceButton);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ToolBoxWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Tools";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
			this.Shown += new System.EventHandler(this.ToolBoxWindow_Show);
			((System.ComponentModel.ISupportInitialize)(this.cellSizeSelector)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.delaySelector)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.Button advanceButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button quitButton;
		private System.Windows.Forms.SaveFileDialog saveStateDialog;
		private System.Windows.Forms.ToolTip form2ToolTip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button insertStructureButton;
		private System.Windows.Forms.NumericUpDown cellSizeSelector;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown delaySelector;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox wrapCheckBox;
	}
}