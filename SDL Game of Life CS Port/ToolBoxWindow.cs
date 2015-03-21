using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDL_Game_of_Life_CS_Port
{
	public partial class ToolBoxWindow : Form
	{
		public MainWindow parent;

		private bool _settingUp;
		private bool _paused;
		private bool _close;

		public ToolBoxWindow()
		{
			InitializeComponent();

			Point location = Location;
			location.X += 100;
			Location = location;

			_settingUp = true;
			_paused = false;
			_close = false;
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_close) e.Cancel = true;
		}

		#region Controls Event Handlers

		private void startButton_Click(object sender, EventArgs e)
		{
			if (_settingUp)
			{
				_settingUp = false;
				startButton.Image = new Bitmap(SDL_Game_of_Life_CS_Port.Properties.Resources.pauseIcon);
				stopButton.Enabled = true;
				advanceButton.Enabled = false;
				clearButton.Enabled = false;
				saveButton.Enabled = false;
				insertStructureButton.Enabled = false;
				form2ToolTip.SetToolTip(startButton, "Pause the simulation");

				Global.messages.Add(GOL_Message.Start);
			}
			else if (!_settingUp && !_paused)
			{
				_paused = true;
				startButton.Image = new Bitmap(SDL_Game_of_Life_CS_Port.Properties.Resources.playIcon);
				advanceButton.Enabled = true;
				insertStructureButton.Enabled = true;
				form2ToolTip.SetToolTip(startButton, "Resume the simulation");

				Global.messages.Add(GOL_Message.Pause);
			}
			else if (_paused)
			{
				_paused = false;
				startButton.Image = new Bitmap(SDL_Game_of_Life_CS_Port.Properties.Resources.pauseIcon);
				advanceButton.Enabled = false;
				insertStructureButton.Enabled = false;
				form2ToolTip.SetToolTip(startButton, "Pause the simulation");

				Global.messages.Add(GOL_Message.Resume);
			}
		}

		private void stopButton_Click(object sender, EventArgs e)
		{
			_paused = false;
			_settingUp = true;
			startButton.Image = new Bitmap(SDL_Game_of_Life_CS_Port.Properties.Resources.playIcon);
			stopButton.Enabled = false;
			advanceButton.Enabled = true;
			clearButton.Enabled = true;
			saveButton.Enabled = true;
			insertStructureButton.Enabled = true;
			form2ToolTip.SetToolTip(startButton, "Begin the simulation");

			Global.messages.Add(GOL_Message.Stop);
		}

		private void advanceButton_Click(object sender, EventArgs e)
		{
			_settingUp = false;
			_paused = true;
			stopButton.Enabled = true;
			clearButton.Enabled = false;
			saveButton.Enabled = false;

			Global.messages.Add(GOL_Message.Advance);
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			Global.messages.Add(GOL_Message.Clear);
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			DialogResult result = saveStateDialog.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.Cancel) return;

			Global.messages.Add(GOL_Message.Suspend);
			StreamWriter file = new StreamWriter(saveStateDialog.FileName);
			Global.fStreams.Add(file);
			Global.messages.Add(GOL_Message.Save);
			Global.messages.Add(GOL_Message.Resume);

			bool saved = false;

			while (!saved)
			{
				if (Global.saved.Count > 0)
				{
					saved = Global.saved.Take();
				}
			}

			file.Close();

			MessageBox.Show("File \"" + saveStateDialog.FileName + "\" was saved successfully.",
				"Saved",
				MessageBoxButtons.OK,
				MessageBoxIcon.Asterisk);
		}

		private void quitButton_Click(object sender, EventArgs e)
		{
			_close = true;
			Global.messages.Add(GOL_Message.Quit);
		}

		#endregion

		#region Tools Event Handlers

		private void insertStructureButton_Click(object sender, EventArgs e)
		{
			bool[,] structure = Global.Glider;

			using (SelectStructureDialog dialog = new SelectStructureDialog())
			{
				DialogResult result = dialog.ShowDialog();

				if (result == System.Windows.Forms.DialogResult.Cancel) return;

				switch (dialog.tabControl1.SelectedIndex)
				{
					case 0:
						switch (dialog.spaceShipListBox.SelectedIndex)
						{
							case 1:
								structure = Global.LWSS;
								break;
						}
						break;
					case 1:
						switch (dialog.oscillatorListBox.SelectedIndex)
						{
							case 0:
								structure = Global.Blinker;
								break;
							case 1:
								structure = Global.Toad;
								break;
							case 2:
								structure = Global.Beacon;
								break;
							case 3:
								structure = Global.Pulsar;
								break;
							case 4:
								structure = Global.GliderGun;
								break;
						}
						break;
					case 2:
						switch (dialog.stillLifeListBox.SelectedIndex)
						{
							case 0:
								structure = Global.Block;
								break;
							case 1:
								structure = Global.Beehive;
								break;
							case 2:
								structure = Global.Loaf;
								break;
							case 3:
								structure = Global.Boat;
								break;
						}
						break;
				}
			}

			if (structure.GetLength(0) > parent.width || structure.GetLength(1) > parent.height) return;

			this.Hide();

			StructureToolBoxWindow window = new StructureToolBoxWindow();
			window.parent = this;
			window.Show();

			Global.structures.Add(structure);
			Global.messages.Add(GOL_Message.Insert);
		}

		#endregion

		private void cellSizeSelector_ValueChanged(object sender, EventArgs e)
		{
			Global.intData.Add(Convert.ToInt32(cellSizeSelector.Value));
			Global.messages.Add(GOL_Message.ChangeCellSize);
		}

		private void delaySelector_ValueChanged(object sender, EventArgs e)
		{
			Global.intData.Add(Convert.ToInt32(delaySelector.Value));
			Global.messages.Add(GOL_Message.ChangeDelay);
		}

		private void wrapCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Global.intData.Add(wrapCheckBox.Checked ? 1 : 0);
			Global.messages.Add(GOL_Message.ChangeWrap);
		}

		private void ToolBoxWindow_Show(object sender, EventArgs e)
		{
			if (parent.custom) cellSizeSelector.Value = parent.cellSize;
			parent.custom = false;
		}
	}
}