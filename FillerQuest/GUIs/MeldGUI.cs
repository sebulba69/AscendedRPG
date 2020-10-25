using AscendedRPG.GUIs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AscendedRPG
{
    public partial class MeldGUI : Form
    {
        private FormState _state;

        public MeldGUI(FormState state)
        {
            _state = state;
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            UpdateAllScreens();
        }

        private void UpdateAllScreens()
        {
            InventoryList.Items.Clear();
            InventoryList.Items.Add($"~ Inventory ({_state.Player.Inventory.Inventory.Count}/100)~");
            InventoryList.Items.AddRange(_state.Player.Inventory.Inventory.ToArray());

            SelectedInventorySkill.Clear();

            skillDisplay.Clear();
            var elementals = _state.Player.ElementalAttack;

            for (int i = 0; i < elementals.Count - 1; i++)
            {
                skillDisplay.AppendText($"{_state.SManager.ElementToString(i)} +{elementals[i]}");
                skillDisplay.AppendText(Environment.NewLine);
            }
            skillDisplay.AppendText($"{_state.SManager.ElementToString(elementals.Count - 1)} +{elementals.Last()}");

            if (_state.Player.Inventory.Inventory.Count > 0)
                InventoryList.SelectedIndex = 1;
        }

        private void UpdateInventoryList(Armor[] array)
        {
            InventoryList.Items.Clear();
            InventoryList.Items.Add($"~ Inventory ({_state.Player.Inventory.Inventory.Count}/100)~");
            InventoryList.Items.AddRange(array);
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
            {
                if(InventoryList.Items.Count > 1)
                    InventoryList.SelectedIndex = 1;
            }
        }

        private void MeldButton_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var inventory = _state.Player.Inventory.Inventory;
                var armor = inventory[InventoryList.SelectedIndex - 1];
                armor.Skills.ForEach(s =>
                {
                    var skill = s.Skill;
                    if (skill.S_Type == SkillType.OFFENSIVE)
                        _state.Player.ElementalAttack[skill.Element] += skill.Multiplier;
                });
                inventory.Remove(armor);
                _state.Save.SaveGame(_state.Player);
                UpdateAllScreens();
            }
            catch (NullReferenceException) { }
            catch (ArgumentOutOfRangeException)
            {
                if (InventoryList.Items.Count > 1)
                    InventoryList.SelectedIndex = 1;
            }
        }

        private void UnfilterButton_MouseClick(object sender, MouseEventArgs e)
        {
            UncheckRadioBoxes();
            UpdateInventoryList(_state.Player.Inventory.Inventory.ToArray());
        }


        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _state.Location = Location;
            _state.Type = FTypes.SHOP_ROOM;
            Close();
        }

        #endregion

        private void moveToolStripItem(object sender, EventArgs e)
        {
            _state.Type = FTypes.MOVE;
            _state.Location = Location;
            Close();
        }

        private void Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.MELD)
                _state.Type = FTypes.CLOSE;
        }
    }
}
