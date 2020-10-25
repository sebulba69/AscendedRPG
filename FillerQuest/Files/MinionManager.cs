using AscendedRPG.Enemies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Files
{
    public class MinionManager
    {
        private readonly string PIC_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "enemies", "minions");

        private string[] _images;
        private Random _rand;

        public MinionManager(Random r)
        {
            _rand = r;
            _images = Directory.GetFiles(PIC_PATH);
        }

        public Minion MakeMinion()
        {
            var minion = new Minion();
            minion.Level = 1;
            minion.XP = 0;
            minion.XPtoNext = 500;
            minion.Weapon = MakeWeapon();
            minion.MType = _rand.Next(0, _images.Length);
            minion.Skills = MakeSkills(minion.MType);
            minion.Image = _images[minion.MType];
            minion.IsEquipped = false;
            return minion;
        }

        private Weapon MakeWeapon()
        {
            var weapon = new Weapon();

            weapon.Level = 1;
            weapon.XP = 0;
            weapon.XPtoNext = 500;
            weapon.Damage = 13;
            weapon.Style = _rand.Next(0, 3); // ATTACK, PARRY, LIFESTEAL

            return weapon;
        }

        private List<Skill> MakeSkills(int type)
        {
            var skills = new List<Skill>();

            // 3 types of minions -- BUFF, SUPPORT, ATTACK
            
            string image = _images[type];

            switch (type)
            {
                // buff
                case 0:
                    string[] bnames = { "Bucettack Up", "Bucefense Up", "Bucriticals Up" };
                    int stat = _rand.Next(0, bnames.Length);

                    var obskill = new Skill()
                    {
                        S_Type = SkillType.OFFENSIVE_BUFF,
                        Name = bnames[stat],
                        Multiplier = 1,
                        Damage = 0,
                        Element = 0,
                        Stat = stat
                    };

                    // offensive buff minions only have 1 skill + their weapon
                    skills.Add(obskill);
                    break;
                // support
                case 1:

                    var hskill = new Skill()
                    {
                        S_Type = SkillType.HEALING,
                        Name = "Bucey HP",
                        Multiplier = 1,
                        Damage = _rand.Next(10,21),
                        Element = 0,
                        Stat = 0
                    };

                    skills.Add(hskill);
                    break;
                // by default, the minion is an attack minion
                default:
                    var sm = new SkillManager();
                    string[] names = { "Bucire", "Bucater", "Buceyice", "Bushock", "Buwind", "Bucenuke", "Bucedark", "Bulight", "Buceical" };
                    
                    for (int i = 0; i < 2; i++)
                    {
                        int n = _rand.Next(0, names.Length);
                        var oskill = new Skill()
                        {
                            S_Type = SkillType.OFFENSIVE,
                            Name = names[n],
                            Multiplier = 1,
                            Damage = _rand.Next(15,21),
                            Element = n,
                            Stat = 0
                        };

                        skills.Add(oskill);
                    }
                    break;
            }

            return skills;
        }
    }
}
