using AscendedRPG;
using AscendedRPG.Armors;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscendedRPG
{
    [ProtoContract]
    public class Player
    {
        private const int HP = 100; // default HP, gets incremented upon by armor

        private const int TURNS = 8; // default 4 turns (8 half turns = 4 full turns)

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public string Picture { get; set; }

        [ProtoMember(4)]
        public ArmorSet Set { get; set; }

        [ProtoMember(5)]
        public ArmorInventory Inventory { get; set; }

        [ProtoMember(6)]
        public Wallet Wallet { get; set; }

        [ProtoMember(7)]
        public LootHolder Loot { get; set; }

        [ProtoMember(8)]
        public Dictionary<string, HashSet<int>> Weaknesses { get; set; }

        [ProtoMember(9)]
        public Dictionary<string, EIndexEntry> EnemyIndex { get; set; }

        [ProtoMember(10)]
        public List<int> ElementalAttack { get; set; }

        [ProtoMember(11)]
        public Weapon Weapon { get; set; }

        [ProtoMember(12)]
        public int VendorCap { get; set; }

        // 0 -> 6
        // normal, ex, asc, bounty, exbounty, ascbounty, elder
        [ProtoMember(20)]
        public List<int> Tiers { get; set; }

        [ProtoMember(18)]
        public bool HasSeenNotCutscene { get; set; }

        [ProtoMember(33)]
        public List<Enemies.Minion> Minions { get; set; }

        public BattleStats Stats { get; set; } // stats exclusively used in battle

        public Player()
        {
            if(Inventory == null)
                Inventory = new ArmorInventory();

            if(Weaknesses == null)
                Weaknesses = new Dictionary<string, HashSet<int>>();

            if(EnemyIndex == null)
                EnemyIndex = new Dictionary<string, EIndexEntry>();

            if (ElementalAttack == null)
                ElementalAttack = new List<int>(9);

            if (Minions == null)
                Minions = new List<Enemies.Minion>();

            if (VendorCap < 250)
                VendorCap = 250;
        }

        public void ProcessWeakness(Enemy e, int element)
        {
            if(Weaknesses.ContainsKey(e.Name))
            {
                var set = Weaknesses[e.Name];
                if(!set.Contains(element))
                {
                    set.Add(element);
                }
            }
            else
            {
                var set = new HashSet<int>();
                set.Add(element);
                Weaknesses.Add(e.Name, set);
            }
        }

        public string GetWeaknessString(Enemy e, Files.SkillManager sm)
        {
            var str = new StringBuilder();
            if(Weaknesses.ContainsKey(e.Name))
            {
                var set = Weaknesses[e.Name];
                foreach (int w in e.Weakness)
                {
                    if(set.Contains(w))
                        str.Append(sm.ElementToString(w));
                    else
                        str.Append("???");

                    str.Append(", ");
                }
            }
            else
            {
                foreach (int w in e.Weakness)
                    str.Append("???, ");
            }

            string ret_str = str.ToString();
            // "string, " --> 8 chars --> 8 - 2 = 6... string (excludes "right" value)
            return ret_str.Substring(0, ret_str.Length - 2);
        }

        public int GetHP() => HP;

        public int GetBattleHP() => HP + Set.TotalDef + Stats.stats[Stat.DEFENSE];

        public int GetTurns() => TURNS + Stats.stats[Stat.TURNS];

        public int GetLevel()
        {
            int level = Tiers[0];

            // only add up levels higher than 1 so not to confuse the player
            for (int i = 1; i < Tiers.Count; i++)
                if (Tiers[i] > 1)
                    level += Tiers[i];

            return level;
        }

        public int GetVendorCap() => (Tiers[0] < 250) ? Tiers[0] : VendorCap;

    }
}
