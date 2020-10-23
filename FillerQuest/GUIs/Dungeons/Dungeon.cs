using AscendedRPG.Files;
using System;
using System.Collections.Generic;

namespace AscendedRPG
{
    public class Dungeon
    {
        private int fights, currentFight, dtype, tier;
        private EnemyManager loader;
        private Random r;

        public Dungeon(int t, int type, Random random)
        {
            tier = t;
            dtype = type;
            r = random;

            // if type % 10 == 0 OR we're in a bounty dungeon or above
            fights = (t % 10 == 0 || type >= Enemies.DungeonType.BOUNTY) ? 0 : ((t + 5)/2) * (type + 1);
            currentFight = 1;
            loader = new EnemyManager();
        }


        public Enemy[] MakeEnemyTroop() => loader.MakeTroop(dtype, (tier * dtype + 1), r);

        public Enemy MakeBoss() => loader.MakeBoss(dtype, tier, r);

        public void LoadNextFight()
        {
            fights--;
            currentFight++;
        }

        public void ForceEnd() => fights = 0;

        public int GetFights() => fights;

        public int GetCurrentFight() => currentFight;

    }
}
