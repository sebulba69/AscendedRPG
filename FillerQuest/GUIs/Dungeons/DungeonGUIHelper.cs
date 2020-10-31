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
        private IDungeon _dungeon;
        private DGPComponents _dgc;
        private DungeonHandlers _dh;
        private int currentFighter, currentEnemy;
        private List<BattleMember> battleMembers;
        private const int FULL = 2;
        private const int HALF = 1;
        public DungeonGUIHelper(FormState state, IDungeon dungeon)
        {
            _state = state;
            _state.Player.Stats = new BattleStats();
            _dungeon = dungeon;
            currentFighter = 0;
            currentEnemy = 0;
            battleMembers = new List<BattleMember>();
            _dh = new DungeonHandlers(state);
        }

        public void Start()
        {
            PopulateBattleMembers(battleMembers);

            _dgc = _dungeon.GetDGPComponents();

            InitializePlayerPassives();
            InitializeHPAndTurns();
            SetCurrentFighter();
            UpdateFightCounter();

            _dungeon.SetUpEnemyGUI();
            _dungeon.StartMusic();
        }

        private void InitializeHPAndTurns()
        {
            _dgc.InitializePlayerHealth(_state.Player.GetBattleHP());
            InitializePlayerTurns();
        }

        private void InitializePlayerTurns()
        {
            _dh.SetTurns(_state.Player.GetTurns());
            _dgc.SetTurnText(_dh.GetTurnString());
        }

        private void InitializePlayerPassives()
        {
            var buffs = _state.Player.Set.GetListOfSkillType(SkillType.PASSIVE_BUFF);
            var voids = _state.Player.Set.GetListOfSkillType(SkillType.PASSIVE_VOID);

            if (buffs != null)
                buffs.ForEach(b => _state.Player.Stats.stats[b.Stat] += b.Multiplier);

            if (voids != null)
                voids.ForEach(v => _state.Player.Stats.elementalRes[v.Stat] += v.Multiplier);
        }

        private void PopulateBattleMembers(List<BattleMember> bm)
        {
            var skills = new List<Skill>();
            skills.AddRange(_state.Player.Set.GetListOfSkillType(SkillType.OFFENSIVE));
            skills.AddRange(_state.Player.Set.GetListOfSkillType(SkillType.HEALING));
            bm.Add(MakeBattleMember(_state.Player.Name, _state.Player.Picture, skills, _state.Player.Weapon));
            _state.Player.Minions.ForEach(m => 
            {
                if(m.IsEquipped)
                    bm.Add(MakeBattleMember(m.NameString(), m.Image, m.Skills, m.Weapon));
            });
        }

        private void UpdateFightCounter()
        {
            _dgc.SetCurrentFight(_dh.GetCurrentFights());
            _dgc.SetRemainingFights(_dh.GetRemainingFights());
        }

        private BattleMember MakeBattleMember(string name, string image, List<Skill> skills, Weapon weapon) => new BattleMember() { Name = name, Image = image, Skills = skills, Weapon = weapon };

        // move left = -1
        // move right = +1
        public void ChangeCurrentBattler(int value)
        {
            if (currentFighter + value < 0)
                currentFighter = 0;
            else if (currentFighter + value > battleMembers.Count - 1)
                currentFighter = battleMembers.Count - 1;
            else
                currentFighter += value;

            SetCurrentFighter();
        }

        private void SetCurrentFighter()
        {
            var current = battleMembers[currentFighter];
            _dgc.SetPlayerName(current.Name);
            _dgc.SetPicture(current.Image);
            _dgc.UpdateSkillBoxSkills(current);
        }

        public int SelectTarget() => _dgc.FindTarget();

        public void UseSelected(Enemy target, int t)
        {
            // Are we selecting an item that isn't the "~ Skills ~" header?
            if(_dgc.IsSelectable())
            {
                var bm = battleMembers[currentFighter];
                if (_dgc.IsWeapon()) // If it is selectable, then are we selecting a weapon?
                    UseWeapon(bm, target, t); // Use weapon
                else
                    UseSkillPlayer(bm, target, t); // Use skill
            }

        }

        private void UseSkillPlayer(BattleMember bm, Enemy target, int t)
        {
            var skill = _dgc.GetSelectedSkill();
            string result = "";
            if (skill != null)
            {
                switch(skill.S_Type)
                {
                    case SkillType.OFFENSIVE_BUFF:
                        if (_state.Player.Stats.CanBuff(skill.Stat))
                        {
                            result = $"{bm.Name} used {skill.Name} and buffed their party.";
                            _state.Player.Stats.stats[skill.Stat] += skill.Multiplier;
                            ReduceTurns(FULL);
                        }
                        else
                        {
                            result = "You can't buff that stat any further.";
                            MessageBox.Show(result);
                        }
                        _dgc.UpdateCombatLog(result);
                        CheckTurnEnd();
                        break;
                    case SkillType.HEALING:
                        _dgc.ReducePlayerHealth(skill.GetDamage() * -1);
                        ReduceTurns(FULL);
                        result = $"{bm.Name} used {skill.Name} and healed for {skill.GetDamage()} HP";
                        _dgc.UpdateCombatLog(result);
                        CheckTurnEnd();
                        break;
                    default:
                        result = _dh.GetSkillResult(bm.Name, _state, skill, target);
                        
                        if (result.Contains("critical") || result.Contains("weakness"))
                            ReduceTurns(HALF);
                        else
                            ReduceTurns(FULL);

                        _dgc.UpdateCombatLog(result);

                        ProcessDamage(target, t);

                        break;
                }
                
            }
        }

        private void UseWeapon(BattleMember bm, Enemy target, int t)
        {
            var weapon = bm.Weapon;
            int damage = 0;
            string log = "";
            switch (weapon.Style)
            {
                case WeaponStyle.LIFESTEAL:
                    if (_dh.CanUseNIcons(2))
                    {
                        ReduceTurns(FULL * 2);
                        damage = (weapon.Damage + _state.Player.Stats.stats[Stat.ATTACK]) / 2;
                        log = _dh.GetWeaponResult(bm.Name, damage, _state, target);

                        if (!log.Contains("missed"))
                        {
                            _dgc.ReducePlayerHealth(damage * -1); // we want to heal, so we make dmg negative
                            log += $" {bm.Name} healed everyone for {damage} HP!";
                        }

                        ProcessDamage(target, t);
                    }
                    else
                    {
                        log = "Not enough icons to use this skill.";
                        MessageBox.Show(log);
                    }

                    break;
                case WeaponStyle.PARRY:
                    if (_dh.CanUseNIcons(2) && !_state.Player.Stats.isParryState)
                    {
                        _state.Player.Stats.isParryState = true;
                        log = $"Player team assumes a parry stance!";
                        ReduceTurns(FULL*2);
                        CheckTurnEnd();
                    }
                    else
                    {
                        MessageBox.Show("You either don't have enough turns or are already in a parry stance.");
                    }
                    break;
                default:
                    log = _dh.GetWeaponResult(bm.Name, weapon.Damage, _state, target);
                    ReduceTurns(FULL);
                    _dgc.UpdateCombatLog(log);
                    ProcessDamage(target, t);
                    break;
            }

        }

        private void ReduceTurns(int amount)
        {
            _dh.DecrementTurns(amount);
            _dgc.SetTurnText(_dh.GetTurnString());
        }

        private void ProcessDamage(Enemy target, int t)
        {
            _dungeon.UpdateEnemyHealth();
            if (target.HP == 0)
            {
                if (!_dungeon.IsTroopDead())
                {
                    // disable current checked button and check a new button
                    SetTargetButtonEnabled(t, false);
                    ChangeTargetButtonChecked();
                    CheckTurnEnd();
                }
                else
                {
                    // distribute loot
                    _dungeon.DistributeLoot();

                    // increment fight counters
                    _dh.IncrementFightCounter();
                    if (_dh.GetFightCounter() >= 0)
                    {
                        UpdateFightCounter(); // update fight counter
                        _state.Player.Wallet.AddDellenCoin(_state.Random.Next(100, 201) * _dh.GetFightCounter() * (_state.DungeonType+1) * (_state.Player.Minions.Count+1)); // get paid for last fight
                        _dungeon.SetUpEnemyGUI(); // load another set of fighters if we still have more fights left
                        InitializeHPAndTurns(); // reset the HP to maxg
                    }
                    else
                    {
                        // end the dungeon
                        _state.Music.Stop();
                        if(_state.DungeonType == Enemies.DungeonType.FINAL)
                        {
                            string[] d = {
                                "The time has come.",
                                "You have slain the Ascended God, Rickeus Martineus.",
                                "You truly are a gamer.",
                                $"Now, the world will fear the wrath of {_state.Player.Name}",
                                "If you take a screencap of this dialog box, you may even end up in the RPGMaker game!!!!",
                                "Anyway, that's all the content I have for you.",
                                "You will not get anything new beyond this point so that's about it.",
                                "This is the end.",
                                "Goodbye."
                            };

                            DialogBox db = new DialogBox(d);
                            db.StartPosition = FormStartPosition.Manual;
                            db.Location = _state.Location;
                            db.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Dungeon Complete.");
                            _state.ProcessCompletedTier(battleMembers.Count);
                            if (_state.dungeonTiers[_state.DungeonType] == _state.GetCap(_state.DungeonType))
                                _state.Player.CompletionTracker.Add(true);
                        }

                        _dungeon.CloseGUI();
                    }
                }
            }
            else
            {
                // the target is not dead, we need to check the turns
                _dgc.SetTurnText(_dh.GetTurnString());
                // if we're out of turns, start timer
                CheckTurnEnd();
            }
        }

        private void CheckTurnEnd()
        {
            if (_dh.GetIsTurnEnd())
            {
                _dh.SetTurns(_dungeon.GetEnemyTurns());
                _dgc.StartTimer();
                _dgc.SetUseSkillButtonEnabled(false);
            }
        }

        public Enemy GetNextEnemy(Enemy[] troop)
        {
            Enemy enemy = troop[currentEnemy];

            while (enemy == null || enemy.HP <= 0)
            {
                currentEnemy = (currentEnemy + 1 == troop.Length) ? 0 : currentEnemy + 1;
                enemy = troop[currentEnemy];
            }
            
            return enemy;
        }

        public void HandleEnemyTurn(Enemy attacker)
        {
            if(_state.Random.Next(0, 100) < 85)
            {
                var skill = attacker.Skills[_state.Random.Next(0, attacker.Skills.Count)];

                int damage = skill.GetDamage() - _state.Player.Stats.elementalRes[skill.Element];

                string parry = "";

                if(_state.Player.Stats.isParryState)
                {
                    _state.Player.Stats.isParryState = false;
                    _state.Player.Stats.isParried = true;
                    damage /= 2;
                    parry = " Player parried the attack!";
                }

                _dgc.ReducePlayerHealth(damage);

                _dgc.UpdateCombatLog($"{attacker.Name} used {skill.Name}. It hit for {damage}." + parry);

                if (_dgc.IsPlayerDead())
                {
                    _dgc.StopTimer();
                    _state.Music.Stop();
                    MessageBox.Show("You died.");
                    _dungeon.CloseGUI();
                }
                else
                {
                    if(_dh.GetIsTurnEnd())
                    {
                        _dgc.StopTimer();
                        InitializePlayerTurns();
                        _dgc.SetUseSkillButtonEnabled(true);
                    }
                    else
                    {
                        _dh.DecrementTurns(FULL);
                        _dgc.SetTurnText(_dh.GetTurnString());
                    }
                }
            }
            else
            {
                _dh.DecrementTurns(FULL);
                _dgc.UpdateCombatLog($"{attacker.Name} attacked and missed!");
            }
        }

        public void SetTargetButtonEnabled(int index, bool value) => _dgc.SetTargetEnabled(index, value);
        public void ChangeTargetButtonChecked() => _dgc.FindNextEnabled();
        public Enemy[] MakeTroop() => _dh.GetTroop();
        public Enemy MakeBoss() => _dh.GetBoss();
        public void DistributeLoot(Enemy e) => _dh.DistributeLoot(e, _state);
        public void LogEnemy(Enemy e, bool isBoss) => _dh.LogEnemyIntoIndex(e, _state, isBoss);
    }
}
