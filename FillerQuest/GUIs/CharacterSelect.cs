using AscendedRPG.Files;
using AscendedRPG;
using AscendedRPG.GUIs;
using AscendedRPG.Skill_Files;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class CharacterSelect : Form
    {
        private static readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "profilePictures");
        private string[] images;
        private string i_path;
        private PictureBox selected;
        private int index;

        private FormState _state;

        public CharacterSelect(FormState state)
        {
            _state = state;
            InitializeComponent();
        }

        private void CharacterSelect_Load(object sender, EventArgs e)
        { 
            index = 0;
            images = Directory.GetFiles(PATH);
            selected = pictureBox1;
            i_path = string.Empty;
            DisplayImages();
        }

        private void DisplayImages()
        {
            PictureBox[] pbs = { pictureBox1, pictureBox2, pictureBox3 };
            for (int i = 0; i < pbs.Length; i++)
            {
                pbs[i].Visible = true;
                pbs[i].Image = Image.FromFile(images[index]);
                pbs[i].ImageLocation = images[index];
                index++;
            }
        }

        private void nextSet_Click(object sender, EventArgs e)
        {
            blink.Stop();
            int test = index + 3;
            if(test >= images.Length)index = test - images.Length;
            i_path = string.Empty;
            DisplayImages();
        }

        private void oldSet_Click(object sender, EventArgs e)
        {
            blink.Stop();
            index -= 6;
            if(index < 0)index = images.Length - 3;
            i_path = string.Empty;
            DisplayImages();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) => AlternateVisiblePictureBoxes(pictureBox2, pictureBox3, pictureBox1);
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e) => AlternateVisiblePictureBoxes(pictureBox1, pictureBox3, pictureBox2);
        private void pictureBox3_MouseClick(object sender, MouseEventArgs e) => AlternateVisiblePictureBoxes(pictureBox1, pictureBox2, pictureBox3);

        private void AlternateVisiblePictureBoxes(PictureBox one, PictureBox two, PictureBox pb)
        {
            blink.Stop();
            one.Visible = true;
            two.Visible = true;
            selected = pb;
            i_path = selected.ImageLocation;
            blink.Start();
        }

        private void blink_Tick(object sender, EventArgs e)
        {
            selected.Visible = !selected.Visible;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if(i_path.Equals(string.Empty))
            {
                MessageBox.Show("Pick a proflie pic to continue.");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want this image as your profile picture? There's no going back once it's chosen.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _state.Player.Picture = i_path;
                    _state.Player.Set = new ArmorSet();
                    _state.Player.Weapon = new Weapon()
                    {
                        Level = 1,
                        XP = 0,
                        XPtoNext = 500,
                        Damage = 23,
                        Style = WeaponStyle.ATTACK
                    };

                    for (int i = 0; i < ArmorPiece.TOTAL; i++)
                        _state.Player.Set.AddArmor(_state.AManager.GetRandomArmorPiece(_state, _state.Player.Tiers[0], i));

                    _state.Player.Loot = new AscendedRPG.LootHolder();

                    for (int i = 0; i < 9; i++)
                        _state.Player.ElementalAttack.Add(0);

                    _state.Save.SaveGame(_state.Player);

                    Visible = false;
                    // i'm too lazy to make a bunch of save files with dialog so it's gonna be hardcoded in here
                    string[] d = {
                        "You are a villager from a far off island.",
                        "It was a few weeks ago that you received your calling.",
                        "Since then, you've journed across the globe to find what is known as \"The Endless Dungeon.\"",
                        "When every young villager grows up, it becomes their duty to journey to this far off place.",
                        "Rumor has it that if you reach the bottom, you can attain enlightenment beyond normal human comprehension.",
                        "However, no one has been able to confirm it.",
                        "All who try to fully traverse The Endless Dungeon disappear.",
                        "But, you will be different.",
                        "You are a gamer, and gamers rise up and conquer all challenges.",
                        "So, go, my fellow gamer... rise up...",
                        "...AND ASCEND!!!!",
                        "~ this post was made by the \"totally not a scam\" gang"
                    };

                    DialogBox db = new DialogBox(d);
                    db.StartPosition = FormStartPosition.Manual;
                    db.Location = Location;
                    db.ShowDialog();

                    _state.Location = Location;
                    _state.Type = FTypes.INVENTORY;
                    Close();
                }
            }
        }


        private void CharacterSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            blink.Stop();
            if (_state.Type == FTypes.CHARACTER_SELECT)
                _state.Type = FTypes.CLOSE;
        }

    }
}
