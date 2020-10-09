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
    public partial class MoveGUI : Form
    {
        private readonly string[] locations = { "Inventory", "Shop", "Craft Armor", "Upgrade Armor", "Meld Armor", "Mat. Exchange", "Minion Hut" };
        private readonly FTypes[] states = { FTypes.INVENTORY, FTypes.SHOP_ROOM, FTypes.CRAFTING_ARMOR, FTypes.UPGRADE_SKILLS, FTypes.MELD, FTypes.EXCHANGE, FTypes.MINIONS };
        private FormState _state;

        public MoveGUI(FormState state)
        {
            _state = state;
            InitializeComponent();
        }

        private void MoveGUI_Load(object sender, EventArgs e)
        {
            locals.Items.Add("~ Locations ~");
            foreach(string l in locations)
                locals.Items.Add(l);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            int index = locals.SelectedIndex - 1;
            if (index >= 0)
            {
                _state.Type = states[index];
                _state.Location = Location;
                Close();
            }
        }

        private void MoveGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.MOVE)
                _state.Type = FTypes.CLOSE;
        }
    }
}
