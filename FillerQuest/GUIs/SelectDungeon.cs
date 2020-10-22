using AscendedRPG.Files;
using AscendedRPG;
using AscendedRPG.Enemies;
using AscendedRPG.GUIs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG
{
    public partial class SelectDungeon : Form
    {
        private FormState _state;
        private bool _isDungeonClose;

        public SelectDungeon(FormState state)
        {
            _state = state;
            _isDungeonClose = false;
            InitializeComponent();
        }

        private void SelectDungeon_Load(object sender, EventArgs e)
        {
            normalButton.Checked = true;
        }

        private void TierBox_ValueChanged(object sender, EventArgs e)
        {
            int t = (int)TierBox.Value;

            if(t < 1)
            {
                TierBox.Value = 1;
            }
        }

        private void SelectDungeon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.SELECT_DUNGEON || !_isDungeonClose)
                _state.Type = FTypes.CLOSE;
        }

        private void GoBack_MouseClick(object sender, MouseEventArgs e)
        {
            _state.Type = FTypes.INVENTORY;
            _state.Location = Location;
            _isDungeonClose = true;
            Close();
        }

        private void EmbarkButton_MouseClick(object sender, MouseEventArgs e)
        {
            int d = (int)TierBox.Value;

            // if bcheck is checked --> state = dungeon boss, else if d % 10 == 0, then dungeon boss, else dungoen gui
            _state.Type = (bountyCheckbox.Checked) ?
                FTypes.DUNGEON_BOSS :
                    (d % 10 == 0) ?
                        FTypes.DUNGEON_BOSS : 
                        FTypes.DUNGEON_GUI;

            Embark(d);
        }

        private void recentTier_MouseClick(object sender, MouseEventArgs e)
        {
            string text = recentTier.Text.Split(' ')[1];
            int d = Int32.Parse(text);

            _state.Type = (bountyCheckbox.Checked) ?
                FTypes.DUNGEON_BOSS :
                    (d % 10 == 0) ?
                        FTypes.DUNGEON_BOSS :
                        FTypes.DUNGEON_GUI;

            Embark(d);
        }

        private void Embark(int t)
        {
            if (_state.DungeonType != DungeonType.NORMAL)
            {
                var keys = _state.Player.Wallet.Keys;
                if (keys[_state.DungeonType] - 1 < 0)
                {
                    MessageBox.Show("You don't have enough keys to enter this dungeon.");
                }
                else
                {
                    keys[_state.DungeonType]--;
                    Depart(t);
                }
            }
            else
            {
                // your normal tier caps at this point
                if (t == 500 && _state.Player.HasSeenNotCutscene)
                {
                    _state.Player.HasSeenNotCutscene = false;
                    MessageBox.Show("Before you enter the dungeon, you see a message inscribed on the wall nearby. " +
                    "\"Beyond this door awaits your final challenge. Once you conquer this, you will truly ascend. Good luck.\"");
                }
                Depart(t);
            }
        }

        private void Depart(int t)
        {
            _state.Music.Stop();

            _state.Location = Location;

            _state.dungeonTiers[_state.DungeonType] = t;

            _isDungeonClose = true;

            Close();
        }

        private void normalButton_CheckedChanged(object sender, EventArgs e)
        {
            BountyCheck(DungeonType.BOUNTY, DungeonType.NORMAL);
        }

        private void exButton_CheckedChanged(object sender, EventArgs e)
        {
            BountyCheck(DungeonType.EXBOUNTY, DungeonType.EX);
        }

        private void ascButton_CheckedChanged(object sender, EventArgs e)
        {
            BountyCheck(DungeonType.ASCBOUNTY, DungeonType.ASCENDED);
        }

        private void elderButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bountyCheckbox.Checked)
                bountyCheckbox.Checked = false;

            int type = DungeonType.ELDER;

            _state.DungeonType = type;
            int tier = _state.Player.Tiers[type];
            int dtier = _state.dungeonTiers[type];

            SetTierValues(tier, dtier, _state.Player.Wallet.Keys[type]);
        }


        private void BountyCheck(int bt, int dt)
        {
            if (bountyCheckbox.Checked)
                _state.DungeonType = bt;
            else
                _state.DungeonType = dt;

            SetTierValues(_state.Player.Tiers[_state.DungeonType],
                _state.dungeonTiers[_state.DungeonType],
                _state.Player.Wallet.Keys[_state.DungeonType]);
        }

        private void SetTierValues(int t_player, int d_tier, int count)
        {
            TierBox.Maximum = t_player;
            TierBox.Value = t_player;
            recentTier.Text = $"Re-embark: {d_tier}";
            string keys = (count == 1) ? "key" : "keys";
            keyBox.Text = $"{count} {keys}";
        }

        private void ResetBountyBox()
        {
            MessageBox.Show("You don't have any keys to embark into this dungeon!");
            bountyCheckbox.Checked = false;
            normalButton.Checked = true;
        }

        private void bountyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton check;

            if (normalButton.Checked)
                check = normalButton;
            else if (exButton.Checked)
                check = exButton;
            else if (ascButton.Checked)
                check = ascButton;
            else
                check = elderButton;

            // refresh the display
            for (int i = 0; i < 2; i++)
                check.Checked = !check.Checked;
        }
    }
}
