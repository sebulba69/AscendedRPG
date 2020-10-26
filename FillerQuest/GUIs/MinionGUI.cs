using AscendedRPG.Files;
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
    public partial class MinionGUI : Form
    {
        private FormState _state;
        private MinionManager mm;

        public MinionGUI(FormState state)
        {
            _state = state;
            mm = new MinionManager(state.Random);
            InitializeComponent();
        }

        private void MinionGUI_Load(object sender, EventArgs e)
        {
            var minions = _state.Player.Minions;

            msCount.Text = $"{_state.Player.Wallet.MinionShards} MS";

            if(minions.Count > 0)
            {
                minionBox.DataSource = minions;
                minionBox.SelectedIndex = 0;
            }
        }

        private void minionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selected = minionBox.SelectedItem as Enemies.Minion;
                mpicBox.ImageLocation = selected.Image;
                minionName.Text = selected.NameString();
                minionWeapon.Text = selected.Weapon.ToString();
                minionSkills.Clear();
                for(int i = 0; i < selected.Skills.Count-1;i++)
                {
                    minionSkills.AppendText(selected.Skills[i].ToString());
                    minionSkills.AppendText(Environment.NewLine);
                }

                minionSkills.AppendText(selected.Skills.Last().ToString());
                equipButton.Text = (selected.IsEquipped)? "Unequip" : "Equip";
            }
            catch (NullReferenceException)
            {
                mpicBox.ImageLocation = null;
                minionName.Clear();
                minionWeapon.Clear();
                minionSkills.Clear();
            }
        }

        private void create_MouseClick(object sender, MouseEventArgs e)
        {
            var wallet = _state.Player.Wallet;
            if (wallet.MinionShards >= 10)
            {
                if(_state.Player.Minions.Count == 5)
                {
                    MessageBox.Show("You don't have enough space for a new minion.");
                }
                else
                {
                    _state.Player.Minions.Add(mm.MakeMinion());
                    wallet.MinionShards -= 10;
                    ResetMBox();
                    _state.Save.SaveGame(_state.Player);
                }
            }
            else
            {
                MessageBox.Show("You don't have enough shards to summon this minion.");
            }
        }

        private void boostButton_MouseClick(object sender, MouseEventArgs e)
        {
            var wallet = _state.Player.Wallet;
            if (wallet.MinionShards >= 100)
            {
                var selected = minionBox.SelectedItem as Enemies.Minion;
                if(selected.Level + 1 > 100)
                {
                    MessageBox.Show("Your minion is currently max level. You'll need to ascend your minion using the Ascended Bucey God Form button to reset it.");
                }
                else
                {
                    selected.ForcedLevelUp();
                    wallet.MinionShards -= 100;
                    ResetMBox();
                    _state.Save.SaveGame(_state.Player);
                }

            }
            else
            {
                MessageBox.Show("You don't have enough shards to boost this minion.");
            }
        }

        private void godFormButton_MouseClick(object sender, MouseEventArgs e)
        {
            var wallet = _state.Player.Wallet;
            if (wallet.MinionShards >= 1000)
            {
                var selected = minionBox.SelectedItem as Enemies.Minion;
                if (selected.Level < 100)
                {
                    MessageBox.Show("Your minion must be max level to properly Ascended Bucey Godform it.");
                }
                else
                {
                    selected.GodForm();
                    wallet.MinionShards -= 1000;
                    ResetMBox();
                    _state.Save.SaveGame(_state.Player);
                }

            }
            else
            {
                MessageBox.Show("You don't have enough shards to boost this minion.");
            }
        }

        private void delete_MouseClick(object sender, MouseEventArgs e)
        {
            if(_state.Player.Minions.Count >= 0)
            {
                var selected = minionBox.SelectedItem as Enemies.Minion;
                _state.Player.Minions.Remove(selected);
                ResetMBox();
                _state.Save.SaveGame(_state.Player);
            }
        }

        private void equipButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (_state.Player.Minions.Count >= 0)
            {
                var selected = minionBox.SelectedItem as Enemies.Minion;

                var all = _state.Player.Minions.FindAll(m => m.IsEquipped);

                if (all != null && all.Count == 2 && equipButton.Text.Contains("Equip"))
                {
                    MessageBox.Show("You can only equip 2 minions at a time.");
                }
                else
                {
                    selected.IsEquipped = equipButton.Text.Contains("Equip");
                    ResetMBox();
                    _state.Save.SaveGame(_state.Player);
                }
            }
        }

        private void ResetMBox()
        {
            minionBox.DataSource = null;
            minionBox.DataSource = _state.Player.Minions;
            msCount.Text = $"{_state.Player.Wallet.MinionShards} MS";
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _state.Location = Location;
            _state.Type = FTypes.MOVE;
            Close();
        }

        private void MinionGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.MINIONS)
                _state.Type = FTypes.CLOSE;
        }
    }
}
