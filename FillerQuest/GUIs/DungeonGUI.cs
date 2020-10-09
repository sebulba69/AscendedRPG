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
    public partial class DungeonGUI : Form
    {
        private List<PictureBox> enemyBoxes;
        private List<ProgressBar> enemyBars;
        private List<TextBox> enemyNames;
        private Enemy[] troop;
        private RadioButton[] targets;
        private FormState _state;
        private Dungeon d;
        private int current;
        private bool endingDungeon, loading;
        private int d_tier;
        private List<BattleMember> members;
        private DungeonGUIHelper dgh;

        public DungeonGUI(FormState state)
        {
            endingDungeon = false;
            loading = false;
            _state = state;
            enemyBoxes = new List<PictureBox>();
            enemyBars = new List<ProgressBar>();
            enemyNames = new List<TextBox>();
            targets = new RadioButton[3];
            current = 0;
            d_tier = _state.dungeonTiers[_state.DungeonType];
            d = new Dungeon(d_tier, _state.DungeonType);
            members = new List<BattleMember>();
            InitializeComponent();
        }

        private void DungeonGUI_Load(object sender, EventArgs e)
        {
            Text = $"Tier {d_tier} Dungeon";

            // set up the lists here since we need to reuse "SetUpEnemyGUI" later
            enemyBoxes.Add(EnemyPic1); enemyBoxes.Add(EnemyPic2); enemyBoxes.Add(EnemyPic3);
            enemyBars.Add(EnemyBar1); enemyBars.Add(EnemyBar2); enemyBars.Add(EnemyBar3);
            enemyNames.Add(EnemyBox1); enemyNames.Add(EnemyBox2); enemyNames.Add(EnemyBox3);
            targets[0] = Target1; targets[1] = Target2; targets[2] = Target3;

            _state.Music.SetFloorSong(d_tier);
            _state.Music.PlayFloorSong();
            _state.Player.Stats = new BattleStats();

            SetUpEnemyGUI();

            dgh = new DungeonGUIHelper(_state, Skills, NameBox, 
                ProfilePic, PlayerHealth, CurrentFight, 
                FightsLeft, d, TurnBox, UseSkillButton, 
                CombatLog, d_tier);

            dgh.SetUp();

            FindFirstAliveTarget();
        }

        private void SetUpEnemyGUI()
        {
            loading = true;
            troop = d.MakeEnemyTroop(_state.DungeonType, (int)Math.Pow(d_tier, _state.DungeonType + 1), _state.Random);

            for (int i = 0; i < troop.Length; i++)
            {
                if (troop[i] != null)
                {
                    enemyNames[i].Text = troop[i].Name + $" [{_state.Player.GetWeaknessString(troop[i], _state.SManager)}]";
                    enemyBoxes[i].ImageLocation = troop[i].Image;
                    enemyBars[i].Maximum = troop[i].HP;
                    enemyBars[i].Value = enemyBars[i].Maximum;
                    targets[i].Enabled = true;
                }
                else
                {
                    enemyNames[i].Clear();
                    enemyBoxes[i].ImageLocation = null;
                    enemyBars[i].Value = 0;
                    targets[i].Enabled = false;
                }
            }
            loading = false;
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Retreating from dungeon...");
            RunAway();
        }

        private void RunAway()
        {
            endingDungeon = true;
            _state.Music.Stop();
            _state.Save.SaveGame(_state.Player);
            _state.Type = FTypes.INVENTORY;
            _state.Location = Location;
            Close();
        }

        private void DungeonGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_state.Type == FTypes.DUNGEON_GUI)
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
            if(!endingDungeon)
            {
                var enemy = GetNextEnemy();
                dgh.EnemyAttackPlayer(enemy);
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
            else
            {
                timer.Stop();
            }

        }

        private void FindFirstAliveTarget()
        {
            for(int i = 0; i < troop.Length; i++)
            {
                if(troop[i] != null && troop[i].HP > 0)
                {
                    targets[i].Checked = true;
                    break;
                }
            }
        }

        private Enemy GetNextEnemy()
        {
            var enemy = this.troop[current];

            current = (current + 1 >= this.troop.Length) ? 0 : current + 1;

            if (enemy == null || enemy.HP == 0)
                return GetNextEnemy();
            else
                return enemy;
        }

        private Enemy FindTarget()
        {
            Enemy target = null;
            for(int i = 0; i < targets.Length; i++)
            {
                if (targets[i].Checked)
                {
                    target = troop[i];
                    break;
                }
                    
            }
            return target;
        }

        private void UseSelectedSkill()
        {
            try
            {
                var target = FindTarget();
                dgh.UseSelectedSkill(target);
                ProcessLog(target);
                for (int i = 0; i < targets.Length; i++)
                    if (troop[i] != null)
                        enemyNames[i].Text = troop[i].Name + $" [{_state.Player.GetWeaknessString(troop[i], _state.SManager)}]";

                TurnCheck();
            }
            catch (NullReferenceException) { }
        }

        private void UseWeapon()
        {
            try
            {
                var target = FindTarget();
                dgh.UseWeapon(target);
                ProcessLog(target);
                TurnCheck();
            }
            catch (NullReferenceException) { }
        }

        private void TurnCheck()
        {
            if (dgh.TurnCheck())
            {
                int t = 0;
                foreach (Enemy e in troop)
                {
                    if (e != null && e.HP > 0)
                        t += (e.Turns * 2);
                }

                dgh.EndPlayerTurn(t);
                current = 0;
                timer.Start();
            }
        }

        private void ProcessLog(Enemy enemy)
        {
            CheckEnemyHP();
            if (enemy.HP == 0)
            {
                FindFirstAliveTarget();
            }
        }

        private void CheckEnemyHP()
        {
            // count who is dead and who is present
            int dead = 0;
            int present = 0;

            for(int i = 0; i < troop.Length; i++)
            {
                if(troop[i] != null)
                {
                    present++;
                    if (troop[i].HP == 0)
                    {
                        dead++;
                        targets[i].Enabled = false;
                    }  
                }
            }

            // if all present fighters are dead, load next fight
            if (dead == present)
            {
                DistributeEnemyLoot();
                NextFight();
            }
            else
            {
                UpdateEnemyHealth();
            }
            
        }

        private void UpdateEnemyHealth()
        {
            for(int i = 0; i < troop.Length; i++)
            {
                if(troop[i] != null)
                {
                    enemyBars[i].Value = troop[i].HP;
                }
            }
        }

        private void NextFight()
        {
            if(d.IsDungeonComplete())
            {
                endingDungeon = true;

                _state.Music.Stop();

                MessageBox.Show("Dungeon complete.");

                int quantity = _state.Random.Next(3, 5) + members.Count;

                var tiers = _state.Player.Tiers;
                tiers[_state.DungeonType] += (d_tier == tiers[_state.DungeonType]) ? 1 : 0;

                for (int i = 0; i < quantity; i++)
                {
                    int xp = _state.Random.Next(d_tier, d_tier * 2) + d_tier;
                    _state.Player.Weapon.IncreaseXP(xp);
                    _state.Player.Minions.ForEach(m =>
                    {
                        m.IncreaseXP(xp + _state.Random.Next(100,201));
                        m.Weapon.IncreaseXP(xp + 200);
                    });
                }

                _state.Player.Wallet.AddDellenCoin(_state.Random.Next(1000,2001));

                RunAway();
            }
            else
            {
                d.LoadNextFight();
                dgh.UpdateCurrentFights();
                PlayerHealth.Value = PlayerHealth.Maximum;
                SetUpEnemyGUI();
                FindFirstAliveTarget();
                dgh.LoadNextFight();
                _state.Player.Wallet.AddDellenCoin(_state.Random.Next(100, 201) * d.GetCurrentFight());
            }
        }

        private void DistributeEnemyLoot()
        {
            // get specific loot from enemies
            foreach (Enemy e in troop)
                if (e != null)
                    dgh.DistributeLoot(e);
        }

        private void UpdateLog(string log)
        {
            CombatLog.AppendText(log);
            CombatLog.AppendText(Environment.NewLine);
            CombatLog.AppendText(Environment.NewLine);
        }

        private void DungeonGUI_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (dgh.IsPlayerTurn() && !endingDungeon && !loading)
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
            catch (NullReferenceException) { }
        }

        private void rightButton_MouseClick(object sender, MouseEventArgs e)
        {
            dgh.PartyMemberRight();
        }

        private void leftButton_MouseClick(object sender, MouseEventArgs e)
        {
            dgh.PartyMemberLeft();
        }

        private void enemyIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnemyIndexGUI eigui = new EnemyIndexGUI(_state.Player.EnemyIndex);
            eigui.StartPosition = FormStartPosition.Manual;
            eigui.Location = Location;
            eigui.ShowDialog();
        }
    }
}
