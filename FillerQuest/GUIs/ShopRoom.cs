﻿using AscendedRPG;
using AscendedRPG.GUIs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    public partial class ShopRoom : Form
    {
        private readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ascended", "shopKeepers");

        private int vendor;

        private List<string[]> vendorDialog;

        // intro, when you buy something
        private string[] vendor1 = { "Welcome! Please enjoy your stay.", "Good choice. I was thinking about getting one for myself, too.", "You need more money if you want to buy that."};
        private string[] vendor2 = { "Haa haa, yuhhhhhh... Yuhhhhhh baby. Feel it.", "Ha ha, your money causes ripples in my soul. Very nice...", "Bruh, come on. You get the cash, you get the stash."};
        private string[] vendor3 = { "BAAAAAASSSSSSEEDDDD!", "You don't have to buy things to give me money, my guy. But, it's still very genki either way.", "This isn't a charity. Get the money, or get out."};
        private string[] vendor4 = { "STEALING IS HARD WORK. HARD WORK DEMANDS MONEY. COMMENSE TRANSACTIONS THIS INSTANT.", "YOUR PURCHASE IS NOTED. YOUR DATE OF DESPAIR WILL BE EXTENDED OUTWARD TO ANOTHER TIME.", "YOU ARE TRYING MY PATIENCE WITH YOUR LACK OF CURRENCY."};
        private string[] vendor5 = { "Don't tell anyone about this. Got it?", "If anyone asks, you didn't see me.", "I can't go givin' this out for free... You either pay the price or get out."};
        private string[] vendor6 = { "Another has appeared! Brothers, it is time to feast on gold once more!", "YES, YES! *gargling noises* FEAST...! FEAST!!!", "[THE FOOLISH ONE LACKS MONEY. HE IS OF NO USE TO US]"};

        private FormState _state;

        private List<Armor> charms;
        private List<string> wares_charms, wares_keys, current;
        Dictionary<string, long> costs;

        public ShopRoom(FormState state)
        {
            _state = state;
            vendorDialog = new List<string[]>();
            InitializeComponent();
        }

        private void ShopRoom_Load(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(PATH, "*.png");
            vendor = (_state.Player.GetVendorCap() - 1) % files.Length;
            VendorPicture.Image = Image.FromFile(Path.Combine(PATH, files[vendor]));

            vendorDialog.Add(vendor1);
            vendorDialog.Add(vendor2);
            vendorDialog.Add(vendor3);
            vendorDialog.Add(vendor4);
            vendorDialog.Add(vendor5);
            vendorDialog.Add(vendor6);

            VendorTextBox.Text = vendorDialog[vendor][0];

            RollWares();

            UpdatePlayerCoins(_state.Player.Wallet.Coins);
        }

        private void RollWares()
        {
            charms = new List<Armor>();
            wares_charms = new List<string>();
            wares_keys = new List<string>();
            costs = new Dictionary<string, long>();

            var r = new Random();

            for (int i = 0; i < 10; i++)
            {
                Armor charm = _state.AManager.GetRandomArmorPiece(_state, GetCharmLevel(), ArmorPiece.CHARM);

                wares_charms.Add(charm.ToString());
                charms.Add(charm);
                int cost = Math.Abs(GetCost(r, 8000, 9000));
                AddCost(charm.ToString(), cost);
            }

            AddCost("Upgrade", Math.Abs(GetCost(r, 8000,9000)));

            AddKeysToShopList(r);

            UpdateVendorDisplay();
        }

        private int GetCharmLevel()
        {
            int vcap = _state.Player.GetVendorCap();
            int mult;
            if (vcap <= 250)
                mult = 1;
            else if (vcap > 250 && vcap <= 500)
                mult = _state.AManager.EX_MODIFIER;
            else
                mult = _state.AManager.ASC_MODIFIER;

            return Math.Abs(vcap * mult);
        }

        private void AddKeysToShopList(Random r)
        {
           int d_cost = GetCost(r, 5000, 6000);
           string[] names = { "EX Dungeon Key", "ASC Dungeon Key", "Bounty Key", "EX Bounty Key", "ASC Bounty Key", "Elder Key" };
           for(int i = 0; i < names.Length; i++)
            {
                wares_keys.Add(names[i]);

                int cost = d_cost * (i + 1);

                AddCost(names[i], Math.Abs(cost/2));
            }
        }

        private int GetCost(Random r, int lower, int upper)
        {
            try
            {
                return checked(r.Next(_state.Player.GetVendorCap() * lower, _state.Player.GetVendorCap() * upper));
            }
            catch(OverflowException)
            {
                return int.MaxValue;
            }
            
        }

        private void UpdateVendorDisplay()
        {
            Text = $"Shop Room Level {_state.Player.GetVendorCap()}";

            if (charmRadio.Checked)
            {
                current = wares_charms;
            }
            else if (keyRadio.Checked)
            {
                current = wares_keys;
            }
            else
            {
                current = new List<string>();
                current.AddRange(wares_charms);
                current.AddRange(wares_keys);
            }

            UpdateVendorWares();
        }


        private void UpdateVendorWares()
        {
            VendorWares.Items.Clear();
            VendorWares.Items.AddRange(current.ToArray());
            upgradeButton.Text = $"Upgrade Vendor: {costs["Upgrade"]}";
        }


        private void AddCost(string k, int v)
        {
            if(costs.ContainsKey(k))
            {
                costs[k] = v;
            }
            else
            {
                costs.Add(k, v);
            }
        }

        private void VendorWares_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VendorWares.SelectedItem != null)
            {
                string selected = VendorWares.SelectedItem.ToString();
                long cost = costs[selected];

                InformationBox.Text = "";

                if (selected.Contains("Charm"))
                    UpdateInfoBoxCharm(selected, cost);
                else
                    UpdateInfoKey($"{selected} -- {cost}", "Can be used at the Select Dungeon screen to progress down a special dungeon.");
            }
        }

        private void UpdateInfoBoxCharm(string selected, long cost)
        {
            var charm = charms.Find(c => c.ToString().Equals(selected));
            AppendToBox($"{charm.ToString()} -- D${cost}");
            AppendToBox("");
            var split = charm.PrintSkills().Split('|');
            foreach(string s in split)
            {
                AppendToBox(s);
            } 
        }

        private void UpdateInfoKey(string cost, string description)
        {
            AppendToBox(cost);
            AppendToBox("");
            AppendToBox(description);
        }

        private void UpdatePlayerCoins(long amount)
        {
            PlayerCoins.Text = $"D.Coin: {amount}";
        }

        private void AppendToBox(string text)
        {
            InformationBox.AppendText(text);
            InformationBox.AppendText(Environment.NewLine);
        }

        private void PurchaseButton_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string selected = VendorWares.SelectedItem.ToString();
                long cost = costs[selected];

                if (_state.Player.Wallet.Coins - cost < 0)
                {
                    VendorTextBox.Text = vendorDialog[vendor][2];
                }
                else
                {
                    int s_index = VendorWares.SelectedIndex;
                    _state.Player.Wallet.Coins -= cost;
                    if (selected.Contains("Charm"))
                    {
                        var charm = charms.Find(c => c.ToString().Equals(selected));
                        _state.Player.Inventory.AddArmor(charm);
                        charms.Remove(charm);
                        wares_charms.Remove(charm.ToString());
                    }
                    else
                    {
                        // wares = num_dungeonTypes - 1
                        // we're going to use the dungeonType later to access our key index so we have to add by 1
                        int index = wares_keys.IndexOf(selected);
                        _state.Player.Wallet.Keys[index+1]++;
                        
                    }

                    VendorTextBox.Text = vendorDialog[vendor][1];
                    UpdatePlayerCoins(_state.Player.Wallet.Coins);
                    UpdateVendorDisplay();

                    _state.HandleSelectedIndex(VendorWares, s_index);
                    _state.Save.SaveGame(_state.Player);
                }
            }
            catch (NullReferenceException)
            {
                allRadio.Checked = true;
            }
        }

        private void upgradeButton_MouseClick(object sender, MouseEventArgs e)
        {
            long cost = costs["Upgrade"];

            if (_state.Player.Wallet.Coins - cost < 0)
            {
                VendorTextBox.Text = vendorDialog[vendor][2];
            }
            else
            {
                if (_state.Player.Tiers[0] < 250)
                    MessageBox.Show("You have to max out your Normal Tier before being able to uncap the vendor.");
                else
                {
                    if (_state.Player.VendorCap + 1 <= _state.GetCap())
                    {
                        _state.Player.Wallet.Coins -= cost;
                        _state.Player.VendorCap++;
                        VendorTextBox.Text = vendorDialog[vendor][1];
                        UpdatePlayerCoins(_state.Player.Wallet.Coins);
                        RollWares();
                        _state.Save.SaveGame(_state.Player);
                    }
                    else
                    {
                        MessageBox.Show("Your shop is currently at max level.");
                    }

                }
            }

        }

        private void charmRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(charmRadio.Checked)
            {
                current = wares_charms;
                UpdateVendorWares();
                if (VendorWares.Items.Count > 0)
                    VendorWares.SelectedIndex = 0;
            }
        }

        private void keyRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(keyRadio.Checked)
            {
                current = wares_keys;
                UpdateVendorWares();
                if (VendorWares.Items.Count > 0)
                    VendorWares.SelectedIndex = 0;
            }
        }

        private void allRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(allRadio.Checked)
            {
                current = new List<string>();
                current.AddRange(wares_charms);
                current.AddRange(wares_keys);
                UpdateVendorWares();
                if (VendorWares.Items.Count > 0)
                    VendorWares.SelectedIndex = 0;
            }
        }

        private void reRollWaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RollWares();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _state.Type = FTypes.MOVE;
            _state.Location = Location;
            Close();
        }

        private void ShopRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_state.Type == FTypes.SHOP_ROOM)
                _state.Type = FTypes.CLOSE;
        }
    }
}
