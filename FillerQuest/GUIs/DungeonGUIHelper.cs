using AscendedRPG.LootClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public class DungeonGUIHelper
    {
        private FormState _state;
        private ListBox Skills;
        private TextBox NameBox, CurrentFight, FightsLeft, TurnBox, CombatLog;
        private Button UseSkillButton;
        private PictureBox ProfilePic;
        private ProgressBar PlayerHealth;
        private List<BattleMember> members;
        private ActionHandler ah;
        private LootHandler lh;
        private int currentFighter, d_tier;
        private Dungeon d;
        private bool isPlayerDead;

        public DungeonGUIHelper(FormState state, ListBox skills, TextBox name, PictureBox prof, ProgressBar ph, TextBox cfight, TextBox rfight, Dungeon dungeon, TextBox turns, Button usb, TextBox cl, int dt)
        {
            // textboxes
            NameBox = name;
            CurrentFight = cfight;
            FightsLeft = rfight;
            TurnBox = turns;
            CombatLog = cl;

            // buttons
            UseSkillButton = usb;

            // ints
            currentFighter = 0;
            d_tier = dt;

            // misc
            isPlayerDead = false;
            d = dungeon;
            ah = new ActionHandler();
            lh = new LootHandler();
            _state = state;
            Skills = skills;
            ProfilePic = prof;
            PlayerHealth = ph;
            members = new List<BattleMember>();
        }

        public void SetUp()
        {
            PopulateBattleMembers();
            PopulateSkillList(members[currentFighter]);
            SetUpPlayerHealth();
            UpdateCurrentFights();
            RegisterPlayerPassives();
            ah.SetTurns(_state.Player.GetTurns() + _state.Player.Stats.stats[Stat.TURNS]);
            TurnBox.Text = ah.GetTurns();
        }

        private void PopulateBattleMembers()
        {
            var bm = new BattleMember()
            {
                Name = _state.Player.Name,
                Image = _state.Player.Picture,
                Skills = _state.Player.Set.GetListOfSkillType(SkillType.OFFENSIVE),
                Weapon = _state.Player.Weapon
            };

            members.Add(bm);

            _state.Player.Minions.ForEach(m =>
            {
                if (m.IsEquipped)
                {
                    var minionMember = new BattleMember()
                    {
                        Name = m.NameString(),
                        Image = m.Image,
                        Skills = m.Skills,
                        Weapon = m.Weapon
                    };

                    members.Add(minionMember);
                }

            });
        }

        private void PopulateSkillList(BattleMember bm)
        {
            Skills.Items.Clear();
            var sorted = bm.Skills.OrderBy(x => x.CalculateDamage(x.Damage, x.Multiplier)).Reverse();
            Skills.Items.Add("~ Skills ~");
            Skills.Items.AddRange(sorted.ToArray());
            Skills.Items.Add(bm.Weapon.DisplayString());
            NameBox.Text = bm.Name;
            ProfilePic.ImageLocation = bm.Image;
        }

        private void SetUpPlayerHealth()
        {
            PlayerHealth.Maximum = _state.Player.GetHP() + _state.Player.Set.TotalDef + _state.Player.Stats.stats[Stat.DEFENSE];
            PlayerHealth.Value = PlayerHealth.Maximum;
        }

        private void RegisterPlayerPassives()
        {
            _state.Player.Stats = new BattleStats();
            var buffs = _state.Player.Set.GetListOfSkillType(SkillType.PASSIVE_BUFF);
            var voids = _state.Player.Set.GetListOfSkillType(SkillType.PASSIVE_VOID);
            foreach (Skill b in buffs) _state.Player.Stats.stats[b.Stat] += b.Multiplier;
            foreach (Skill v in voids) _state.Player.Stats.elementalRes[v.Element] += v.Multiplier;
        }

        public void PartyMemberRight()
        {
            currentFighter += (currentFighter + 1 < members.Count) ? 1 : 0;
            PopulateSkillList(members[currentFighter]);
        }

        public void PartyMemberLeft()
        {
            currentFighter -= (currentFighter - 1 >= 0) ? 1 : 0;
            PopulateSkillList(members[currentFighter]);
        }

        public void UpdateCurrentFights()
        {
            CurrentFight.Text = $"Current Fight: {d.GetCurrentFight()}";
            FightsLeft.Text = $"Remaining Fights: {d.GetFights()}";
        }

        public void EnemyAttackPlayer(Enemy enemy)
        {
            int h = _state.Random.Next(0, 100);
            if (h < 85)
            {
                var skill = enemy.Skills[_state.Random.Next(0, enemy.Skills.Count)];
                int damage = skill.Damage;
                damage -= _state.Player.Stats.elementalRes[skill.Element];

                if (_state.Player.Stats.isParryState)
                {
                    _state.Player.Stats.isParried = true;
                    _state.Player.Stats.isParryState = false;
                    damage = damage / 2;
                    UpdateLog($"{enemy.Name} used {skill.Name} and got parried! It hit for only {damage} dmg!");
                }
                else
                {
                    UpdateLog($"{enemy.Name} used {skill.Name} and hit for {damage} dmg!");
                }

                IsPlayerDead(damage);
            }
            else
            {
                UpdateLog($"{enemy} attacked and missed!");
                ah.Miss();
            }
        }

        private void IsPlayerDead(int damage)
        {
            if (PlayerHealth.Value - damage <= 0)
            {
                PlayerHealth.Value = 0;
                isPlayerDead = true;
            }
            else if (PlayerHealth.Value - damage >= PlayerHealth.Maximum)
                PlayerHealth.Value = PlayerHealth.Maximum;
            else
                PlayerHealth.Value -= damage;
        }

        public bool GetIsPlayerDead() => isPlayerDead;

        public bool IsTurnEndEnemy()
        {
            if (ah.IsTurnEnd())
            {
                ah.pt = true;
                UseSkillButton.Enabled = true;
                ah.SetTurns(_state.Player.GetTurns() + _state.Player.Stats.stats[Stat.TURNS]);
                ProcessTurnBox();
                return true;
            }
            else
            {
                return false;
            }

        }

        public void UseSelectedSkill(Enemy enemy)
        {
            var c = members[currentFighter];
            var skill = Skills.SelectedItem as Skill;
            if (skill.S_Type == SkillType.OFFENSIVE)
            {
                UpdateLog(ah.UseSkillPlayer(c, skill, _state, enemy));
            }
            else if (skill.S_Type == SkillType.OFFENSIVE_BUFF)
            {
                if (_state.Player.Stats.CanBuff(skill.Stat))
                {
                    _state.Player.Stats.stats[skill.Stat] += skill.Multiplier;
                    if (skill.Stat == Stat.DEFENSE)
                        PlayerHealth.Maximum = _state.Player.GetHP() + _state.Player.Set.TotalDef + _state.Player.Stats.stats[Stat.DEFENSE];
                    UpdateLog($"{c.Name} buffed everyone!");
                    ah.FullTurn();
                }
                else
                {
                    MessageBox.Show("You can't buff that stat any more!");
                }

            }
            else // it's a healing spell
            {
                PlayerHealth.Value = (PlayerHealth.Value + skill.Multiplier > PlayerHealth.Maximum) ? PlayerHealth.Maximum : PlayerHealth.Value + skill.Multiplier;

                UpdateLog($"{c.Name} healed everyone!");

                ah.FullTurn();
            }
            ProcessTurnBox();
        }

        public void UseWeapon(Enemy target)
        {
            try
            {
                var c = members[currentFighter];
                var weapon = c.Weapon;
                int damage = 0;
                string log = "";
                switch (weapon.Style)
                {
                    case WeaponStyle.LIFESTEAL:
                        if (ah.GetIcons() >= 2)
                        {
                            ah.FullTurn(); // costs 2 turns (1 and 1/2 if you crit)
                            damage = (weapon.Damage + _state.Player.Stats.stats[Stat.ATTACK]) / 2;
                            log = ah.UseWeaponPlayer(c, damage, _state, target);

                            if (!log.Contains("missed"))
                            {
                                PlayerHealth.Value = (PlayerHealth.Value + damage > PlayerHealth.Maximum) ?
                                                            PlayerHealth.Maximum :
                                                            PlayerHealth.Value + damage;

                                UpdateLog($"{c.Name} healed everyone for {damage} HP!");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Not enough icons to use this skill.");
                        }

                        break;
                    case WeaponStyle.PARRY:
                        if (ah.GetIcons() >= 2 && !_state.Player.Stats.isParryState)
                        {
                            _state.Player.Stats.isParryState = true;
                            for (int i = 0; i < 2; i++)
                                ah.FullTurn();
                            UpdateLog($"Player team assumes a parry stance!");
                        }
                        else
                        {
                            MessageBox.Show("You either don't have enough turns or are already in a parry stance.");
                        }
                        break;
                    default:
                        log = ah.UseWeaponPlayer(c, weapon.Damage, _state, target);
                        break;
                }

                if (log != "")
                    UpdateLog(log);

                ProcessTurnBox();
            }
            catch (NullReferenceException) { }
        }

        private void ProcessTurnBox()
        {
            TurnBox.Text = ah.GetTurns();
        }

        public void ContinueEnemyTurn()
        {
            ah.FullTurn();
        }

        public bool TurnCheck()
        {
            return ah.IsTurnEnd();
        }

        public void EndPlayerTurn(int turns)
        {
            ah.pt = false;
            UseSkillButton.Enabled = false;
            ah.SetTurns(turns);
        }

        public void LoadNextFight()
        {
            ah.SetTurns(_state.Player.GetTurns() + _state.Player.Stats.stats[Stat.TURNS]);
            ah.pt = true;
            ProcessTurnBox();
        }

        public bool IsPlayerTurn() => ah.pt;

        public void DistributeLoot(Enemy e)
        {
            if (e.Name.Contains("Pot of"))
            {
                lh.GetRecipeDrop(d_tier, _state.DungeonType, _state.Player.Loot.Recipes, _state.Random);
            }
            else if (e.Name.Contains("Minion"))
            {
                _state.Player.Wallet.MinionShards++;
            }
            else
            {
                var loot = lh.GetEnemyDrop(e.Name, _state.Random, d_tier);
                var eLoot = _state.Player.Loot.EnemyLoot; // make pointer to list so we can check it easily
                var l = eLoot.Find(x => x.GetName().Equals(loot.GetName()));

                if (l == null)
                    eLoot.Add(loot);
                else
                    l.Quantity += loot.Quantity;

            }
            LogEnemyIntoIndex(e);
        }

        private void LogEnemyIntoIndex(Enemy enemy)
        {
            var e_index = _state.Player.EnemyIndex;
            if (e_index.ContainsKey(enemy.Name))
            {
                var key = e_index[enemy.Name];
                key.Tier = (key.Tier < d_tier) ? d_tier : key.Tier;
            }
            else
            {
                var e_index_val = new EIndexEntry()
                {
                    Name = enemy.Name,
                    DType = _state.DungeonType,
                    Image = enemy.Image,
                    Tier = d_tier,
                    IsBoss = false
                };

                e_index.Add(enemy.Name, e_index_val);
            }
            _state.Save.SaveGame(_state.Player);
        }

        private void UpdateLog(string log)
        {
            CombatLog.AppendText(log);
            CombatLog.AppendText(Environment.NewLine);
            CombatLog.AppendText(Environment.NewLine);
        }
    }
}
