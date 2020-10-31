using AscendedRPG;
using AscendedRPG.Files;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public class FormState
    {
        public Point Location { get; set; }
        public FTypes Type { get; set; }
        public Player Player { get; set; }
        public Random Random { get; set; }
        public MusicManager Music { get; set; }
        public SaveManager Save { get; set; }
        public SkillManager SManager { get; set; }
        public ArmorManager AManager { get; set; }

        public int[] dungeonTiers;

        // 0 -> 6
        // normal, ex, asc, bounty, exbounty, ascbounty, elder
        private readonly int[] CAPS = { 250, 250, 250, 20, 20, 20, 21 };

        public readonly int MAX_MULT = 500000;

        public int DungeonType { get; set; }

        public FormState()
        {
            dungeonTiers = new int[7];
            for (int i = 0; i < dungeonTiers.Length; i++)
                dungeonTiers[i] = 1;
        }

        public void ProcessCompletedTier(int memberCount)
        {
            int d_tier = dungeonTiers[DungeonType];
            int boss = (d_tier % 10 == 0) ? 2 : 1;
            HandleTierLevel(d_tier);
            HandleXPDistribution(d_tier, boss, memberCount);
            Player.Wallet.AddDellenCoin(Random.Next(Random.Next(1000, 2001) * boss * (DungeonType + 1) * (Player.Minions.Count+1)));
        }

        private void HandleTierLevel(int d_tier)
        {
            var tiers = Player.Tiers;

            // if our current floor == our current level and we haven't hit the level cap, level up
            if (tiers[DungeonType] == d_tier && tiers[DungeonType] != CAPS[DungeonType])
                    tiers[DungeonType] += 1;
        }

        private void HandleXPDistribution(int d_tier, int boss, int memberCount)
        {
            int quantity = Random.Next(3, 5) + boss + memberCount;
          
            for (int i = 0; i < quantity; i++)
            {
                int xp = Random.Next(d_tier, d_tier * 2) + (Player.GetLevel() +(DungeonType + 1));
                Player.Weapon.IncreaseXP(xp);
                Player.Minions.ForEach(m =>
                {
                    m.IncreaseXP(xp, MAX_MULT);
                    m.Weapon.IncreaseXP(xp);
                });
            }
        }

        public int GetCap(int type) => CAPS[type];

        public int GetCapCount() => CAPS.Length;

        public int GetCap()
        {
            int total = 0;
            foreach (int c in CAPS)
                total += c;
            return total;
        }

        public void HandleSelectedIndex(ListBox listBox, int s_index)
        {
            if (listBox.Items.Count > 0)
                if (s_index < listBox.Items.Count)
                    listBox.SelectedIndex = s_index;
                else
                    if (s_index - 1 >= 0)
                        listBox.SelectedIndex = s_index - 1;
                    else
                        listBox.SelectedIndex = 0;
        }
    }
}
