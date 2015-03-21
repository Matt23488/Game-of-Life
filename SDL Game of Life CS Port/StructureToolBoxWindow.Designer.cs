namespace SDL_Game_of_Life_CS_Port
{
	partial class StructureToolBoxWindow
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
			this.finishButton = new System.Windows.Forms.Button();
			this.moveButton = new System.Windows.Forms.Button();
			this.flipVerticalButton = new System.Windows.Forms.Button();
			this.flipHorizontalButton = new System.Windows.Forms.Button();
			this.rotateRightButton = new System.Windows.Forms.Button();
			this.rotateLeftButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// finishButton
			// 
			this.finishButton.Enabled = false;
			this.finishButton.Location = new System.Drawing.Point(12, 195);
			this.finishButton.Name = "finishButton";
			this.finishButton.Size = new System.Drawing.Size(87, 23);
			this.finishButton.TabIndex = 0;
			this.finishButton.Text = "Finished";
			this.finishButton.UseVisualStyleBackColor = true;
			this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
			// 
			// moveButton
			// 
			this.moveButton.Enabled = false;
			this.moveButton.Location = new System.Drawing.Point(12, 12);
			this.moveButton.Name = "moveButton";
			this.moveButton.Size = new System.Drawing.Size(87, 23);
			this.moveButton.TabIndex = 1;
			this.moveButton.Text = "Move";
			this.moveButton.UseVisualStyleBackColor = true;
			this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
			// 
			// flipVerticalButton
			// 
			this.flipVerticalButton.Image = global::SDL_Game_of_Life_CS_Port.Properties.Resources.flipVerticalIcon;
			this.flipVerticalButton.Location = new System.Drawing.Point(59, 89);
			this.flipVerticalButton.Name = "flipVerticalButton";
			this.flipVerticalButton.Size = new System.Drawing.Size(40, 40);
			this.flipVerticalButton.TabIndex = 5;
			this.flipVerticalButton.UseVisualStyleBackColor = true;
			this.flipVerticalButton.Click += new System.EventHandler(this.flipVerticalButton_Click);
			// 
			// flipHorizontalButton
			// 
			this.flipHorizontalButton.Image = global::SDL_Game_of_Life_CS_Port.Properties.Resources.flipHorizontalIcon;
			this.flipHorizontalButton.Location = new System.Drawing.Point(13, 89);
			this.flipHorizontalButton.Name = "flipHorizontalButton";
			this.flipHorizontalButton.Size = new System.Drawing.Size(40, 40);
			this.flipHorizontalButton.TabIndex = 4;
			this.flipHorizontalButton.UseVisualStyleBackColor = true;
			this.flipHorizontalButton.Click += new System.EventHandler(this.flipHorizontalButton_Click);
			// 
			// rotateRightButton
			// 
			this.rotateRightButton.Enabled = false;
			this.rotateRightButton.Image = global::SDL_Game_of_Life_CS_Port.Properties.Resources.rotateRightIcon;
			this.rotateRightButton.Location = new System.Drawing.Point(59, 41);
			this.rotateRightButton.Name = "rotateRightButton";
			this.rotateRightButton.Size = new System.Drawing.Size(40, 40);
			this.rotateRightButton.TabIndex = 3;
			this.rotateRightButton.UseVisualStyleBackColor = true;
			this.rotateRightButton.Click += new System.EventHandler(this.rotateRightButton_Click);
			// 
			// rotateLeftButton
			// 
			this.rotateLeftButton.Enabled = false;
			this.rotateLeftButton.Image = global::SDL_Game_of_Life_CS_Port.Properties.Resources.rotateLeftIcon;
			this.rotateLeftButton.Location = new System.Drawing.Point(13, 42);
			this.rotateLeftButton.Name = "rotateLeftButton";
			this.rotateLeftButton.Size = new System.Drawing.Size(40, 40);
			this.rotateLeftButton.TabIndex = 2;
			this.rotateLeftButton.UseVisualStyleBackColor = true;
			this.rotateLeftButton.Click += new System.EventHandler(this.rotateLeftButton_Click);
			// 
			// StructureToolBoxWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(112, 230);
			this.Controls.Add(this.flipVerticalButton);
			this.Controls.Add(this.flipHorizontalButton);
			this.Controls.Add(this.rotateRightButton);
			this.Controls.Add(this.rotateLeftButton);
			this.Controls.Add(this.moveButton);
			this.Controls.Add(this.finishButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "StructureToolBoxWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "StructureToolBoxWindow";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StructureToolBoxWindow_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button finishButton;
		private System.Windows.Forms.Button moveButton;
		private System.Windows.Forms.Button rotateLeftButton;
		private System.Windows.Forms.Button rotateRightButton;
		private System.Windows.Forms.Button flipHorizontalButton;
		private System.Windows.Forms.Button flipVerticalButton;
	}
}