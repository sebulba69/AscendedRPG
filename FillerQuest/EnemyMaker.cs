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
        private readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended/enemies/bountyBoss.bin");
        public EnemyMaker()
        {
            InitializeComponent();
        }

        private void EnemyMaker_Load(object sender, EventArgs e)
        {
            var ff = EncryptionManager.DeCrypt<List<Enemy>>(PATH);
            listBox1.DataSource = ff;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
