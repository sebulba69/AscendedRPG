using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.Enemies
{
    public class BossCalculator
    {
        public int hp_default = 5000;

        private int sub_default;

        public int baseBar, subbars;
        
        public BossCalculator(int sub_def)
        {
            sub_default = sub_def;
        }

        public void CheckDefault(int hp)
        {
            int max = hp_default * sub_default;
            if(hp >= max)
            {
                hp_default = hp / sub_default;
                while(hp >= max)
                {
                    hp_default += 5000;
                    max = hp_default * sub_default;
                }
            }
        }

        public void SetSubBars(int hp)
        {
            baseBar = 0;
            if(hp <= hp_default)
            {
                baseBar = hp;
                subbars = 0;
            }
            else
            {
                if(hp % hp_default != 0)
                {
                    int h = hp;
                    while(h % hp_default != 0)
                    {
                        h--;
                        baseBar++;
                    }
                    subbars = h / hp_default;
                }
                else
                {
                    baseBar = hp_default;
                    subbars = hp / hp_default;
                }
            }
        }

        public void ResetBars()
        {
            hp_default = 5000;
        }
    }
}
