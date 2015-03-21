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
	public partial class SelectStructureDialog : Form
	{
		public SelectStructureDialog()
		{
			InitializeComponent();

			spaceShipListBox.SelectedIndex = 0;
			oscillatorListBox.SelectedIndex = 0;
			stillLifeListBox.SelectedIndex = 0;
		}
	}
}
