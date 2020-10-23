using AscendedRPG;
using AscendedRPG.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.LootClasses
{
    public class LootHandler
    {
        private readonly string[] enemyLoot = { "Energy", "Shard", "Scale", "Mantle", "Crystal" };

        private readonly string[] tierLoot = { "Essence", "Plate", "Orb", "Relic", "Jewel" };

        private readonly string[] recipeLootNames = { "normal.bin", "ex.bin", "ascended.bin" };

        public LootHandler() { }

        public void GetRecipeDrop(int tier, int dtype, List<Recipe> recipes, Random r)
        {
            var npath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended/recipes", recipeLootNames[dtype]);
            var names = AscendedRPG.Files.EncryptionManager.DeCrypt<List<string>>(npath);
            var name = names[r.Next(0, names.Count)];

            Ingredient ingredient = new Ingredient()
            {
                Tier = (tier + dtype) * (dtype + 1),
                Name = name,
                Suffix = enemyLoot[GetDropIndex(r)],
                Quantity = r.Next(tier + 5, tier + 16)
            };

            AddIngredient(recipes, ingredient);
        }

        private void AddIngredient(List<Recipe> recipes, Ingredient ingredient)
        {
            // returns null if condition not met
            Recipe recipe = recipes.Find(x => x.Ingredients.Count < 4);
            if(recipe == null)
            {
                recipe = new Recipe() { Ingredients = new List<Ingredient>() };
                recipe.Ingredients.Add(ingredient);
                recipes.Add(recipe);
            }
            else
            {
                // ensure no duplicates
                var sameIngredient = recipe.Ingredients.Find(i => i.Name.Equals(ingredient.Name));
                if (sameIngredient == null)
                {
                    // no duplicate found, into the ingredient list it goes
                    recipe.Ingredients.Add(ingredient);
                }
                else
                {
                    // slightly increase the quantity required of an ingredient by quanity/2
                    // these will most likely get humongous as you go up in tier so this is a bet
                    sameIngredient.Quantity += ingredient.Quantity/2;
                    sameIngredient.Tier++;
                }
            }
        }

        public Loot GetEnemyDrop(string name, Random r, int tier)
        {
            var loot = new Loot();
            int index = GetDropIndex(r);
            MakeLoot(loot, LootType.ENEMY_DROP, name, enemyLoot[index], index);
            loot.Quantity = r.Next(1, tier+1);
            return loot;
        }

        private void MakeLoot(Loot loot, int type, string name, string suffix, int index)
        {
            loot.LType = type;
            loot.Name = name;
            loot.Suffix = suffix;
            loot.Rarity = index + 1;
        }

        private int GetDropIndex(Random r)
        {
            int suffix = r.Next(1, 101);
            if (suffix <= 35)
                return 0;
            else if (suffix > 35 && suffix <= 55)
                return 1;
            else if (suffix > 55 && suffix <= 75)
                return 2;
            else if (suffix > 75 && suffix <= 85)
                return 3;
            else
                return 4;
        }
    }
}
