using AscendedRPG.LootClasses;
using AscendedRPG.Recipes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    [ProtoContract]
    public class LootHolder
    {
        [ProtoMember(1, AsReference = true)]
        public List<Loot> EnemyLoot { get; set; }
        [ProtoMember(2, AsReference = true)]
        public List<Recipe> Recipes { get; set; }
        [ProtoMember(3, AsReference =true)]
        public List<Recipe> Wishlist { get; set; }

        public LootHolder()
        {
            if (EnemyLoot == null)
                EnemyLoot = new List<Loot>();

            if (Recipes == null)
                Recipes = new List<Recipe>();

            if (Wishlist == null)
                Wishlist = new List<Recipe>();
        }

        public List<Loot> FilterLoot(int rarity)
        {
            try
            {
                return EnemyLoot.FindAll(l => l.Rarity == rarity);
            }
            catch (NullReferenceException)
            {
                return null;
            }
            
        }
    }
}
