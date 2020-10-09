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
    public partial class WishlistGUI : Form
    {
        private FormState _state;

        public WishlistGUI(FormState state)
        {
            _state = state;
            InitializeComponent();
        }

        private void WishlistGUI_Load(object sender, EventArgs e)
        {
            recipeList.DataSource = _state.Player.Loot.Wishlist;
        }

        private void recipeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selected = recipeList.SelectedItem as Recipes.Recipe;
                resultBox.Text = selected.Result.ToString();
                skillBox.DataSource = selected.Result.Skills;
                recipeIngredients.Items.Clear();
                foreach(Recipes.Ingredient i in selected.Ingredients)
                {
                    var l = _state.Player.Loot.EnemyLoot.Find(loot => loot.GetName().Equals(i.GetName()));
                    if (l == null)
                        recipeIngredients.Items.Add(i.DisplayString(0));
                    else
                        recipeIngredients.Items.Add(i.DisplayString(l.Quantity));
                }
            }
            catch (NullReferenceException) {}
        }

        private void deleteRecipe_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                var selected = recipeList.SelectedItem as Recipes.Recipe;
                RemoveRecipeFromList(selected);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You don't have any recipes to delete.");
            }
        }

        private void RemoveRecipeFromList(Recipes.Recipe selected)
        {
            _state.Player.Loot.Wishlist.Remove(selected);
            RefreshList();
        }

        public void RefreshList()
        {
            recipeList.DataSource = null;
            recipeList.DataSource = _state.Player.Loot.Wishlist;
            if (_state.Player.Loot.Wishlist.Count == 0)
            {
                recipeIngredients.Items.Clear();
                skillBox.DataSource = null;
                resultBox.Clear();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpGUI help = new HelpGUI();
            help.StartPosition = FormStartPosition.Manual;
            help.Location = Location;
            help.ShowDialog();
        }

        private void enemyIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnemyIndexGUI eigui = new EnemyIndexGUI(_state.Player.EnemyIndex);
            eigui.StartPosition = FormStartPosition.Manual;
            eigui.Location = Location;
            eigui.ShowDialog();
        }


    }
}
