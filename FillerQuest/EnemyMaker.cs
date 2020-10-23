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
        public EnemyMaker()
        {
            InitializeComponent();
        }

        private void EnemyMaker_Load(object sender, EventArgs e)
        {
            int[] dtypes = { 0, 1, 2 };
            string[] typeNames = { "~ NORMAL ~", "~ EX ~", "~ ASC ~" };
            int[] caps = { 60, 1000, 5000 };
            int bounty = 20;

            foreach(int dtype in dtypes)
            {
                listBox1.Items.Add(typeNames[dtype]);
                int t = dtype + 1;
                for(int tier = 1; tier <= 21; tier++)
                {
                    long hp = tier * (dtype+1);
                    hp *= (caps[dtype] * bounty);
                    hp = BossHPCalc(hp);
                    listBox1.Items.Add($"[T{tier}] {hp} HP -- ({hp <= Int32.MaxValue})");
                }
                listBox1.Items.Add("");
            }
        }

        private long BossHPCalc(long hp) => (long)((Math.Log(hp) * hp) + hp);
    }
}
