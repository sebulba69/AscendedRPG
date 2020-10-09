using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Recipes
{
    [ProtoContract]
    public class Ingredient
    {
        [ProtoMember(1)]
        public int Tier { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int Quantity { get; set; }
        [ProtoMember(4)]
        public string Suffix { get; set; }

        public Ingredient() { }

        public string GetName() => $"{Name} {Suffix}";

        public string DisplayString(int currentOwned)
        {
            return $"{Name} {Suffix} x{Quantity} -- ({currentOwned}/{Quantity})";
        }

        public override string ToString()
        {
            return $"{Name} x{Quantity}";
        }
    }
}
