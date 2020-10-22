using AscendedRPG;
using AscendedRPG.Enemies;
using AscendedRPG.GUIs;
using AscendedRPG.LootClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AscendedRPG
{
    public partial class DungeonGUI : Form, IDungeon
    {
        private List<PictureBox> enemyBoxes;
        private List<ProgressBar> enemyBars;
        private List<TextBox> enemyNames;

        private FormState _state;

        private DungeonGUIHelper dgh;

        private Enemy[] troop;

        private bool loading;

        public DungeonGUI(FormState state)
        {
            _state = state;

            loading = true;

            enemyBoxes = new List<PictureBox>();
            enemyBars = new List<ProgressBar>();
            enemyNames = new List<TextBox>();

            InitializeComponent();
        }

        private void DungeonGUI_Load(object sender, EventArgs e)
        {
            Text = $"Tier {_state.dungeonTiers[_state.DungeonType]} Dungeon";

            // set up the lists here since we need to reuse "SetUpEnemyGUI" later
            enemyBoxes.AddRange(new PictureBox[]{EnemyPic1, EnemyPic2, EnemyPic3});
            enemyBars.AddRange(new ProgressBar[] { EnemyBar1, EnemyBar2, EnemyBar3 });
            enemyNames.AddRange(new TextBox[] { EnemyBox1, EnemyBox2, EnemyBox3 });

            dgh = new DungeonGUIHelper(_state, this);

            dgh.Start();
        }

        #region Enemy GUI Management
        public void SetUpEnemyGUI()
        {
            loading = true;

            troop = dgh.MakeTroop();

            for (int i = 0; i < troop.Length; i++)
            {
                if (troop[i] != null)
                {
                    enemyNames[i].Text = troop[i].Name + $" [{_state.Player.GetWeaknessString(troop[i], _state.SManager)}]";
                    enemyBoxes[i].ImageLocation = troop[i].Image;
                    enemyBars[i].Maximum = troop[i].HP;
                    enemyBars[i].Value = enemyBars[i].Maximum;
                    dgh.SetTargetButtonEnabled(i, true);
                }
                else
                {
                    enemyNames[i].Clear();
                    enemyBoxes[i].ImageLocation = null;
                    enemyBars[i].Value = 0;
                    dgh.SetTargetButtonEnabled(i, false);
                }
            }
            loading = false;
            dgh.ChangeTargetButtonChecked();
        }

        public void UpdateEnemyHealth()
        {
            for (int i = 0; i < troop.Length; i++)
                if (troop[i] != null)
                {
                    enemyBars[i].Value = troop[i].HP;
                    enemyNames[i].Text = troop[i].Name + $" [{_state.Player.GetWeaknessString(troop[i], _state.SManager)}]";
                }  
        }

        public bool IsTroopDead()
        {
            bool dead = true;
            foreach (Enemy e in troop)
                if (e != null && e.HP > 0)
                    dead = false;
            return dead;
        }

        public int GetEnemyTurns()
        {
            int turns = 0;
            foreach (Enemy e in troop)
                if (e != null && e.HP > 0)
                    turns += e.Turns;
            return turns;
        }

        public void CloseGUI()
        {
            _state.Music.Stop();
            _state.Type = FTypes.INVENTORY;
            _state.Save.SaveGame(_state.Player);
            Close();
        }

        public void DistributeLoot()
        {
            foreach (Enemy e in troop)
                if (e != null)
                {
                    dgh.DistributeLoot(e);
                    dgh.LogEnemy(e, false);
                }   
        }
        #endregion

        #region toolStripMenuItems
        private void enemyIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnemyIndexGUI eigui = new EnemyIndexGUI(_state.Player.EnemyIndex);
            eigui.StartPosition = FormStartPosition.Manual;
            eigui.Location = Location;
            eigui.ShowDialog();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // to be added
        }
        #endregion

        private void UseSkillButton_MouseClick(object sender, MouseEventArgs e)
        {
            UseSelectedSkill();
        }

        private void UseSelectedSkill()
        {
            int t = dgh.SelectTarget();
            dgh.UseSelected(troop[t], t);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            dgh.HandleEnemyTurn(dgh.GetNextEnemy(troop));
        }

        private void rightButton_MouseClick(object sender, MouseEventArgs e)
        {
            dgh.ChangeCurrentBattler(1);
        }

        private void leftButton_MouseClick(object sender, MouseEventArgs e)
        {
            dgh.ChangeCurrentBattler(-1);
        }

        private void DungeonGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.DUNGEON_GUI)
            {
                _state.Type = FTypes.CLOSE;
                _state.Save.SaveGame(_state.Player);
            }
        }

        public DGPComponents GetDGPComponents()
        {
            return new DGPComponents(ProfilePic, CurrentFight, FightsLeft, NameBox, TurnBox,
                CombatLog, new RadioButton[] { Target1, Target2, Target3 }, PlayerHealth,
                Skills, UseSkillButton, leftButton, rightButton, timer);
        }

        public void StartMusic()
        {
            _state.Music.SetFloorSong( _state.dungeonTiers[_state.DungeonType]);
            _state.Music.PlayFloorSong();
        }

        private void DungeonGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if(UseSkillButton.Enabled && !loading)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        UseSelectedSkill();
                        break;
                }
            }
        }
    }
}
