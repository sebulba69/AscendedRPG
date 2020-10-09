using AscendedRPG;
using AscendedRPG.Files;
using AscendedRPG.LootClasses;
using AscendedRPG.Recipes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class EnemyMaker : Form
    {
        private readonly string PIC_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "enemies", "minion");
        private readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "enemies", "minions.bin");

        public EnemyMaker()
        {
            InitializeComponent();
        }

        private void EnemyMaker_Load(object sender, EventArgs e)
        {
            List<Enemy> minions = new List<Enemy>();
            var files = Directory.GetFiles(PIC_PATH);
            pictureBox1.ImageLocation = files[0];
            string[] names = { "Bucire", "Bucater", "Buceyice", "Bushock", "Buwind", "Bucenuke", "Bucedark", "Bulight", "Buceical" };
            SkillManager sm = new SkillManager();
            Random r = new Random();
            for (int i = 0; i < files.Length; i++)
            {
                var skills = sm.GetRandomArmorSkills(1, r);
                skills.ForEach(s => s.Name = names[s.Element]);
                var enemy = new Enemy()
                {
                    Name = "Bucey Minion",
                    Image = files[i],
                    Skills = skills,
                    Turns = 1
                };
                enemy.Weakness = new HashSet<int>();
                int n = r.Next(1, 3);
                for(int j = 0; j < n;j++)
                {
                    int w = r.Next(0, 9);
                    while(enemy.Weakness.Contains(w))
                    {
                        w = r.Next(0, 9);
                    }
                    enemy.Weakness.Add(w);
                }
                minions.Add(enemy);
            }
            EncryptionManager.EncryptFile(PATH, minions);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
