using AscendedRPG;
using AscendedRPG.Files;
using System;
using System.Drawing;

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

        public int DungeonType { get; set; }

        public FormState()
        {
            dungeonTiers = new int[7];
            for (int i = 0; i < dungeonTiers.Length; i++)
                dungeonTiers[i] = 1;
        }
    }
}
