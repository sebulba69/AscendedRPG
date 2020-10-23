using AscendedRPG.Skill_Files;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace AscendedRPG
{
    [ProtoContract]
    public class Armor
    {
        [ProtoMember(1)]
        public int Piece { get; set; } // head, chest, arms, waist, legs
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int Defense { get; set; }
        [ProtoMember(4, AsReference = true)]
        public List<ArmorSkill> Skills { get; set; }
        [ProtoMember(5)]
        public int UpgradeLevel { get; set; }
        [ProtoMember(6)]
        public int UpXP { get; set; }

        public Armor()
        {
            if(Skills == null) Skills = new List<ArmorSkill>();
        }

        public string PrintSkills()
        {
            var str = new StringBuilder();
            for (int i = 0; i < Skills.Count - 1; i++)
                str.Append(Skills[i].ToString() + "|");
            str.Append(Skills[Skills.Count - 1].ToString());
            return str.ToString();
        }

        public void LevelUp()
        {
            Defense += 20;
            foreach(ArmorSkill s in Skills)
            {
                if (s.Skill.Stat == Stat.TURNS)
                    s.Skill.Multiplier += (s.Skill.Multiplier >= 5) ? 0 : 1;
                else
                    s.Skill.Multiplier++;

            }
            UpgradeLevel++;
        }

        public override string ToString()
        {
            return $"[{Defense}] {Name}";
        }

    }
}