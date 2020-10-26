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

        public Minion() { }

        public void IncreaseXP(long xp)
        {
            if(Level < 100)
            {
                XP += xp;
                if (XP >= XPtoNext)
                    LevelUp();
            }
            else
            {
                XP = 0;
            }
        }

        public void LevelUp()
        {
            if(Level + 1 <= 100)
            {
                Level++;
                XP -= XPtoNext;
                XPtoNext = GetRequiredXP();
                Skills.ForEach(s => s.Multiplier += 2);
            }
        }

        public void GodForm()
        {
            Level = 1;
            XP = 0;
            XPtoNext = GetRequiredXP();
            Skills.ForEach(s => s.Multiplier += 50);
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
