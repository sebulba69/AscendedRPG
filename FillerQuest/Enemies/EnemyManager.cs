using AscendedRPG.Enemies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AscendedRPG.Files
{
    public class EnemyManager
    {
        private static readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended/enemies");
        
        private readonly string[] enemies = { "t1e", "t2e", "t3e", "t4e", "t5e", "t6e" };
        
        private readonly string ex_enemies = "ex_enemies";
        private readonly string asc_enemies = "asc_enemies";

        private readonly string recipe_enemies = "recipe_enemies"; 

        private readonly string bosses = "bosses";
        private readonly string ex_bosses = "ex_bosses";
        private readonly string asc_bosses = "asc_bosses";

        private readonly string bountyBosses = "bountyBoss";
        private readonly string ex_bountyBosses = "ex_bountyBoss";
        private readonly string asc_bounty = "asc_bounty";

        private readonly string invaders = "invader";
        private readonly string ex_invaders = "ex_invaders";
        private readonly string asc_invaders = "asc_invaders";

        private readonly string elders = "elderbosses";

        private readonly string minions = "minions";

        private const int ENEMY_CAP = 60;
        private const int EX_CAP = 1000;
        private const int ASC_CAP = 5000;

        public EnemyManager() {}

        public Enemy[] MakeTroop(int dtype, int tier, Random r)
        {
            var troop = new Enemy[3];
            int n = r.Next(1, 4);
            switch(n)
            {
                case 1:
                    troop[1] = MakeEnemy(dtype, tier, r);
                    break;
                case 2:
                    troop[0] = MakeEnemy(dtype, tier, r);
                    troop[2] = MakeEnemy(dtype, tier, r);
                    break;
                case 3:
                    for(int i = 0; i < troop.Length; i++)
                    {
                        troop[i] = MakeEnemy(dtype, tier, r);
                    }
                    break;
            }
            return troop;
        }

        private Enemy MakeEnemy(int dtype, int tier, Random r)
        {
            Enemy enemy;

            bool isRecipe = (r.Next(0, 100) < 10);

            bool isMinion = (!isRecipe && r.Next(0, 100) < 10);

            // if isRecipe, make recipe enemy,
            // else if isMinion, make minion,
            // else make an enemy
            string path;

            if (isRecipe)
                path = recipe_enemies;
            else if (isMinion)
                path = minions;
            else
                path = GetEnemyPath(dtype, tier);

            path = Path.Combine(PATH, path);

            var list = LoadEnemyList(path);

            int index = (isRecipe) ? dtype : r.Next(0, list.Count);

            enemy = GetEnemyClone(list, index);

            int t = tier * (dtype + 1);
            enemy.HP = GetEnemyHP(dtype, t, r);
            enemy.Image = LoadEnemyImage(path, index);

            t += ((int)Math.Pow((dtype + 1), 3));

            enemy.Skills.ForEach(s => SetSkillDamage(dtype+1, s, t, r));

            return enemy;
        }

        private string GetEnemyPath(int dtype, int tier)
        {
            switch(dtype)
            {
                case DungeonType.EX:
                    return ex_enemies;
                case DungeonType.ASCENDED:
                    return asc_enemies;
                default:
                    return enemies[(tier - 1) % enemies.Length];
            }
        }

        private Enemy GetEnemyClone(List<Enemy> list, int pos)
        {
            return (Enemy)list[pos].Clone();
        }

        public Enemy MakeBoss(int dtype, int tier, Random r)
        {
            
            bool invader = (r.Next(0, 100) < 5 && tier >= 50);
            int hp, index;
            int bountyMultiplier = 10;
            string bossPath;
            switch (dtype)
            {
                case DungeonType.EX:
                    hp = EX_CAP;
                    bossPath = (invader) ? ex_invaders : ex_bosses;
                    index = (invader) ? tier - 1 : (tier / 10) - 1;
                    break;
                case DungeonType.ASCENDED:

                    hp = ASC_CAP;
                    bossPath = (invader) ? asc_invaders : asc_bosses;
                    index = (invader) ? tier - 1 : (tier / 10) - 1;
                    break;
                case DungeonType.BOUNTY:
         
                    hp = ENEMY_CAP * bountyMultiplier;
                    bossPath = bountyBosses;
                    index = tier - 1;
                    break;
                case DungeonType.EXBOUNTY:
                    
                    hp = EX_CAP * bountyMultiplier;
                    bossPath = ex_bountyBosses;
                    index = tier - 1;
                    break;
                case DungeonType.ASCBOUNTY:
                    
                    hp = ASC_CAP * bountyMultiplier;
                    bossPath = asc_bounty;
                    index = tier - 1;
                    break;
                case DungeonType.ELDER:
                   
                    hp = ASC_CAP * (bountyMultiplier * 2);
                    bossPath = elders;
                    index = tier - 1;
                    break;
                default:
                    
                    hp = ENEMY_CAP;
                    bossPath = (invader) ? invaders : bosses;
                    index = (invader) ? tier - 1 : (tier / 10) - 1;
                    break;
            }
            List<Enemy> b_list = LoadEnemyList(bossPath);
            
            index = index % b_list.Count;
            
            Enemy boss = (Enemy)b_list[index].Clone();
            
            int t = (tier * (dtype + 1));

            boss.HP = BossHPCalc(t * hp);

            t += ((int)Math.Pow((dtype + 1), 3));

            boss.Skills.ForEach(s => SetSkillDamage(dtype + 1, s, t * (dtype + 1), r));
            boss.Image = LoadEnemyImage(Path.Combine(PATH,bossPath), index);
            return boss;
        }

        public Enemy MakeFinalBoss(int dtype, int tier, Random r)
        {
            Enemy boss = new Enemy();
            boss.Name = "Rickeus Martineus";
            boss.Image = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended/finalBoss/final boss.png");
            boss.HP = 1224197100;
            var sm = new SkillManager();
            boss.Skills = sm.GetRandomArmorSkills(tier, r);
            boss.Skills.ForEach(s => SetSkillDamage(dtype + 1, s, tier * (dtype + 1), r));
            boss.Weakness = new HashSet<int>();
            boss.Weakness.Add(6);
            boss.Weakness.Add(7);
            return boss;
        }

        private string LoadEnemyImage(string folder, int index)
        {
            var images = Directory.GetFiles(folder);
            return images[index];
        }

        private List<Enemy> LoadEnemyList(string file) => EncryptionManager.DeCrypt<List<Enemy>>(Path.Combine(PATH, file + ".bin"));

        private int GetEnemyHP(int dtype, int t, Random r)
        {
            switch(dtype)
            {
                case DungeonType.EX:
                    return GetEXEnemyHP(t, r);
                case DungeonType.ASCENDED:
                    return GetASCEnemyHP(t, r);
                default:
                    return GetEnemyNormalHP(t, r);
            }
        }

        private int GetEnemyNormalHP(int t, Random r)
        {
            int[] mult = { ENEMY_CAP-20, ENEMY_CAP-10, ENEMY_CAP };
            int m = mult[r.Next(0, mult.Length)];
            return t * m;
        }

        private int GetEXEnemyHP(int t, Random r)
        {
            int[] mult = { EX_CAP - 20, EX_CAP - 10, EX_CAP };
            int m = mult[r.Next(0, mult.Length)];
            return t * m;
        }

        private int GetASCEnemyHP(int t, Random r)
        {
            int[] mult = { ASC_CAP - 20, ASC_CAP - 10, ASC_CAP };
            int m = mult[r.Next(0, mult.Length)];
            return t * m;
        }

        private void SetSkillDamage(int m, Skill skill, int tier, Random r)
        {
            skill.Damage = (skill.S_Type == SkillType.OFFENSIVE) ? r.Next(20 + (tier * 5), 40 + (tier * 5)) : 0;
            skill.Damage *= m;
            skill.Multiplier = r.Next(1, ((tier / 5) + 1) + 1); 
        }

        private int BossHPCalc(int hp) => (int)((Math.Log(hp) * hp) + hp);
    }
}
