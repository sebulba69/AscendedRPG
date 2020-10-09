using AscendedRPG.Files;
using System;
using System.Collections.Generic;

namespace AscendedRPG
{
    public class Dungeon
    {
        private int fights, currentFight;

        private EnemyManager loader;

        public Dungeon(int t, int type)
        {
            fights = ((t + 5)/2) * (type + 1);
            currentFight = 1;
            loader = new EnemyManager();
        }

        public Dungeon()
        {
            fights = 0;
            currentFight = 1;
            loader = new EnemyManager();
        }

        public Enemy[] MakeEnemyTroop(int dtype, int tier, Random r) => loader.MakeTroop(dtype, tier, r);

        public Enemy MakeBoss(int type, int tier, Random r) => loader.MakeBoss(type, tier, r);

        public void LoadNextFight()
        {
            fights--;
            currentFight++;
        }

        public bool IsDungeonComplete() => (fights <= 0);

        public void ForceEnd() => fights = 0;

        public int GetFights() => fights;

        public int GetCurrentFight() => currentFight;

    }
}
