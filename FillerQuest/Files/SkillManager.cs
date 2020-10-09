using AscendedRPG;
using System;
using System.Collections.Generic;
using System.IO;

namespace AscendedRPG.Files
{
    public class SkillManager
    {
        private readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "skills.bin");

        private readonly string[] elements =  { "Fire", "Water", "Ice", "Shock", "Wind", "Nuke", "Dark", "Light", "Physical"};

        private readonly string[] stats = { "Attack", "Defense", "Critical", "Turns" };

        private List<Skill> skills;

        public SkillManager()
        {
            skills = EncryptionManager.DeCrypt<List<Skill>>(PATH);
        }

        public HashSet<int> Wex(Random r)
        {
            var set = new HashSet<int>();
            int n = r.Next(1, 3);
            for(int i = 0; i < n; i++)
            {
                int value = r.Next(0, 9);
                while(set.Contains(value))
                {
                    value = r.Next(0, 9);
                }
                set.Add(value);
            }
            return set;
        }
        
        public List<Skill> GetRandomArmorSkills(int tier, Random r)
        {
            var result = new List<Skill>();

            int num = r.Next(1, 3);

            for(int i = 0; i < num; i++)
            {
                Skill s = (Skill)skills[r.Next(0, skills.Count)].Clone();

                s.Damage = (s.S_Type == SkillType.OFFENSIVE || s.S_Type == SkillType.HEALING) ? r.Next(20 + (tier * 5), 40 + (tier * 5)) : 0;

                switch(s.S_Type)
                {
                    case SkillType.PASSIVE_BUFF:
                        s.Multiplier = (s.Stat == Stat.TURNS) ? r.Next(1, 2) : r.Next(10 + (tier * 3), 30 + (tier * 3));
                        break;
                    case SkillType.PASSIVE_VOID:
                        s.Multiplier = r.Next(10 + (tier * 3), 30 + (tier * 3));
                        break;
                    default:
                        s.Multiplier = r.Next(1, ((tier / 5) + 1) + 1);
                        break;
                }

                result.Add(s);
            }

            return result;
        }

        public string ElementToString(int element)
        {
            return elements[element];
        }

        public string StatsToString(int stat)
        {
            return stats[stat];
        }
    }
}
