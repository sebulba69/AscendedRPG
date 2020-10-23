using AscendedRPG;
using AscendedRPG.GUIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    public class ActionHandler
    {
        private TurnPress tp;
        public bool pt;

        public ActionHandler()
        {
            tp = new TurnPress();
            pt = true;
        }

        public string UseSkillPlayer(string name, Skill skill, FormState state, Enemy target)
        {
            var stats = state.Player.Stats;
            int damage = skill.GetDamage() + stats.stats[Stat.ATTACK] + state.Player.ElementalAttack[skill.Element];
            var result = GetDamage(state, name, stats, damage, target, skill.Name);

            if (!result[0].Contains("missed!"))
            {
                damage = Int32.Parse(result[1]);
                
                if (target.Weakness.Contains(skill.Element))
                {
                    state.Player.ProcessWeakness(target, skill.Element);
                    result[0] += $"The enemy's weakness was struck! ";
                    damage *= 2;
                    if (!result[0].Contains("critical hit!"))
                        tp.HalfTurn();
                }

                if (!result[0].Contains("critical hit!") && !result[0].Contains("weakness was"))
                    tp.FullTurn();

                result[0] += $"{damage} damage dealt.";
                DamageEnemy(target, damage);
            }

            return result[0];
        }

        public string UseWeaponPlayer(string name, int dmg, FormState state, Enemy target)
        {
            var stats = state.Player.Stats;
            dmg += state.Player.Stats.stats[Stat.ATTACK];
            var result = GetDamage(state, name, stats, dmg, target, "their weapon");
            
            if (!result[0].Contains("missed!"))
            {
                int damage = Int32.Parse(result[1]);
                result[0] += $"{damage} damage dealt.";
                DamageEnemy(target, damage);

                if (!result[0].Contains("critical hit"))
                    tp.FullTurn();
            }

            return result[0];
        }

        private string[] GetDamage(FormState state, string name, BattleStats bstats, int damage, Enemy target, string attackName)
        {
            string[] result = new string[] { "", "" };
            Random r = state.Random; // Random pointer
            Player p = state.Player;

            if (IsHit(r))
            {
                
                // get brief damage boost after initial parry
                
                if (p.Stats.isParried)
                {
                    p.Stats.isParried = false;
                    damage *= 2;
                }

                result[0] = $"{name} used {attackName}! ";
                int crit = GetDamageFromCrit(damage, bstats.stats[Stat.CRITS], r);

                if (crit > damage)
                {
                    result[0] += "It was a critical hit! ";
                    damage = crit;
                }

                result[1] = damage.ToString();
            }
            else
            {
                tp.Miss();
                result[0] = $"{name} used {attackName} and missed!";
                result[1] = 0.ToString();
            }
            return result;
        }

        #region Private Functions for Repeated Processes
        private bool IsHit(Random r)
        {
            return r.Next(0, 100) < 95;
        }

        private int GetDamageFromCrit(int damage, int critStat, Random r)
        {
            if (r.Next(0, 100) < 35)
            {
                damage *= 2;
                damage += critStat;
                tp.HalfTurn();
            }

            return damage;
        }

        public void DamageEnemy(Enemy target, int damage)
        {
            target.HP = (target.HP - damage >= 0) ? target.HP - damage : 0;
        }

        #endregion

        public int GetIcons() => tp.GetIcons();

        public void FullTurn() => tp.FullTurn();

        public void Miss() => tp.Miss();

        public void SetTurns(int t) => tp.SetTurns(t);

        public string GetTurns() => tp.PrintIcons();

        public bool IsTurnEnd() => tp.turnEnd;
    }
}
