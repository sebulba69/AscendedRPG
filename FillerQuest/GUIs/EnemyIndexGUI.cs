using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class EnemyIndexGUI : Form
    {
        private List<EIndexEntry> index;
        public EnemyIndexGUI(Dictionary<string, EIndexEntry> i)
        {
            index = i.Select(kvp => kvp.Value).ToList();
            InitializeComponent();
        }

        private void EnemyIndexGUI_Load(object sender, EventArgs e)
        {
            enemyList.DataSource = index;
        }

        private void enemyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            description.Clear();
            var selected = enemyList.SelectedItem as EIndexEntry;
            pic.ImageLocation = selected.Image;
            var d = selected.GetDescString().Split('*');
            for(int i = 0; i < d.Length - 1; i++)
            {
                description.AppendText(d[i]);
                description.AppendText(Environment.NewLine);
            }
            description.AppendText(d.Last());
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string s_string = searchBox.Text[0].ToString().ToUpper() + searchBox.Text.Substring(1);
                var search = index.FindAll(q => q.Name.StartsWith(s_string));
                enemyList.DataSource = search;
            }
            catch (IndexOutOfRangeException)
            {
                enemyList.DataSource = index;
            }

        }
    }
}
