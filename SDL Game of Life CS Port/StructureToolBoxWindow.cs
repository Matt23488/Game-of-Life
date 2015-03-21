using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDL_Game_of_Life_CS_Port
{
	public partial class StructureToolBoxWindow : Form
	{
		public ToolBoxWindow parent;

		private bool _close;

		public StructureToolBoxWindow()
		{
			InitializeComponent();

			Point location = Location;
			location.X += 100;
			Location = location;

			Global.buttons.Add(finishButton);
			Global.buttons.Add(moveButton);
			Global.buttons.Add(rotateLeftButton);
			Global.buttons.Add(rotateRightButton);

			_close = false;
		}

		private void StructureToolBoxWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_close)
			{
				e.Cancel = true;
				return;
			}

			parent.Show();
		}

		private void finishButton_Click(object sender, EventArgs e)
		{
			Global.messages.Add(GOL_Message.Quit);
			_close = true;
			this.Close();
		}

		private void moveButton_Click(object sender, EventArgs e)
		{
			moveButton.Enabled = false;
			finishButton.Enabled = false;
			rotateLeftButton.Enabled = false;
			rotateRightButton.Enabled = false;
			Global.buttons.Add(finishButton);
			Global.buttons.Add(moveButton);
			Global.buttons.Add(rotateLeftButton);
			Global.buttons.Add(rotateRightButton);
			Global.messages.Add(GOL_Message.Move);
		}

		private void rotateLeftButton_Click(object sender, EventArgs e)
		{
			Global.messages.Add(GOL_Message.RotateLeft);
		}

		private void rotateRightButton_Click(object sender, EventArgs e)
		{
			Global.messages.Add(GOL_Message.RotateRight);
		}

		private void flipHorizontalButton_Click(object sender, EventArgs e)
		{
			Global.messages.Add(GOL_Message.FlipHorizontal);
		}

		private void flipVerticalButton_Click(object sender, EventArgs e)
		{
			Global.messages.Add(GOL_Message.FlipVertical);
		}
	}
}
