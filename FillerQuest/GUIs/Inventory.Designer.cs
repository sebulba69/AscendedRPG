namespace AscendedRPG
{
    partial class Inventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.InventoryList = new System.Windows.Forms.ListBox();
            this.SelectedArmorSkill = new System.Windows.Forms.TextBox();
            this.SelectedInventorySkill = new System.Windows.Forms.TextBox();
            this.DeleteSelectedInventory = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmbarkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.craftArmorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkWishlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EquipmentBox = new System.Windows.Forms.ListBox();
            this.ActiveSkillBox = new System.Windows.Forms.ListBox();
            this.SkillDisplayBox = new System.Windows.Forms.TextBox();
            this.head = new System.Windows.Forms.RadioButton();
            this.torso = new System.Windows.Forms.RadioButton();
            this.arms = new System.Windows.Forms.RadioButton();
            this.waist = new System.Windows.Forms.RadioButton();
            this.legs = new System.Windows.Forms.RadioButton();
            this.charms = new System.Windows.Forms.RadioButton();
            this.UnfilterButton = new System.Windows.Forms.Button();
            this.DefenseBox = new System.Windows.Forms.TextBox();
            this.CoinBox = new System.Windows.Forms.TextBox();
            this.TierBox = new System.Windows.Forms.TextBox();
            this.EquipmentGroup = new System.Windows.Forms.GroupBox();
            this.WeaponBox = new System.Windows.Forms.TextBox();
            this.activeElements = new System.Windows.Forms.TextBox();
            this.PlayerPic = new System.Windows.Forms.PictureBox();
            this.InventoryGroup = new System.Windows.Forms.GroupBox();
            this.EquipButton = new System.Windows.Forms.Button();
            this.WeaponStyles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.EquipmentGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPic)).BeginInit();
            this.InventoryGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // InventoryList
            // 
            this.InventoryList.FormattingEnabled = true;
            this.InventoryList.Location = new System.Drawing.Point(11, 82);
            this.InventoryList.Name = "InventoryList";
            this.InventoryList.Size = new System.Drawing.Size(248, 225);
            this.InventoryList.TabIndex = 1;
            this.InventoryList.SelectedIndexChanged += new System.EventHandler(this.InventoryList_SelectedIndexChanged);
            // 
            // SelectedArmorSkill
            // 
            this.SelectedArmorSkill.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelectedArmorSkill.Location = new System.Drawing.Point(204, 238);
            this.SelectedArmorSkill.Multiline = true;
            this.SelectedArmorSkill.Name = "SelectedArmorSkill";
            this.SelectedArmorSkill.ReadOnly = true;
            this.SelectedArmorSkill.Size = new System.Drawing.Size(197, 52);
            this.SelectedArmorSkill.TabIndex = 4;
            // 
            // SelectedInventorySkill
            // 
            this.SelectedInventorySkill.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelectedInventorySkill.Location = new System.Drawing.Point(11, 19);
            this.SelectedInventorySkill.Multiline = true;
            this.SelectedInventorySkill.Name = "SelectedInventorySkill";
            this.SelectedInventorySkill.ReadOnly = true;
            this.SelectedInventorySkill.Size = new System.Drawing.Size(248, 57);
            this.SelectedInventorySkill.TabIndex = 5;
            // 
            // DeleteSelectedInventory
            // 
            this.DeleteSelectedInventory.Location = new System.Drawing.Point(94, 334);
            this.DeleteSelectedInventory.Name = "DeleteSelectedInventory";
            this.DeleteSelectedInventory.Size = new System.Drawing.Size(82, 25);
            this.DeleteSelectedInventory.TabIndex = 7;
            this.DeleteSelectedInventory.Text = "Delete";
            this.DeleteSelectedInventory.UseVisualStyleBackColor = true;
            this.DeleteSelectedInventory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DeleteSelectedInventory_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveMenuItem,
            this.EmbarkMenuItem,
            this.craftArmorToolStripMenuItem,
            this.checkWishlistToolStripMenuItem,
            this.enemyIndexToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(701, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(43, 20);
            this.SaveMenuItem.Text = "Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // EmbarkMenuItem
            // 
            this.EmbarkMenuItem.Name = "EmbarkMenuItem";
            this.EmbarkMenuItem.Size = new System.Drawing.Size(59, 20);
            this.EmbarkMenuItem.Text = "Embark";
            this.EmbarkMenuItem.Click += new System.EventHandler(this.EmbarkMenuItem_Click);
            // 
            // craftArmorToolStripMenuItem
            // 
            this.craftArmorToolStripMenuItem.Name = "craftArmorToolStripMenuItem";
            this.craftArmorToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.craftArmorToolStripMenuItem.Text = "Move";
            this.craftArmorToolStripMenuItem.Click += new System.EventHandler(this.craftArmorToolStripMenuItem_Click);
            // 
            // checkWishlistToolStripMenuItem
            // 
            this.checkWishlistToolStripMenuItem.Name = "checkWishlistToolStripMenuItem";
            this.checkWishlistToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.checkWishlistToolStripMenuItem.Text = "Check Wishlist";
            this.checkWishlistToolStripMenuItem.Click += new System.EventHandler(this.checkWishlistToolStripMenuItem_Click);
            // 
            // enemyIndexToolStripMenuItem
            // 
            this.enemyIndexToolStripMenuItem.Name = "enemyIndexToolStripMenuItem";
            this.enemyIndexToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.enemyIndexToolStripMenuItem.Text = "Enemy Index";
            this.enemyIndexToolStripMenuItem.Click += new System.EventHandler(this.enemyIndexToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // EquipmentBox
            // 
            this.EquipmentBox.FormattingEnabled = true;
            this.EquipmentBox.Location = new System.Drawing.Point(204, 137);
            this.EquipmentBox.Name = "EquipmentBox";
            this.EquipmentBox.Size = new System.Drawing.Size(197, 95);
            this.EquipmentBox.TabIndex = 11;
            this.EquipmentBox.SelectedIndexChanged += new System.EventHandler(this.EquipmentBox_SelectedIndexChanged);
            // 
            // ActiveSkillBox
            // 
            this.ActiveSkillBox.FormattingEnabled = true;
            this.ActiveSkillBox.Location = new System.Drawing.Point(6, 197);
            this.ActiveSkillBox.Name = "ActiveSkillBox";
            this.ActiveSkillBox.Size = new System.Drawing.Size(192, 134);
            this.ActiveSkillBox.TabIndex = 12;
            this.ActiveSkillBox.SelectedIndexChanged += new System.EventHandler(this.ActiveSkillBox_SelectedIndexChanged);
            // 
            // SkillDisplayBox
            // 
            this.SkillDisplayBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SkillDisplayBox.Location = new System.Drawing.Point(204, 296);
            this.SkillDisplayBox.Multiline = true;
            this.SkillDisplayBox.Name = "SkillDisplayBox";
            this.SkillDisplayBox.ReadOnly = true;
            this.SkillDisplayBox.Size = new System.Drawing.Size(197, 61);
            this.SkillDisplayBox.TabIndex = 0;
            // 
            // head
            // 
            this.head.AutoSize = true;
            this.head.Location = new System.Drawing.Point(25, 312);
            this.head.Name = "head";
            this.head.Size = new System.Drawing.Size(33, 17);
            this.head.TabIndex = 14;
            this.head.TabStop = true;
            this.head.Text = "H";
            this.head.UseVisualStyleBackColor = true;
            this.head.CheckedChanged += new System.EventHandler(this.head_CheckedChanged);
            // 
            // torso
            // 
            this.torso.AutoSize = true;
            this.torso.Location = new System.Drawing.Point(64, 312);
            this.torso.Name = "torso";
            this.torso.Size = new System.Drawing.Size(32, 17);
            this.torso.TabIndex = 15;
            this.torso.TabStop = true;
            this.torso.Text = "T";
            this.torso.UseVisualStyleBackColor = true;
            this.torso.CheckedChanged += new System.EventHandler(this.torso_CheckedChanged);
            // 
            // arms
            // 
            this.arms.AutoSize = true;
            this.arms.Location = new System.Drawing.Point(102, 312);
            this.arms.Name = "arms";
            this.arms.Size = new System.Drawing.Size(32, 17);
            this.arms.TabIndex = 16;
            this.arms.TabStop = true;
            this.arms.Text = "A";
            this.arms.UseVisualStyleBackColor = true;
            this.arms.CheckedChanged += new System.EventHandler(this.arms_CheckedChanged);
            // 
            // waist
            // 
            this.waist.AutoSize = true;
            this.waist.Location = new System.Drawing.Point(140, 312);
            this.waist.Name = "waist";
            this.waist.Size = new System.Drawing.Size(36, 17);
            this.waist.TabIndex = 17;
            this.waist.TabStop = true;
            this.waist.Text = "W";
            this.waist.UseVisualStyleBackColor = true;
            this.waist.CheckedChanged += new System.EventHandler(this.waist_CheckedChanged);
            // 
            // legs
            // 
            this.legs.AutoSize = true;
            this.legs.Location = new System.Drawing.Point(182, 312);
            this.legs.Name = "legs";
            this.legs.Size = new System.Drawing.Size(31, 17);
            this.legs.TabIndex = 18;
            this.legs.TabStop = true;
            this.legs.Text = "L";
            this.legs.UseVisualStyleBackColor = true;
            this.legs.CheckedChanged += new System.EventHandler(this.legs_CheckedChanged);
            // 
            // charms
            // 
            this.charms.AutoSize = true;
            this.charms.Location = new System.Drawing.Point(219, 312);
            this.charms.Name = "charms";
            this.charms.Size = new System.Drawing.Size(32, 17);
            this.charms.TabIndex = 19;
            this.charms.TabStop = true;
            this.charms.Text = "C";
            this.charms.UseVisualStyleBackColor = true;
            this.charms.CheckedChanged += new System.EventHandler(this.charms_CheckedChanged);
            // 
            // UnfilterButton
            // 
            this.UnfilterButton.Location = new System.Drawing.Point(184, 334);
            this.UnfilterButton.Name = "UnfilterButton";
            this.UnfilterButton.Size = new System.Drawing.Size(75, 25);
            this.UnfilterButton.TabIndex = 20;
            this.UnfilterButton.Text = "Unfilter";
            this.UnfilterButton.UseVisualStyleBackColor = true;
            this.UnfilterButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UnfilterButton_MouseClick);
            // 
            // DefenseBox
            // 
            this.DefenseBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DefenseBox.Location = new System.Drawing.Point(204, 36);
            this.DefenseBox.Name = "DefenseBox";
            this.DefenseBox.ReadOnly = true;
            this.DefenseBox.Size = new System.Drawing.Size(197, 20);
            this.DefenseBox.TabIndex = 21;
            this.DefenseBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CoinBox
            // 
            this.CoinBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CoinBox.Location = new System.Drawing.Point(204, 60);
            this.CoinBox.Name = "CoinBox";
            this.CoinBox.ReadOnly = true;
            this.CoinBox.Size = new System.Drawing.Size(197, 20);
            this.CoinBox.TabIndex = 22;
            this.CoinBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TierBox
            // 
            this.TierBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TierBox.Location = new System.Drawing.Point(204, 12);
            this.TierBox.Name = "TierBox";
            this.TierBox.ReadOnly = true;
            this.TierBox.Size = new System.Drawing.Size(197, 20);
            this.TierBox.TabIndex = 23;
            this.TierBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EquipmentGroup
            // 
            this.EquipmentGroup.Controls.Add(this.label1);
            this.EquipmentGroup.Controls.Add(this.WeaponStyles);
            this.EquipmentGroup.Controls.Add(this.WeaponBox);
            this.EquipmentGroup.Controls.Add(this.activeElements);
            this.EquipmentGroup.Controls.Add(this.SkillDisplayBox);
            this.EquipmentGroup.Controls.Add(this.SelectedArmorSkill);
            this.EquipmentGroup.Controls.Add(this.ActiveSkillBox);
            this.EquipmentGroup.Controls.Add(this.DefenseBox);
            this.EquipmentGroup.Controls.Add(this.CoinBox);
            this.EquipmentGroup.Controls.Add(this.PlayerPic);
            this.EquipmentGroup.Controls.Add(this.TierBox);
            this.EquipmentGroup.Controls.Add(this.EquipmentBox);
            this.EquipmentGroup.Location = new System.Drawing.Point(9, 27);
            this.EquipmentGroup.Name = "EquipmentGroup";
            this.EquipmentGroup.Size = new System.Drawing.Size(407, 367);
            this.EquipmentGroup.TabIndex = 25;
            this.EquipmentGroup.TabStop = false;
            // 
            // WeaponBox
            // 
            this.WeaponBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.WeaponBox.Location = new System.Drawing.Point(204, 85);
            this.WeaponBox.Name = "WeaponBox";
            this.WeaponBox.ReadOnly = true;
            this.WeaponBox.Size = new System.Drawing.Size(197, 20);
            this.WeaponBox.TabIndex = 29;
            this.WeaponBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // activeElements
            // 
            this.activeElements.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.activeElements.Location = new System.Drawing.Point(6, 337);
            this.activeElements.Name = "activeElements";
            this.activeElements.ReadOnly = true;
            this.activeElements.Size = new System.Drawing.Size(192, 20);
            this.activeElements.TabIndex = 28;
            this.activeElements.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PlayerPic
            // 
            this.PlayerPic.ErrorImage = null;
            this.PlayerPic.InitialImage = null;
            this.PlayerPic.Location = new System.Drawing.Point(6, 12);
            this.PlayerPic.Name = "PlayerPic";
            this.PlayerPic.Size = new System.Drawing.Size(192, 179);
            this.PlayerPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayerPic.TabIndex = 27;
            this.PlayerPic.TabStop = false;
            // 
            // InventoryGroup
            // 
            this.InventoryGroup.Controls.Add(this.EquipButton);
            this.InventoryGroup.Controls.Add(this.SelectedInventorySkill);
            this.InventoryGroup.Controls.Add(this.InventoryList);
            this.InventoryGroup.Controls.Add(this.UnfilterButton);
            this.InventoryGroup.Controls.Add(this.DeleteSelectedInventory);
            this.InventoryGroup.Controls.Add(this.charms);
            this.InventoryGroup.Controls.Add(this.head);
            this.InventoryGroup.Controls.Add(this.legs);
            this.InventoryGroup.Controls.Add(this.torso);
            this.InventoryGroup.Controls.Add(this.waist);
            this.InventoryGroup.Controls.Add(this.arms);
            this.InventoryGroup.Location = new System.Drawing.Point(422, 27);
            this.InventoryGroup.Name = "InventoryGroup";
            this.InventoryGroup.Size = new System.Drawing.Size(267, 367);
            this.InventoryGroup.TabIndex = 26;
            this.InventoryGroup.TabStop = false;
            // 
            // EquipButton
            // 
            this.EquipButton.Location = new System.Drawing.Point(6, 334);
            this.EquipButton.Name = "EquipButton";
            this.EquipButton.Size = new System.Drawing.Size(81, 25);
            this.EquipButton.TabIndex = 21;
            this.EquipButton.Text = "Equip";
            this.EquipButton.UseVisualStyleBackColor = true;
            this.EquipButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EquipButton_MouseClick);
            // 
            // WeaponStyles
            // 
            this.WeaponStyles.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.WeaponStyles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WeaponStyles.FormattingEnabled = true;
            this.WeaponStyles.Items.AddRange(new object[] {
            "Attack",
            "Parry",
            "Lifesteal"});
            this.WeaponStyles.Location = new System.Drawing.Point(284, 110);
            this.WeaponStyles.Name = "WeaponStyles";
            this.WeaponStyles.Size = new System.Drawing.Size(117, 21);
            this.WeaponStyles.TabIndex = 30;
            this.WeaponStyles.SelectedIndexChanged += new System.EventHandler(this.WeaponStyles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Weapon Style:";
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 402);
            this.Controls.Add(this.InventoryGroup);
            this.Controls.Add(this.EquipmentGroup);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inventory_FormClosing);
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.EquipmentGroup.ResumeLayout(false);
            this.EquipmentGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerPic)).EndInit();
            this.InventoryGroup.ResumeLayout(false);
            this.InventoryGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox InventoryList;
        private System.Windows.Forms.TextBox SelectedArmorSkill;
        private System.Windows.Forms.TextBox SelectedInventorySkill;
        private System.Windows.Forms.Button DeleteSelectedInventory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListBox EquipmentBox;
        private System.Windows.Forms.ListBox ActiveSkillBox;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmbarkMenuItem;
        private System.Windows.Forms.TextBox SkillDisplayBox;
        private System.Windows.Forms.RadioButton head;
        private System.Windows.Forms.RadioButton torso;
        private System.Windows.Forms.RadioButton arms;
        private System.Windows.Forms.RadioButton waist;
        private System.Windows.Forms.RadioButton legs;
        private System.Windows.Forms.RadioButton charms;
        private System.Windows.Forms.Button UnfilterButton;
        private System.Windows.Forms.TextBox DefenseBox;
        private System.Windows.Forms.TextBox CoinBox;
        private System.Windows.Forms.TextBox TierBox;
        private System.Windows.Forms.GroupBox EquipmentGroup;
        private System.Windows.Forms.GroupBox InventoryGroup;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox PlayerPic;
        private System.Windows.Forms.ToolStripMenuItem craftArmorToolStripMenuItem;
        private System.Windows.Forms.TextBox activeElements;
        private System.Windows.Forms.Button EquipButton;
        private System.Windows.Forms.ToolStripMenuItem enemyIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkWishlistToolStripMenuItem;
        private System.Windows.Forms.TextBox WeaponBox;
        private System.Windows.Forms.ComboBox WeaponStyles;
        private System.Windows.Forms.Label label1;
    }
}

