using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Recipes
{
    [ProtoContract]
    public class Recipe
    {
        [ProtoMember(1, AsReference = true)]
        public List<Ingredient> Ingredients { get; set; }
        [ProtoMember(3)]
        public AscendedRPG.Armor Result { get; set; }

        public Recipe() { }

        public override string ToString()
        {
            return (Result != null) ? Result.ToString() + " Recipe" : "";
        }
    }
}
