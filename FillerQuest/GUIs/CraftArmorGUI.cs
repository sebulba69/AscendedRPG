using AscendedRPG;
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
    public partial class CraftArmorGUI : Form
    {
        private FormState _state;
        private List<RadioButton> rbuttons;

        public CraftArmorGUI(FormState state)
        {
            _state = state;
            rbuttons = new List<RadioButton>();
            InitializeComponent();
        }

        private void CraftArmorGUI_Load(object sender, EventArgs e)
        {
            var recipes = _state.Player.Loot.Recipes;
            var display = recipes.FindAll(x => x != null && x.Ingredients.Count == 4);

            rbuttons.Add(headButton);
            rbuttons.Add(torsoButton);
            rbuttons.Add(armsButton);
            rbuttons.Add(waistButton);
            rbuttons.Add(legButton);

            // display all ingredients that aren't null
            display.ForEach(x =>
            {
                if (x.Result == null)
                {
                    int tier = (int)x.Ingredients.Average(i => i.Tier);

                    string namePrefix = "";

                    int normal = 0;
                    int ex = 0;
                    int asc = 0;

                    x.Ingredients.ForEach(i =>
                    {
                        if (i.Name.Contains("EX "))
                            ex++;
                        else if (i.Name.Contains("ASC"))
                            asc++;
                        else
                            normal++;
                    });

                    if(normal >= 1)
                    {
                        // do nothing if there is at least 1 normal mat
                        tier *= 1;
                    }
                    else if(ex >= 1)
                    {
                        // if there is at least 1 ex mat and no normal mats, it's ex
                        tier *= _state.AManager.EX_MODIFIER;
                        namePrefix = "EX ";
                    }
                    else
                    {
                        // if there aren't any normal mats and no ex mats, it's ascended
                        tier *= _state.AManager.ASC_MODIFIER;
                        namePrefix = "ASC ";
                    }

                    x.Result = _state.AManager.GetRandomArmorPiece(_state, tier, _state.Random.Next(0, 5));
                    x.Result.Name = namePrefix + x.Result.Name;
                }
            });

            recipeList.DataSource = display;
            if (recipeList.Items.Count > 0)
            {
                recipeList.SelectedIndex = 0;
            }
                
        }

        private void recipeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = recipeList.SelectedItem as Recipes.Recipe;
            if(selected != null)
            {
                var result = selected.Result;
                if(result != null)
                {
                    resultBox.Text = result.ToString();
                    skillBox.DataSource = result.Skills;
                    recipeIngredients.Items.Clear();
                    foreach (Recipes.Ingredient i in selected.Ingredients)
                    {
                        var l = _state.Player.Loot.EnemyLoot.Find(loot => loot.GetName().Equals(i.GetName()));
                        if (l == null)
                            recipeIngredients.Items.Add(i.DisplayString(0));
                        else
                            recipeIngredients.Items.Add(i.DisplayString(l.Quantity));
                    }
                }

            }

        }

        private void craftButton_MouseClick(object sender, MouseEventArgs e)
        {
            var selected = recipeList.SelectedItem as Recipes.Recipe;
            
            if(selected != null)
            {
                // do we have enough materials to craft this item?
                bool canCraft = selected.Ingredients.TrueForAll(i =>
                {
                    var item = _state.Player.Loot.EnemyLoot.Find(l => l.GetName().Equals(i.GetName()));
                    return (item == null) ? false : item.Quantity >= i.Quantity;
                });

                if (canCraft)
                {
                    if (_state.Player.Inventory.CanAdd())
                    {
                        _state.Player.Inventory.AddArmor(selected.Result);

                        // find and reduce the quantity of materials you're spending on the armor
                        selected.Ingredients.ForEach(i =>
                        {
                            var loot = _state.Player.Loot.EnemyLoot.Find(l => i.GetName().Equals(l.GetName()));
                            loot.Quantity -= i.Quantity;
                        });

                        _state.Player.Loot.EnemyLoot.RemoveAll(l => l.Quantity <= 0);

                        ClearDisplayBox();

                        RemoveRecipeFromList(selected, recipeList.SelectedIndex);

                        _state.Save.SaveGame(_state.Player);
                    }
                    else
                    {
                        MessageBox.Show("Your inventory is currently full. You can craft this item, but you can't add it at this time.");
                    }
                }
                else
                {
                    MessageBox.Show("You do not have enough materials to craft this item.");
                }
            }
            else
            {
                MessageBox.Show("You do not have enough materials to craft this item.");
            }
            

        }

        private void saveRecipe_MouseClick(object sender, MouseEventArgs e)
        {
            var selected = recipeList.SelectedItem as Recipes.Recipe;
            if(selected != null && recipeList.Items.Count > 0)
            {
                if (!_state.Player.Loot.Wishlist.Contains(selected))
                {
                    _state.Player.Loot.Wishlist.Add(selected);
                    MessageBox.Show("Recipe saved.");
                    _state.Save.SaveGame(_state.Player);
                }
                else
                {
                    MessageBox.Show("You already saved this recipe.");
                }
            }
        }

        private void RemoveRecipeFromList(Recipes.Recipe selected, int s_index)
        {
            _state.Player.Loot.Recipes.Remove(selected);

            recipeList.DataSource = null;

            if (_state.Player.Loot.Wishlist.Contains(selected))
                _state.Player.Loot.Wishlist.Remove(selected);

            var display = _state.Player.Loot.Recipes.FindAll(r => r.Result != null);

            if (display != null && display.Count > 0)
            {
                for (int i = 0; i < rbuttons.Count; i++)
                    if (rbuttons[i].Checked)
                        FindPiece(i);

                if (allButton.Checked)
                    recipeList.DataSource = display;

                if (wlistButton.Checked)
                    recipeList.DataSource = _state.Player.Loot.Wishlist;

                if (recipeList.Items.Count > 0)
                    _state.HandleSelectedIndex(recipeList, s_index);
                else
                    ClearDisplayBox();
            }
            else
            {
                ClearDisplayBox();
            }
        }

        private void ClearDisplayBox()
        {
            skillBox.DataSource = null;
            recipeIngredients.Items.Clear();
            resultBox.Clear();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _state.Type = FTypes.MOVE;
            _state.Location = Location;
            Close();
        }

        private void CraftArmorGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            _state.Save.SaveGame(_state.Player);
            if (_state.Type == FTypes.CRAFTING_ARMOR)
                _state.Type = FTypes.CLOSE;
        }

        private void enemyIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnemyIndexGUI eigui = new EnemyIndexGUI(_state.Player.EnemyIndex);
            eigui.StartPosition = FormStartPosition.Manual;
            eigui.Location = Location;
            eigui.ShowDialog();
        }

        private void headButton_CheckedChanged(object sender, EventArgs e)
        {
            if(headButton.Checked)
                FindPiece(ArmorPiece.HEAD);
        }

        private void torsoButton_CheckedChanged(object sender, EventArgs e)
        {
            if (torsoButton.Checked)
                FindPiece(ArmorPiece.TORSO);
        }

        private void armsButton_CheckedChanged(object sender, EventArgs e)
        {
            if (armsButton.Checked)
                FindPiece(ArmorPiece.ARMS);
        }

        private void waistButton_CheckedChanged(object sender, EventArgs e)
        {
            if (waistButton.Checked)
                FindPiece(ArmorPiece.WAIST);
        }

        private void legButton_CheckedChanged(object sender, EventArgs e)
        {
            if (legButton.Checked)
                FindPiece(ArmorPiece.LEGS);
        }

        private void allButton_CheckedChanged(object sender, EventArgs e)
        {
            if (allButton.Checked)
                recipeList.DataSource = _state.Player.Loot.Recipes;
        }

        private void wlistButton_CheckedChanged(object sender, EventArgs e)
        {
            if (wlistButton.Checked)
                recipeList.DataSource = _state.Player.Loot.Wishlist;
        }

        private void FindPiece(int piece)
        {
            try
            {
                recipeList.DataSource = _state.Player.Loot.Recipes.FindAll(r => r.Result != null && r.Result.Piece == piece);
            }
            catch(NullReferenceException)
            {
                recipeList.DataSource = null;
            }
        }

        private void deleteRecipe_Click(object sender, EventArgs e)
        {
            var selected = recipeList.SelectedItem as Recipes.Recipe;
            RemoveRecipeFromList(selected, recipeList.SelectedIndex);
        }
    }
}
