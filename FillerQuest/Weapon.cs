using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    [ProtoContract]
    public class Weapon
    {
        [ProtoMember(1)]
        public int Level { get; set; }
        [ProtoMember(2)]
        public long XP { get; set; }
        [ProtoMember(3)]
        public long XPtoNext { get; set; }
        [ProtoMember(4)]
        public int Damage { get; set; }
        [ProtoMember(5)]
        public int Style { get; set; }

        public Weapon() { }

        public void IncreaseXP(long xp)
        {
            XP += xp;
            if (XP >= XPtoNext)
                LevelUp();
        }

        private void LevelUp()
        {
            Level += (Level + 1 >= int.MaxValue) ? 0 : 1;
            XP -= XPtoNext;
            XPtoNext = GetRequiredXP();
            Damage += 50;
        }

        // bs formula that scales with level ups
        private long GetRequiredXP()
        {
            try
            {
                long x = Level * 70;
                return (x * (int)Math.Log(x)) + x + (Level + 5);
            }
            catch (OverflowException)
            {
                return long.MaxValue;
            }

        }

        public string DisplayString()
        {
            string[] type = {"Attk", "Parry", "Lfstl"};
            return $"T.{Level} Weapon [{type[Style]}]";
        }

        public override string ToString()
        {
            if (XP > -1 && XPtoNext > -1)
            {
                double x = XP;
                double y = XPtoNext;
                return $"T.{Level} Weapon [{Damage}] ({Math.Round(((x / y) * 100), 2)}/100%)";
            }
            else
            {
                return $"T.{Level} Weapon [{Damage}] (MAX)";
            }

        }
    }
}
