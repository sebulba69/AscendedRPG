using ProtoBuf;

namespace AscendedRPG.LootClasses
{
    [ProtoContract]
    public class Loot
    {
        [ProtoMember(1)]
        public int LType { get; set; }
        [ProtoMember(2)]
        public int Tier { get; set; }
        [ProtoMember(3)]
        public string Name { get; set; }
        [ProtoMember(5)]
        public int Quantity { get; set; }
        [ProtoMember(6)]
        public int Rarity { get; set; }
        [ProtoMember(7)]
        public string Suffix { get; set; }

        public Loot() { }

        public string GetName() => $"{Name} {Suffix}";

        public override string ToString()
        {
            return $"{Name} {Suffix} x{Quantity}";
        }
    }
}
