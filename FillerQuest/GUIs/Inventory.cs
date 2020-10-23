using AscendedRPG.GUIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AscendedRPG
{
    public partial class Inventory : Form
    {
        private FormState _state;

        public Inventory(FormState state)
        {
            _state = state;
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            var player = _state.Player;
            PlayerPic.ImageLocation = player.Picture;
            TierBox.Text = $"Tier {player.Tiers[0]}";

            UpdateAllScreens();

            CoinBox.Text = $"{player.Wallet.Coins} D$ - {player.Wallet.MinionShards} MS";
            WeaponBox.Text = player.Weapon.ToString();
            WeaponStyles.SelectedIndex = player.Weapon.Style;

            NumActiveElements();

            if (!_state.Music.IsPlaying())
            {
                _state.Music.SetIdleTheme(player.Tiers[0]);
                _state.Music.PlayIdleSong();
            }
        }

        private void UpdateAllScreens()
        {
            DefenseBox.Text = $"{_state.Player.GetHP() + _state.Player.Set.TotalDef} HP";

            ActiveSkillBox.Items.Clear();
            ActiveSkillBox.Items.Add("~ Active Skills ~");
            var skills = _state.Player.Set.Skills;
            skills.Sort((a, b) => a.Skill.Damage.CompareTo(b.Skill.Damage));
            skills.Reverse();
            ActiveSkillBox.Items.AddRange(skills.ToArray());

            EquipmentBox.Items.Clear();
            EquipmentBox.Items.Add("~ Equipped Armor ~");
            EquipmentBox.Items.AddRange(_state.Player.Set.Armor.ToArray());

            InventoryList.Items.Clear();
            InventoryList.Items.Add($"~ Inventory ({_state.Player.Inventory.Inventory.Count}/100)~");
            InventoryList.Items.AddRange(_state.Player.Inventory.Inventory.ToArray());

            NumActiveElements();
        }

        private void UpdateInventoryList(Armor[] array)
        {
            InventoryList.Items.Clear();
            InventoryList.Items.Add($"~ Inventory ({_state.Player.Inventory.Inventory.Count}/100)~");
            InventoryList.Items.AddRange(array);
        }

        private void EquipmentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectedArmorSkill.Clear();
                int index = EquipmentBox.SelectedIndex;
                var item = _state.Player.Set.Armor[index - 1];
                SelectedArmorSkill.AppendText(item.Name);
                SelectedArmorSkill.AppendText(Environment.NewLine);
                string skills = item.PrintSkills();
                var split = skills.Split('|');
                SelectedArmorSkill.AppendText(split[0]);
                if (split.Length > 1)
                {
                    SelectedArmorSkill.AppendText(Environment.NewLine);
                    SelectedArmorSkill.AppendText(split[1]);
                }
            }
            catch (ArgumentOutOfRangeException) { }

        }

        private void ActiveSkillBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = ActiveSkillBox.SelectedIndex - 1;
                var aSkill = _state.Player.Set.Skills[index];
                var selected = aSkill.Skill;
                SkillDisplayBox.Clear();
                switch (selected.S_Type)
                {
                    case SkillType.OFFENSIVE:
                        UpdateMLTB(SkillDisplayBox, selected.Name);
                        UpdateMLTB(SkillDisplayBox, $"{selected.GetDamage()} Damage");
                        SkillDisplayBox.AppendText($"Element: {_state.SManager.ElementToString(selected.Element)}");
                        break;
                    case SkillType.PASSIVE_BUFF:
                        UpdateMLTB(SkillDisplayBox, selected.Name);
                        SkillDisplayBox.AppendText($"Boosts {_state.SManager.StatsToString(selected.Stat)} by {selected.Multiplier}");
                        break;
                    case SkillType.PASSIVE_VOID:
                        UpdateMLTB(SkillDisplayBox, selected.Name);
                        SkillDisplayBox.AppendText($"Reduces {_state.SManager.ElementToString(selected.Element)} dmg by {selected.Multiplier}");
                        break;
                }
            }
            catch (NullReferenceException) { }
            catch (ArgumentOutOfRangeException) { }
        }

        // update multi line textbox
        private void UpdateMLTB(TextBox tb, string msg)
        {
            tb.AppendText(msg);
            tb.AppendText(Environment.NewLine);
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game saved.");
            _state.Save.SaveGame(_state.Player);
        }

        private void EmbarkMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to embark?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _state.Location = Location;
                _state.Type = FTypes.SELECT_DUNGEON;
                Close();
            }
        }

        private void NumActiveElements()
        {
            int[] elements = new int[9];
            var skills = _state.Player.Set.Skills;
            skills.ForEach(s => 
            {
                if(s.Skill.S_Type == SkillType.OFFENSIVE)
                    elements[s.Skill.Element]++;
            });

            int actives = 0;
            foreach (int e in elements)
                if (e > 0)
                    actives++;

            activeElements.Text = $"{actives}/9 Elements Equipped";
        }

        #region inventory management

        private void head_CheckedChanged(object sender, EventArgs e)
        {
            if(head.Checked)
            {
                FilterPieces(ArmorPiece.HEAD);
            }
        }

        private void torso_CheckedChanged(object sender, EventArgs e)
        {
            if (torso.Checked)
            {
                FilterPieces(ArmorPiece.TORSO);
            }
        }

        private void arms_CheckedChanged(object sender, EventArgs e)
        {
            if (arms.Checked)
            {
                FilterPieces(ArmorPiece.ARMS);
            }
        }

        private void waist_CheckedChanged(object sender, EventArgs e)
        {
            if (waist.Checked)
            {
                FilterPieces(ArmorPiece.WAIST);
            }
        }

        private void legs_CheckedChanged(object sender, EventArgs e)
        {
            if (legs.Checked)
            {
                FilterPieces(ArmorPiece.LEGS);
            }
        }

        private void charms_CheckedChanged(object sender, EventArgs e)
        {
            if (charms.Checked)
            {
                FilterPieces(ArmorPiece.CHARM);
            }
        }

        private void FilterPieces(int piece)
        {
            var inv = _state.Player.Inventory.Inventory;
            var armor = inv.FindAll(a => a.Piece == piece);
            UpdateInventoryList(armor.ToArray());
        }

        private void UncheckRadioBoxes()
        {
            head.Checked = false;
            torso.Checked = false;
            arms.Checked = false;
            waist.Checked = false;
            legs.Checked = false;
            charms.Checked = false;
        }

        private void EquipButton_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var inventory = _state.Player.Inventory.Inventory;
                var armor = inventory[InventoryList.SelectedIndex - 1];
                _state.Player.Set.ExchangeArmor(_state.Player.Inventory, armor);
                UpdateAllScreens();
            }
            catch (NullReferenceException) { }
            catch (ArgumentOutOfRangeException)
            {
                InventoryList.SelectedIndex = 1;
            }
        }

        private void InventoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var inventory = _state.Player.Inventory.Inventory;
                var armor = inventory[InventoryList.SelectedIndex - 1];
                SelectedInventorySkill.Clear();
                var skills = armor.PrintSkills().Split('|');
                for(int i = 0; i < skills.Length - 1; i++)
                {
                    SelectedInventorySkill.AppendText(skills[i]);
                    SelectedInventorySkill.AppendText(Environment.NewLine);
                }
                SelectedInventorySkill.AppendText(skills.Last());
            }
            catch (NullReferenceException) { }
            catch (ArgumentOutOfRangeException)
            { }
        }

        private void DeleteSelectedInventory_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var inventory = _state.Player.Inventory.Inventory;
                if(inventory.Count > 0)
                {
                    inventory.RemoveAt(InventoryList.SelectedIndex - 1);
                    UpdateAllScreens();
                }
                else
                {
                    MessageBox.Show("You have nothing in your inventory to delete.");
                }
            }
            catch (NullReferenceException) { }
            catch (ArgumentOutOfRangeException)
            {
                InventoryList.SelectedIndex = 1;
            }
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _state.Location = Location;
            _state.Type = FTypes.SHOP_ROOM;
            Close();
        }

        private void UnfilterButton_MouseClick(object sender, MouseEventArgs e)
        {
            UncheckRadioBoxes();
            UpdateInventoryList(_state.Player.Inventory.Inventory.ToArray());
        }

        #endregion

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpGUI help = new HelpGUI();
            help.StartPosition = FormStartPosition.Manual;
            help.Location = Location;
            help.ShowDialog();
        }

        private void craftArmorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _state.Type = FTypes.MOVE;
            _state.Location = Location;
            Close();
        }

        private void Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.INVENTORY)
                _state.Type = FTypes.CLOSE;
        }

        private void enemyIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnemyIndexGUI eigui = new EnemyIndexGUI(_state.Player.EnemyIndex);
            eigui.StartPosition = FormStartPosition.Manual;
            eigui.Location = Location;
            eigui.ShowDialog();
        }

        private void checkWishlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WishlistGUI wgui = new WishlistGUI(_state);
            wgui.StartPosition = FormStartPosition.Manual;
            wgui.Location = Location;
            wgui.ShowDialog();
        }

        private void WeaponStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            _state.Player.Weapon.Style = WeaponStyles.SelectedIndex;
        }
    }
}
