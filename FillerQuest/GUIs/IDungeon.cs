using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.GUIs
{
    public interface IDungeon
    {
        void UpdateEnemyHealth();
        void SetUpEnemyGUI();
        void StartMusic();
        void CloseGUI();
        void DistributeLoot();

        int GetEnemyTurns();
        
        bool IsTroopDead();
        DGPComponents GetDGPComponents();
    }
}
