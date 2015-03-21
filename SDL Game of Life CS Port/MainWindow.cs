using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.IO;

namespace SDL_Game_of_Life_CS_Port
{
    public partial class MainWindow : Form
    {
		public ToolBoxWindow toolBox;
		public int width;
		public int height;
		public bool custom;
		public int cellSize;

        public MainWindow()
        {
            InitializeComponent();

			glComboBox.SelectedIndex = 0;
			custom = false;
        }

		private void startButton_Click(object sender, EventArgs e)
		{
			this.Hide();

			if (rulesTextBox.Text == "") rulesTextBox.Text = "B3/S23";

			int width = Convert.ToInt32(widthTextBox.Text);
			int height = Convert.ToInt32(heightTextBox.Text);
			int cellSize = 7;// Convert.ToInt32(cellSizeTextBox.Text);
			uint delay = 75;// Convert.ToUInt32(delayTextBox.Text);
			string rules = rulesTextBox.Text;
			bool wrap = false;// wrapCheckBox.Checked;

			this.width = width;
			this.height = height;

			toolBox = new ToolBoxWindow();
			toolBox.parent = this;

			List<object> list = new List<object>();
			list.Add(width);
			list.Add(height);
			list.Add(cellSize);
			list.Add(delay);
			list.Add(rules);
			list.Add(wrap);
			list.Add(tabControl.SelectedIndex);
			list.Add(glComboBox.SelectedIndex);
			list.Add(hlComboBox.SelectedIndex);
			list.Add(this);

			Thread thread = new Thread(startGame);

			thread.Start(list);
			toolBox.Show();
		}

		private void startGame(object data)
		{
			List<object> list = (List<object>)data;
			int width = (int)list[0];
			int height = (int)list[1];
			int cellSize = (int)list[2];
			uint delay = (uint)list[3];
			string rules = (string)list[4];
			bool wrap = (bool)list[5];
			int tabSelect = (int)list[6];
			int glSelect = (int)list[7];
			int hlSelect = (int)list[8];

			if (tabSelect == 0)
			{
				GameOfLife game = new GameOfLife(width, height, cellSize, delay, rules, wrap);//, Global.bc);
				game.start();
			}
			else if (glSelect >= 0)
			{
				GOL_PRESET preset = GOL_PRESET.GOL_GLIDERGUN_SYNTH;
				switch (glSelect)
				{
					case 0:
						preset = GOL_PRESET.GOL_GLIDERGUN_SYNTH;
						break;
					case 1:
						preset = GOL_PRESET.GOL_X;
						break;
					case 2:
						preset = GOL_PRESET.GOL_CROSS;
						break;
					case 3:
						preset = GOL_PRESET.GOL_HORIZONTAL;
						break;
					case 4:
						preset = GOL_PRESET.GOL_VERTICAL;
						break;
					case 5:
						preset = GOL_PRESET.GOL_VORTEX;
						break;
					case 6:
						preset = GOL_PRESET.GOL_VORTEXFAIL;
						break;
				}
				GameOfLife game = new GameOfLife(delay, wrap, preset);
				game.start();
			}
			else if (hlSelect >= 0)
			{
				HL_PRESET preset = HL_PRESET.HL_REPLICATOR;
				switch (hlSelect)
				{
					case 0:
						preset = HL_PRESET.HL_REPLICATOR;
						break;
				}
				GameOfLife game = new GameOfLife(delay, wrap, preset);
				game.start();
			}

			MainWindow main = (MainWindow)list[9];

			main.Invoke((MethodInvoker)delegate
			{
				main.Show();
			});

			toolBox.Invoke((MethodInvoker)delegate
			{
				toolBox.Close();
			});
		}

		private void startGameCustom(object data)
		{
			List<object> list = (List<object>)data;
			int width = (int)list[0];
			int height = (int)list[1];
			int cellSize = (int)list[2];
			uint delay = (uint)list[3];
			string rules = (string)list[4];
			bool wrap = (bool)list[5];
			bool[,] grid = (bool[,])list[6];
			int tabSelect = (int)list[7];
			int glSelect = (int)list[8];
			int hlSelect = (int)list[9];

			GameOfLife game = new GameOfLife(width, height, cellSize, delay, rules, wrap, grid);
			game.start();

			MainWindow main = (MainWindow)list[10];

			main.Invoke((MethodInvoker)delegate
			{
				main.Show();
			});

			toolBox.Invoke((MethodInvoker)delegate
			{
				toolBox.Close();
			});
		}

		private void glComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = glComboBox.SelectedIndex;
			hlComboBox.SelectedIndex = -1;
			glComboBox.SelectedIndex = index;
		}

		private void hlComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = hlComboBox.SelectedIndex;
			glComboBox.SelectedIndex = -1;
			hlComboBox.SelectedIndex = index;
		}

		private void loadFileButton_Click(object sender, EventArgs e)
		{
			DialogResult result = loadFileDialog.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.Cancel) return;

			this.Hide();

			StreamReader file = new StreamReader(loadFileDialog.FileName);

			string rules = file.ReadLine();
			int width = Convert.ToInt32(file.ReadLine());
			int height = Convert.ToInt32(file.ReadLine());
			int cellSize = Convert.ToInt32(file.ReadLine());
			this.cellSize = cellSize;
			uint delay = 75;// Convert.ToUInt32(delayTextBox.Text);
			bool wrap = false;// wrapCheckBox.Checked;
			bool[,] grid = new bool[width, height];
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					grid[x, y] = false;
				}
			}

			while (!file.EndOfStream)
			{
				string line = file.ReadLine();
				string[] coords = line.Split(' ');
				int x = Convert.ToInt32(coords[0]);
				int y = Convert.ToInt32(coords[1]);
				grid[x, y] = true;
			}

			file.Close();

			toolBox = new ToolBoxWindow();
			toolBox.parent = this;

			List<object> list = new List<object>();
			list.Add(width);
			list.Add(height);
			list.Add(cellSize);
			list.Add(delay);
			list.Add(rules);
			list.Add(wrap);
			list.Add(grid);
			list.Add(tabControl.SelectedIndex);
			list.Add(glComboBox.SelectedIndex);
			list.Add(hlComboBox.SelectedIndex);
			list.Add(this);

			custom = true;

			Thread thread = new Thread(startGameCustom);

			thread.Start(list);
			toolBox.Show();
		}
    }
}