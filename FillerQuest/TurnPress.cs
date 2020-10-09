using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    public class TurnPress
    {
        private int icons;
        public bool turnEnd;

        public TurnPress()
        {
            turnEnd = false;
        }

        public void SetTurns(int turns)
        {
            icons = turns;
            turnEnd = false;
        }

        public void Miss()
        {
            if(icons % 2 == 0)
            {
                FullTurn();
            }
            else
            {
                HalfTurn();
            }
        }

        public void HalfTurn()
        {
            DecreaseIcon(1);
        }

        public void FullTurn()
        {
            DecreaseIcon(2);
        }

        private void DecreaseIcon(int amount)
        {
            icons -= amount;
            if(icons <= 0)
            {
                icons = 0;
                turnEnd = true;
            }
        }

        public int GetIcons()
        {
            return icons / 2;
        }

        public int GetTotalIcons() => icons;

        public string PrintIcons()
        {
            StringBuilder str = new StringBuilder();
            string icon;
            for (int i = 0; i < icons; i++)
            {
                if(i % 2 == 0)
                {
                    icon = "{0";
                }
                else
                {
                    icon = "0}";
                }

                str.Append(icon);
            }

            return str.ToString();
        }
    }
}
