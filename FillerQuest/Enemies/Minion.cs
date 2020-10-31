using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Enemies
{
    [ProtoContract]
    public class Minion
    {
        [ProtoMember(1)]
        public int Level { get; set; }
        [ProtoMember(2)]
        public long XP { get; set; }
        [ProtoMember(3)]
        public long XPtoNext { get; set; }
        [ProtoMember(4)]
        public List<Skill> Skills { get; set; }
        [ProtoMember(5)]
        public Weapon Weapon { get; set; }
        [ProtoMember(6)]
        public string Image { get; set; }
        [ProtoMember(7)]
        public int MType { get; set; }
        [ProtoMember(8)]
        public bool IsEquipped { get; set; }

        [ProtoMember(9)]
        public int Prestige { get; set; }

        public Minion() { }

        public void IncreaseXP(long xp, int max)
        {
            if(Level < 100)
            {
                XP += xp;
                if (XP >= XPtoNext)
                    LevelUp(max);
            }
            else
            {
                XP = 0;
            }
        }

        public void LevelUp(int max)
        {
            if (Level + 1 <= 100)
            {
                Level++;
                XP -= XPtoNext;
                XPtoNext = GetRequiredXP();

                int p_mult = Prestige + 1;
                int init_mult = 3 + Prestige;

                Skills.ForEach(s =>
                {
                    if (s.Multiplier + (init_mult * p_mult) >= max)
                        s.Multiplier = max;
                    else
                        s.Multiplier += (init_mult * p_mult);
                });
            }
        }

        public void GodForm(int max)
        {
            Level = 1;
            XP = 0;
            XPtoNext = GetRequiredXP();
            Skills.ForEach(s =>
            {
                if (s.Multiplier + 90 >= max)
                    s.Multiplier = max;
                else
                    s.Multiplier += 90;
            });
            Prestige += (Prestige + 5 >= max) ? 0 : 5;
        }

        // bs formula that scales with level ups
        private long GetRequiredXP()
        {
            try
            {
                long x = Level * 30;
                return (x * (int)Math.Log(x)) + x + (Level + 5);
            }
            catch (OverflowException)
            {
                return long.MaxValue;
            }
        }

        public string NameString()
        {
            string[] names = { "Buff Minion", "Support Minion", "Attack Minion" };
            return $"{names[MType]} L.{Level}";
        }

        public override string ToString()
        {
            string[] names = { "Buff Minion", "Support Minion", "Attack Minion" };
            double x = XP;
            double y = XPtoNext;
            string name = $"{names[MType]} L.{Level} ({Math.Round(((x / y) * 100), 2)}/100)";
            name = (IsEquipped) ? "[E] " + name : name;
            return name;
        }
    }
}
