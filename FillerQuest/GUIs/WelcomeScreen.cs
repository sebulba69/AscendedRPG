using AscendedRPG.Files;
using AscendedRPG.GUIs;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class WelcomeScreen : Form
    {
        private FormState _state;

        public WelcomeScreen(FormState state)
        {
            _state = state;
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGameGroup.Enabled = true;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeState(FTypes.LOAD_SCREEN);
            Close();
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            if(nameBox.Text == string.Empty)
            {
                MessageBox.Show("You need to enter a name first.");
            }
            else
            {
                if (_state.Save.DoesSaveFileExist(nameBox.Text))
                {
                    var result = MessageBox.Show("A save file with this name already exists. Continuing on will overwrite it.", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        CreateNewPlayer();
                }
                else
                {
                    CreateNewPlayer();
                }
                ChangeState(FTypes.CHARACTER_SELECT);
                Close();
            }
        }

        private void CreateNewPlayer()
        {
            _state.Player = new Player();
            _state.Player.Name = nameBox.Text;
            _state.Player.Tiers = new List<int>(7);

            _state.Player.Wallet = new AscendedRPG.Wallet()
            {
                Coins = 1000,
                Keys = new List<int>(7)
            };

            for (int i = 0; i < 7; i++)
            {
                _state.Player.Wallet.Keys.Add(0);
                _state.Player.Tiers.Add(1);
            }
                
        }

        private void ChangeState(FTypes ftype)
        {
            _state.Location = Location;
            _state.Type = ftype;
        }

        private void WelcomeScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.WELCOME_SCREEN)
                _state.Type = FTypes.CLOSE;
        }
    }
}
