using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Enemies
{
    public class BossCalculator
    {
        private int hpDefault = 5000;

        // baseBar is a percentage of hp_default
        private int subDefault, baseBar, subBars;

        public BossCalculator(int sub_def)
        {
            subDefault = sub_def;
        }

        public void SetupBars(int hp)
        {
            CheckDefault(hp);
            SetSubBars(hp);
        }

        private void CheckDefault(int hp)
        {
            int max = hpDefault * subDefault;
            if(hp >= max)
            {
                hpDefault = hp / subDefault;
                while(hp >= max)
                {
                    hpDefault += 5000;
                    max = hpDefault * subDefault;
                }
            }

            hpDefault = Math.Abs(hpDefault);
        }

        public void SetSubBars(int hp)
        {
            int health = hp;
            int subs = 0;

            if(health > hpDefault)
            {
                if(health % hpDefault != 0)
                {
                    health = health % hpDefault;
                    subs = (hp - health) / hpDefault;
                }
                else
                {
                    health = hpDefault;
                    subs = (hp / hpDefault) - 1; // subtract 1 for last healthbar
                }
            }

            baseBar = health;
            subBars = subs;
        }

        // get base bar percentage
        public int GetBBPercent()
        {
            double top = baseBar;
            double bottom = hpDefault;
            return (int)(100 * (top / bottom));
        }

        public int GetSubbars() => subBars;

        public void ResetBars()
        {
            hpDefault = 5000;
        }
    }
}
