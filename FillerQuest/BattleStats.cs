using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    public class BattleStats
    {
        public int[] stats, elementalRes, buff;
        public bool isParryState, isParried;

        public BattleStats()
        {
            stats = new int[4];
            buff = new int[4];
            elementalRes = new int[9];
            isParryState = false;
            isParried = false;
        }

        public bool CanBuff(int stat)
        {
            buff[stat] += (buff[stat] >= 3) ? 0 : 1;
            return buff[stat] <= 2;
        }
    }
}
