using AscendedRPG.Enemies;
using AscendedRPG.GUIs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AscendedRPG
{
    public partial class DungeonGUIBoss : Form, IDungeon
    {
        private List<ProgressBar> subbars;
        private BossCalculator bc;
        private Enemy boss;
        private FormState _state;
        private DungeonGUIHelper dgh;

        public DungeonGUIBoss(FormState state)
        {
            _state = state;
            
            subbars = new List<ProgressBar>();
            
            InitializeComponent();
        }

        private void DungeonGUI_Load(object sender, EventArgs e)
        {
            Text = (_state.DungeonType == DungeonType.FINAL) ? "God's Domain" : $"Tier {_state.dungeonTiers[_state.DungeonType]} Boss Dungeon";

            dgh = new DungeonGUIHelper(_state, this);

            // set up the lists here since we need to reuse "SetUpEnemyGUI" later
            subbars.AddRange(new ProgressBar[] {subbar,subbar2,subbar3,subbar4,subbar5,subbar6,subbar7,subbar8,subbar9,
            subbar10,subbar11,subbar12,subbar13,subbar14,subbar15,subbar16,subbar17,subbar18,subbar19,subbar20,subbar21});

            bc = new BossCalculator(subbars.Count);

            dgh.Start();
        }

        #region Boss GUI Management
        public void SetUpEnemyGUI()
        {
            boss = dgh.MakeBoss();
            bc.CheckDefault(boss.HP);
            bc.SetSubBars(boss.HP);
            bossBar.Maximum = bc.hp_default;
            bossBar.Value = bc.baseBar;
            for (int i = 0; i < bc.subbars; i++)
                subbars[i].Visible = true;
            bossName.Text = boss.Name + $" [{_state.Player.GetWeaknessString(boss, _state.SManager)}]";
            bossPic.ImageLocation = boss.Image;
        }

        public void UpdateEnemyHealth()
        {
            bossName.Text = boss.Name + $" [{_state.Player.GetWeaknessString(boss, _state.SManager)}]";

            // set the values for the subbars again
            bc.SetSubBars(boss.HP);

            int s = 0;
            // for all subbars greater than what's supposed to be visible, reduce their value to 0
            foreach (ProgressBar sub in subbars)
                if (s++ >= bc.subbars)
                    sub.Value = 0;

            bossBar.Value = bc.baseBar;
        }

        public bool IsTroopDead() => boss.HP == 0;

        public int GetEnemyTurns() => boss.Turns;

        public void CloseGUI()
        {
            _state.Music.Stop();
            _state.Type = FTypes.INVENTORY;
            _state.Save.SaveGame(_state.Player);
            Close();
        }

        public void DistributeLoot()
        {
            for(int i = 0; i < 3; i++)
                dgh.DistributeLoot(boss);

            dgh.LogEnemy(boss, true);
        }

        public void StartMusic()
        {
            int tier = (_state.DungeonType == DungeonType.FINAL) ? _state.Player.GetLevel() : _state.dungeonTiers[_state.DungeonType];
            switch (_state.DungeonType)
            {
                case DungeonType.EX:
                    _state.Music.SetEXSong(tier);
                    break;
                case DungeonType.ASCENDED:
                    _state.Music.SetASCSong(tier);
                    break;
                case DungeonType.BOUNTY:
                case DungeonType.EXBOUNTY:
                case DungeonType.ASCBOUNTY:
                    _state.Music.SetBountySong(tier);
                    break;
                case DungeonType.FINAL:
                    _state.Music.SetFinalBossSong();
                    break;
                default:
                    _state.Music.SetBossSong(tier);
                    break;
            }

            if (boss.Name.Contains("Deviljho") || boss.Name.Contains("Rajang") || boss.Name.Contains("Seregios"))
                _state.Music.SetInvaderSong(tier);

            _state.Music.PlaySong();
        }
        #endregion

        #region toolStripMenuItems
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Running from dungeon...");
            CloseGUI();
        }

        private void enemyIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnemyIndexGUI eigui = new EnemyIndexGUI(_state.Player.EnemyIndex);
            eigui.StartPosition = FormStartPosition.Manual;
            eigui.Location = Location;
            eigui.ShowDialog();
        }
        #endregion

        private void UseSkillButton_MouseClick(object sender, MouseEventArgs e)
        {
            dgh.UseSelected(boss, 0);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            dgh.HandleEnemyTurn(boss);
        }

        private void UpdateLog(string log)
        {
            CombatLog.AppendText(log);
            CombatLog.AppendText(Environment.NewLine);
            CombatLog.AppendText(Environment.NewLine);
        }

        private void DungeonGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (UseSkillButton.Enabled)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        dgh.UseSelected(boss, 0);
                        break;
                }
            }
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
            if (!InvokeRequired)
            {
                if (_state.Type == FTypes.DUNGEON_BOSS)
                {
                    _state.Type = FTypes.CLOSE;
                    _state.Save.SaveGame(_state.Player);
                }
            }
            else
            {
                Close();
            }
        }

        public DGPComponents GetDGPComponents()
        {
            return new DGPComponents(ProfilePic, CurrentFight, FightsLeft, NameBox, TurnBox,
                CombatLog, new RadioButton[] { Target1, Target2, Target3 }, PlayerHealth,
                Skills, UseSkillButton, leftButton, rightButton, timer);
        }
    }
}
