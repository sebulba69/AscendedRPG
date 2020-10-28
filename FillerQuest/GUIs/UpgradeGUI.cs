using AscendedRPG.LootClasses;
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
    public partial class UpgradeGUI : Form
    {
        private FormState _state;

        public UpgradeGUI(FormState state)
        {
            _state = state;
            InitializeComponent();
        }

        private void UpgradeGUI_Load(object sender, EventArgs e)
        {
            var player = _state.Player;
            player.Loot.EnemyLoot.Sort((a, b) => a.Name.CompareTo(b.Name));
            lootList.DataSource = player.Loot.EnemyLoot;
            equipBox.DataSource = player.Set.Armor;
        }

        private void lootList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = lootList.SelectedItem as Loot;
            if(selected != null)
            {
                materialBox.Text = selected.ToString();
                lootQuantity.Maximum = selected.Quantity;
                lootQuantity.Value = selected.Quantity;
                SetTotalValue(selected);
            }
        }

        private void equipBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var armor = equipBox.SelectedItem as AscendedRPG.Armor;
            if (armor != null)
            {
                skillDisplay.DataSource = null;
                skillDisplay.DataSource = armor.Skills;

                int req = GetRequiredXP(armor.UpgradeLevel, armor.Defense);
                xpBar.Maximum = req;
                xpBar.Value = armor.UpXP;
                reqXP.Text = $"{armor.UpXP}/{req} XP";
            }

        }

        private void LevelArmor(AscendedRPG.Armor armor)
        {
            int r = GetRequiredXP(armor.UpgradeLevel, armor.Defense);

            // if we have more XP than needed to level up, reduce until we don't
            if(armor.UpXP >= r)
            {
                armor.UpXP -= r;
                armor.LevelUp();
                LevelArmor(armor);
                _state.Player.Set.CalculateTotalDef();
            }
            else
            {
                // update displays
                lootList.DataSource = null;
                lootList.DataSource = _state.Player.Loot.EnemyLoot;
                equipBox.DataSource = null;
                equipBox.DataSource = _state.Player.Set.Armor;
                

                // reset xp bars
                xpBar.Maximum = GetRequiredXP(armor.UpgradeLevel, armor.Defense);
                xpBar.Value = armor.UpXP;
            }
        }

        // bs armor formula that scales with level ups
        private int GetRequiredXP(int level, int def)
        {
            int x = (level* 12) + (def * 5);
            return (x * (int)Math.Log(x)) + x + (level + 5);
        }

        private void UpgradeGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.UPGRADE_SKILLS)
                _state.Type = FTypes.CLOSE;
            
            _state.Save.SaveGame(_state.Player);
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _state.Type = FTypes.MOVE;
            _state.Location = Location;
            Close();
        }

        private void lootQuantity_ValueChanged(object sender, EventArgs e)
        {

            var material = lootList.SelectedItem as Loot;

            if(material != null)
                SetTotalValue(material);
        }

        private void SetTotalValue(Loot material)
        {
            int initXPAmount = (material.Rarity * 2) + 5;

            if (material.Name.Contains("EX"))
                initXPAmount *= 2;

            if (material.Name.Contains("ASC"))
                initXPAmount *= 3;

            totalValue.Text = $"{initXPAmount * (int)lootQuantity.Value} XP";
        }

        private void boostButton_Click(object sender, EventArgs e)
        {
            BoostArmor();
        }

        private void boostButton_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                BoostArmor();
            }
            catch (NullReferenceException) { }
        }

        private void BoostArmor()
        {
            int quantity = (int)lootQuantity.Value;

            var material = lootList.SelectedItem as Loot;
            var armor = equipBox.SelectedItem as AscendedRPG.Armor;

            if (material != null && armor != null)
            {
                material.Quantity -= quantity;

                if (material.Quantity <= 0)
                    _state.Player.Loot.EnemyLoot.Remove(material);

                int initXPAmount = ((material.Rarity * 2) + 5);

                if (material.Name.Contains("EX"))
                    initXPAmount *= 2;

                if (material.Name.Contains("ASC"))
                    initXPAmount *= 3;

                armor.UpXP += (initXPAmount * quantity);

                LevelArmor(armor);
            }
            else
            {
                ResetAll();
            }
                
        }

        private void ResetAll()
        {
            lootQuantity.Value = 0;
            lootQuantity.Maximum = 0;
            materialBox.Clear();
            totalValue.Clear();
        }
    }
}
