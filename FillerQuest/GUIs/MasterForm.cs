using AscendedRPG;
using AscendedRPG.Files;
using AscendedRPG.GUIs;
using System;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            Visible = false;

            var state = new FormState();
            state.Location = Location;
            state.Type = FTypes.WELCOME_SCREEN;
            state.Random = new Random();
            state.Music = new MusicManager();
            state.Save = new SaveManager();
            state.SManager = new SkillManager();
            state.AManager = new ArmorManager();

            Form current = new Form();

            while(state.Type != FTypes.CLOSE)
            {
                switch(state.Type)
                {
                    case FTypes.WELCOME_SCREEN:
                        current = new WelcomeScreen(state);
                        break;
                    case FTypes.CHARACTER_SELECT:
                        current = new CharacterSelect(state);
                        break;
                    case FTypes.LOAD_SCREEN:
                        current = new LoadScreen(state);
                        break;
                    case FTypes.MOVE:
                        current = new MoveGUI(state);
                        break;
                    case FTypes.INVENTORY:
                        current = new Inventory(state);
                        break;
                    case FTypes.SHOP_ROOM:
                        current = new ShopRoom(state);
                        break;
                    case FTypes.CRAFTING_ARMOR:
                        current = new CraftArmorGUI(state);
                        break;
                    case FTypes.SELECT_DUNGEON:
                        current = new SelectDungeon(state);
                        break;
                    case FTypes.DUNGEON_GUI:
                        current = new DungeonGUI(state);
                        break;
                    case FTypes.DUNGEON_BOSS:
                        current = new DungeonGUIBoss(state);
                        break;
                    case FTypes.UPGRADE_SKILLS:
                        current = new UpgradeGUI(state);
                        break;
                    case FTypes.MELD:
                        current = new MeldGUI(state);
                        break;
                    case FTypes.EXCHANGE:
                        current = new MatExchangeGUI(state);
                        break;
                    case FTypes.MINIONS:
                        current = new MinionGUI(state);
                        break;
                }

                try
                {
                    ShowForm(current, state);
                }
                catch (StackOverflowException) { }
            }

            Close();
        }

        private void ShowForm(Form form, FormState state)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = state.Location;
            form.ShowDialog();
        }
    }
}
