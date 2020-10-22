using AscendedRPG.Files;
using ProtoBuf;
using System;

namespace AscendedRPG
{
    [ProtoContract]
    public class Skill : ICloneable
    {
        [ProtoMember(1)]
        public int S_Type { get; set; } // what type of skill you're working with (will help with DB lookups)
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int Multiplier { get; set; }
        [ProtoMember(4)]
        public int Element { get; set; }
        [ProtoMember(5)]
        public int Damage { get; set; }
        [ProtoMember(6)]
        public int Stat { get; set; }

        public Skill() { }

        public int GetDamage() => CalculateDamage(Damage, Multiplier);

        private int CalculateDamage(int d, int m) => (m == 1) ? d : d + (m * 5);

        public override string ToString()
        {
            switch (S_Type)
            {
                case SkillType.OFFENSIVE_BUFF:
                case SkillType.PASSIVE_BUFF:
                case SkillType.PASSIVE_VOID:
                    return $"{Name} +{Multiplier}";
                default:
                    return $"[{GetDamage()}] {Name} +{Multiplier}";
            }
        }

        public object Clone()
        {
            return new Skill
            {
                S_Type = S_Type,
                Damage = Damage,
                Name = Name,
                Multiplier = Multiplier,
                Element = Element,
                Stat = Stat
            };
        }
    }
}