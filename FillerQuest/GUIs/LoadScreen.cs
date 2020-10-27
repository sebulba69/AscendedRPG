using AscendedRPG.Enemies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class LoadScreen : Form
    {
        private FormState _state;
        public LoadScreen(FormState state)
        {
            _state = state;
            InitializeComponent();
        }

        private void LoadScreen_Load(object sender, EventArgs e)
        {
            var names = _state.Save.GetFileNames();
            if (names.Count <= 0)
            {
                MessageBox.Show("Unable to detect files. Returning to Welcome Screen.");
                _state.Type = FTypes.WELCOME_SCREEN;
                Close();
            }
            else
            {
                loadPaths.DataSource = names;
            }
        }

        private void loadButton_MouseClick(object sender, MouseEventArgs e)
        {
            var selected = loadPaths.SelectedItem.ToString();
            _state.Player = _state.Save.LoadGame(selected);
            _state.Type = FTypes.INVENTORY;
            Close();
        }

        private void LoadScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.LOAD_SCREEN)
                _state.Type = FTypes.CLOSE;
        }
    }
}
