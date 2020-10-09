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
    public partial class MatExchangeGUI : Form
    {
        private FormState _state;
        private List<EIndexEntry> index;
        private EIndexEntry sel_e; // selected enemy
        private Loot sel_l; // loot
        private int required;
        private WishlistGUI wgui;
        private List<RadioButton> rbuttons;
        public MatExchangeGUI(FormState state)
        {
            _state = state;
            rbuttons = new List<RadioButton>();
            index = state.Player.EnemyIndex.Select(kvp => kvp.Value).ToList();
            index = index.FindAll(eie => !eie.Name.Contains("Pot of"));
            InitializeComponent();
        }

        private void MatExchangeGUI_Load(object sender, EventArgs e)
        {
            var loot = _state.Player.Loot.EnemyLoot;
            loot.Sort((a, b) => a.Name.CompareTo(b.Name));

            allMats.DataSource = _state.Player.Loot.EnemyLoot;
            enemyList.DataSource = index;
            matType.SelectedIndex = 0;

            rbuttons.Add(energyButton);
            rbuttons.Add(shardButton);
            rbuttons.Add(scaleButton);
            rbuttons.Add(mantleButton);
            rbuttons.Add(crystalButton);
        }

        private void enemySearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = enemySearch.Text;
                query = query[0].ToString().ToUpper() + query.Substring(1);
                var search = index.FindAll(q => q.Name.StartsWith(query));
                enemyList.DataSource = search;
            }
            catch (IndexOutOfRangeException)
            {
                if(enemySearch.Text == "")
                {
                    enemyList.DataSource = index;
                }
            }

        }

        private void allMats_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sel_l = allMats.SelectedItem as Loot;
                DisplaySelectedEnemyIndex();
            }
            catch (NullReferenceException) { }
        }

        private void enemyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sel_e = enemyList.SelectedItem as EIndexEntry;
                pic.ImageLocation = sel_e.Image;
                DisplaySelectedEnemyIndex();
            }
            catch (NullReferenceException) { }
        }

        private void DisplaySelectedEnemyIndex()
        {
            try
            {
                int m = (sel_e.IsBoss) ? 10 : 5; // multiplier to required mats

                required = (matType.SelectedIndex + 1) * m;
                required *= (int)quantity.Value;
                required *= IsSpecialMob(sel_e.Name, "EX", 15); // add 15 to quantity if EX
                required *= IsSpecialMob(sel_e.Name, "ASC", 25); // add 25 to quantity of ASC

                int subtract = sel_l.Rarity;
                subtract *= IsSpecialMob(sel_e.Name, "EX", 3);
                subtract *= IsSpecialMob(sel_e.Name, "ASC", 5);

                required /= subtract;
                reqInfo.Text = $"COST: {sel_l.GetName()} x{required}";
                resultBox.Text = $"RESULT: {sel_e.Name} {matType.SelectedItem} x{(int)quantity.Value}";
            }
            catch (NullReferenceException) { }
        }

        private int IsSpecialMob(string name, string condition, int value) => (name.Contains(condition)) ? value : 1;

        private void MatExchangeGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.EXCHANGE)
                _state.Type = FTypes.CLOSE;
            _state.Save.SaveGame(_state.Player);
        }

        private void matType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedEnemyIndex();
        }

        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            DisplaySelectedEnemyIndex();
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _state.Type = FTypes.MOVE;
            _state.Location = Location;
            if (wgui != null && wgui.Visible)
                wgui.Close();
            Close();
        }

        private void wishlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(wgui == null || !wgui.Visible)
            {
                wgui = new WishlistGUI(_state);
                wgui.StartPosition = FormStartPosition.Manual;
                wgui.Location = Location;
                wgui.Show();
            }
        }

        private void convertButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (required <= sel_l.Quantity)
            {
                var loot = _state.Player.Loot.EnemyLoot;

                var mat = loot.Find(l => l.GetName().Equals(sel_l.GetName()));

                mat.Quantity -= required;

                if (mat.Quantity <= 0)
                    loot.Remove(mat);

                string suffix = matType.SelectedItem.ToString();
                string query = $"{sel_e.Name} {suffix}";
                var duplicate = loot.Find(l => l.GetName().Equals(query));

                if(duplicate == null)
                {
                    var n = new Loot()
                    {
                        Name = sel_e.Name,
                        Suffix = suffix,
                        LType = LootType.ENEMY_DROP,
                        Quantity = (int)quantity.Value,
                        Rarity = matType.SelectedIndex + 1,
                        Tier = 1
                    };
                    loot.Add(n);
                }
                else
                {
                    duplicate.Quantity += (int)quantity.Value;
                }

                RefreshLists();

                if (wgui != null && wgui.Visible)
                    wgui.RefreshList();

                DisplaySelectedEnemyIndex();
            }
            else
            {
                MessageBox.Show("Not enough mats for this conversion.");
            }
        }

        private void RefreshLists()
        {
            string old_enemy = enemySearch.Text;

            int old_index = allMats.SelectedIndex;
            int old_index_e = enemyList.SelectedIndex;

            allMats.DataSource = null;

            for(int i = 0; i < rbuttons.Count; i++)
                if(rbuttons[i].Checked)
                    allMats.DataSource = _state.Player.Loot.FilterLoot(i+1);

            if(allButton.Checked)
                allMats.DataSource = _state.Player.Loot.EnemyLoot;

            enemyList.DataSource = null;
            enemyList.DataSource = index;
            enemySearch.Clear();
            enemySearch.Text = old_enemy;
            enemyList.SelectedIndex = old_index_e;
  
        }

        private void energyButton_CheckedChanged(object sender, EventArgs e)
        {
            if (energyButton.Checked)
                allMats.DataSource = _state.Player.Loot.FilterLoot(1);
        }

        private void shardButton_CheckedChanged(object sender, EventArgs e)
        {
            if (shardButton.Checked)
                allMats.DataSource = _state.Player.Loot.FilterLoot(2);
        }

        private void scaleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (scaleButton.Checked)
                allMats.DataSource = _state.Player.Loot.FilterLoot(3);
        }

        private void mantleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (mantleButton.Checked)
                allMats.DataSource = _state.Player.Loot.FilterLoot(4);
        }

        private void crystalButton_CheckedChanged(object sender, EventArgs e)
        {
            if (crystalButton.Checked)
                allMats.DataSource = _state.Player.Loot.FilterLoot(5);
        }

        private void allButton_CheckedChanged(object sender, EventArgs e)
        {
            if(allButton.Checked)
                allMats.DataSource = _state.Player.Loot.EnemyLoot;
        }
    }
}
