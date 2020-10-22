using AscendedRPG.LootClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG.GUIs
{
    public class DungeonHandlers
    {
        private ActionHandler _ah;
        private LootHandler _lh;
        private Dungeon _d;

        public DungeonHandlers(FormState state)
        {
            _ah = new ActionHandler();
            _lh = new LootHandler();
            _d = new Dungeon(state.dungeonTiers[state.DungeonType], state.DungeonType, state.Random);
        }

        public void DistributeLoot(Enemy e, FormState state)
        {
            if (e.Name.Contains("Pot of"))
            {
                _lh.GetRecipeDrop(state.dungeonTiers[state.DungeonType],
                    state.DungeonType,
                    state.Player.Loot.Recipes,
                    state.Random);
            }
            else if (e.Name.Contains("Minion"))
            {
                state.Player.Wallet.MinionShards++;
            }
            else
            {
                var loot = _lh.GetEnemyDrop(e.Name, state.Random, state.dungeonTiers[state.DungeonType]);
                var eLoot = state.Player.Loot.EnemyLoot; // make pointer to list so we can check it easily
                var l = eLoot.Find(x => x.GetName().Equals(loot.GetName()));

                if (l == null)
                    eLoot.Add(loot);
                else
                    l.Quantity += loot.Quantity;
            }
        }

        public void LogEnemyIntoIndex(Enemy enemy, FormState state, bool isBoss)
        {
            int d_tier = state.dungeonTiers[state.DungeonType];
            var e_index = state.Player.EnemyIndex;
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
                    DType = state.DungeonType,
                    Image = enemy.Image,
                    Tier = d_tier,
                    IsBoss = isBoss
                };

                e_index.Add(enemy.Name, e_index_val);
            }
            state.Save.SaveGame(state.Player);
        }

        public void SetTurns(int turns) => _ah.SetTurns(turns);
        public void IncrementFightCounter() => _d.LoadNextFight();
        public void DecrementTurns(int value)
        {
            for(int i = 0; i < value; i++)
                _ah.FullTurn();
        } 

        public int GetFightCounter() => _d.GetFights();
        public string GetTurnString() => _ah.GetTurns();
        public string GetCurrentFights() => _d.GetCurrentFight().ToString();
        public string GetRemainingFights() => _d.GetFights().ToString();
        public bool GetIsTurnEnd() => _ah.IsTurnEnd();
        public bool CanUseNIcons(int value) => _ah.GetIcons() >= value;
        public Enemy[] GetTroop() => _d.MakeEnemyTroop();
        public Enemy GetBoss() => _d.MakeBoss();
        public string GetSkillResult(string name, FormState state, Skill skill, Enemy target) => _ah.UseSkillPlayer(name, skill, state, target);
        public string GetWeaponResult(string name, int dmg, FormState state, Enemy target) => _ah.UseWeaponPlayer(name, dmg, state, target);
    }
}
