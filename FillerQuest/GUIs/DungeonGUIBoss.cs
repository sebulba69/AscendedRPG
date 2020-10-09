using AscendedRPG.Enemies;
using AscendedRPG.Files;
using AscendedRPG.GUIs;
using AscendedRPG;
using AscendedRPG.GUIs;
using AscendedRPG.LootClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG
{
    public partial class DungeonGUIBoss : Form
    {
        private List<ProgressBar> subbars;
        private BossCalculator bc;
        private Enemy boss;
        private FormState _state;
        private Dungeon d;
        private int d_tier;
        private int currentFighter;
        private List<BattleMember> members;
        private DungeonGUIHelper dgh;

        public DungeonGUIBoss(FormState state)
        {
            _state = state;
            d = new Dungeon();
            bc = new BossCalculator();
            subbars = new List<ProgressBar>();
            d_tier = _state.dungeonTiers[_state.DungeonType];
            currentFighter = 0;
            members = new List<BattleMember>();
            
            InitializeComponent();
        }

        private void DungeonGUI_Load(object sender, EventArgs e)
        {
            Text = $"Tier {d_tier} Boss Dungeon";

            // set up the lists here since we need to reuse "SetUpEnemyGUI" later
            subbars.Add(subbar);
            subbars.Add(subbar2);
            subbars.Add(subbar3);
            subbars.Add(subbar4);
            subbars.Add(subbar5);
            subbars.Add(subbar6);
            subbars.Add(subbar7);
            subbars.Add(subbar8);
            subbars.Add(subbar9);
            subbars.Add(subbar10);
            subbars.Add(subbar11);
            subbars.Add(subbar12);
            subbars.Add(subbar13);
            subbars.Add(subbar14);
            subbars.Add(subbar15);
            subbars.Add(subbar16);
            subbars.Add(subbar17);
            subbars.Add(subbar18);
            subbars.Add(subbar19);
            subbars.Add(subbar20);
            subbars.Add(subbar21);

            _state.Music.SetBossSong(d_tier);
            _state.Music.PlayBossSong();

            _state.Player.Stats = new BattleStats();

            PlayerHealth.Maximum = _state.Player.GetHP() + _state.Player.Set.TotalDef + _state.Player.Stats.stats[Stat.DEFENSE];
            PlayerHealth.Value = PlayerHealth.Maximum;

            SetUpEnemyGUI();

            dgh = new DungeonGUIHelper(_state, Skills, NameBox,
                ProfilePic, PlayerHealth, CurrentFight,
                FightsLeft, d, TurnBox, UseSkillButton,
                CombatLog, d_tier);

            dgh.SetUp();
        }

        private void SetUpEnemyGUI()
        {
            boss = d.MakeBoss(_state.DungeonType, (int)Math.Pow(d_tier, _state.DungeonType + 1), _state.Random);
            bc.SetSubBars(boss.HP);
            bossBar.Maximum = bc.hp_default;
            bossBar.Value = bc.baseBar;
            for (int i = 0; i < bc.subbars; i++)
                subbars[i].Visible = true;
            bossName.Text = boss.Name + $" [{_state.Player.GetWeaknessString(boss, _state.SManager)}]";
            bossPic.ImageLocation = boss.Image;
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Retreating from dungeon...");
            RunAway();
        }

        private void RunAway()
        {
            _state.Music.Stop();
            _state.Save.SaveGame(_state.Player);
            _state.Type = FTypes.INVENTORY;
            _state.Location = Location;
            Close();
        }

        private void DungeonGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_state.Type == FTypes.DUNGEON_BOSS)
            {
                _state.Type = FTypes.CLOSE;
                _state.Save.SaveGame(_state.Player);
            }
        }

        private void UseSkillButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (Skills.SelectedItem.ToString().Contains(" Weapon"))
                UseWeapon();
            else
                UseSelectedSkill();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            dgh.EnemyAttackPlayer(boss);
            if (dgh.GetIsPlayerDead())
            {
                timer.Stop();
                MessageBox.Show("You died.");
                RunAway();
            }
            else if (dgh.IsTurnEndEnemy())
                timer.Stop();
            else
                dgh.ContinueEnemyTurn();
        }

        private void UseSelectedSkill()
        {
            try
            {
                dgh.UseSelectedSkill(boss);
                CheckEnemyHP();
                bossName.Text = boss.Name + $" [{_state.Player.GetWeaknessString(boss, _state.SManager)}]";

                TurnCheck();
            }
            catch (NullReferenceException) { }
        }

        private void UseWeapon()
        {
            try
            {
                dgh.UseWeapon(boss);
                TurnCheck();
            }
            catch (NullReferenceException) { }
        }

        private void TurnCheck()
        {
            if (dgh.TurnCheck())
            {
                dgh.EndPlayerTurn(boss.Turns * 2);
                timer.Start();
            }
        }

        private void CheckEnemyHP()
        {
            if(boss.HP == 0)
            {
                _state.Music.Stop();

                MessageBox.Show("Dungeon complete.");

                GetBossLoot();

                var tiers = _state.Player.Tiers;
                tiers[_state.DungeonType] += (d_tier == tiers[_state.DungeonType]) ? 1 : 0;

                int quantity = _state.Random.Next(3, 5) + members.Count;

                for (int i = 0; i < quantity; i++)
                {
                    int xp = _state.Random.Next(d_tier, d_tier * 2) + d_tier;
                    _state.Player.Weapon.IncreaseXP(xp);
                    _state.Player.Minions.ForEach(m =>
                    {
                        m.IncreaseXP(xp);
                        m.Weapon.IncreaseXP(xp);
                    });
                }
                    
                _state.Player.Wallet.AddDellenCoin(_state.Random.Next(1200, 1501));

                RunAway();
            }
            else
            {
                UpdateEnemyHealth();
            }
            
        }

        private void GetBossLoot()
        {
            for(int i = 0; i < _state.Random.Next(3,5); i++)
                dgh.DistributeLoot(boss);
        }

        private void UpdateEnemyHealth()
        {
            // set the values for the subbars again
            bc.SetSubBars(boss.HP);
            int s = 0;
            // for all subbars greater than what's supposed to be visible, reduce their value to 0
            foreach(ProgressBar sub in subbars)
                if(s++ >= bc.subbars)
                    sub.Value = 0;
            bossBar.Value = bc.baseBar;
        }

        private void UpdateLog(string log)
        {
            CombatLog.AppendText(log);
            CombatLog.AppendText(Environment.NewLine);
            CombatLog.AppendText(Environment.NewLine);
        }

        private void DungeonGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgh.IsPlayerTurn())
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        if (Skills.SelectedItem.ToString().Contains(" Weapon"))
                            UseWeapon();
                        else
                            UseSelectedSkill();
                        break;
                }
            }

        }

        private void enemyIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnemyIndexGUI eigui = new EnemyIndexGUI(_state.Player.EnemyIndex);
            eigui.StartPosition = FormStartPosition.Manual;
            eigui.Location = Location;
            eigui.ShowDialog();
        }

        private void leftButton_MouseClick(object sender, MouseEventArgs e)
        {
            dgh.PartyMemberLeft();
        }

        private void rightButton_MouseClick(object sender, MouseEventArgs e)
        {
            dgh.PartyMemberRight();
        }
    }
}
