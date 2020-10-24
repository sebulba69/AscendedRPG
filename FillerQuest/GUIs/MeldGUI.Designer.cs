namespace AscendedRPG
{
    partial class MeldGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeldGUI));
            this.InventoryList = new System.Windows.Forms.ListBox();
            this.SelectedInventorySkill = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.craftArmorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.head = new System.Windows.Forms.RadioButton();
            this.torso = new System.Windows.Forms.RadioButton();
            this.arms = new System.Windows.Forms.RadioButton();
            this.waist = new System.Windows.Forms.RadioButton();
            this.legs = new System.Windows.Forms.RadioButton();
            this.charms = new System.Windows.Forms.RadioButton();
            this.UnfilterButton = new System.Windows.Forms.Button();
            this.InventoryGroup = new System.Windows.Forms.GroupBox();
            this.skillDisplay = new System.Windows.Forms.TextBox();
            this.MeldButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.InventoryGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // InventoryList
            // 
            this.InventoryList.FormattingEnabled = true;
            this.InventoryList.Location = new System.Drawing.Point(6, 60);
            this.InventoryList.Name = "InventoryList";
            this.InventoryList.Size = new System.Drawing.Size(252, 212);
            this.InventoryList.TabIndex = 1;
            this.InventoryList.SelectedIndexChanged += new System.EventHandler(this.InventoryList_SelectedIndexChanged);
            // 
            // SelectedInventorySkill
            // 
            this.SelectedInventorySkill.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SelectedInventorySkill.Location = new System.Drawing.Point(6, 19);
            this.SelectedInventorySkill.Multiline = true;
            this.SelectedInventorySkill.Name = "SelectedInventorySkill";
            this.SelectedInventorySkill.ReadOnly = true;
            this.SelectedInventorySkill.Size = new System.Drawing.Size(252, 35);
            this.SelectedInventorySkill.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.craftArmorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(414, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // craftArmorToolStripMenuItem
            // 
            this.craftArmorToolStripMenuItem.Name = "craftArmorToolStripMenuItem";
            this.craftArmorToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.craftArmorToolStripMenuItem.Text = "Move";
            this.craftArmorToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripItem);
            // 
            // head
            // 
            this.head.AutoSize = true;
            this.head.Location = new System.Drawing.Point(274, 169);
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
            this.torso.Location = new System.Drawing.Point(313, 169);
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
            this.arms.Location = new System.Drawing.Point(351, 169);
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
            this.waist.Location = new System.Drawing.Point(274, 192);
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
            this.legs.Location = new System.Drawing.Point(316, 192);
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
            this.charms.Location = new System.Drawing.Point(353, 192);
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
            this.UnfilterButton.Location = new System.Drawing.Point(264, 246);
            this.UnfilterButton.Name = "UnfilterButton";
            this.UnfilterButton.Size = new System.Drawing.Size(122, 25);
            this.UnfilterButton.TabIndex = 20;
            this.UnfilterButton.Text = "Unfilter";
            this.UnfilterButton.UseVisualStyleBackColor = true;
            this.UnfilterButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UnfilterButton_MouseClick);
            // 
            // InventoryGroup
            // 
            this.InventoryGroup.Controls.Add(this.skillDisplay);
            this.InventoryGroup.Controls.Add(this.MeldButton);
            this.InventoryGroup.Controls.Add(this.SelectedInventorySkill);
            this.InventoryGroup.Controls.Add(this.InventoryList);
            this.InventoryGroup.Controls.Add(this.UnfilterButton);
            this.InventoryGroup.Controls.Add(this.charms);
            this.InventoryGroup.Controls.Add(this.head);
            this.InventoryGroup.Controls.Add(this.legs);
            this.InventoryGroup.Controls.Add(this.torso);
            this.InventoryGroup.Controls.Add(this.waist);
            this.InventoryGroup.Controls.Add(this.arms);
            this.InventoryGroup.Location = new System.Drawing.Point(12, 27);
            this.InventoryGroup.Name = "InventoryGroup";
            this.InventoryGroup.Size = new System.Drawing.Size(391, 285);
            this.InventoryGroup.TabIndex = 26;
            this.InventoryGroup.TabStop = false;
            // 
            // skillDisplay
            // 
            this.skillDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.skillDisplay.Location = new System.Drawing.Point(264, 19);
            this.skillDisplay.Multiline = true;
            this.skillDisplay.Name = "skillDisplay";
            this.skillDisplay.ReadOnly = true;
            this.skillDisplay.Size = new System.Drawing.Size(120, 144);
            this.skillDisplay.TabIndex = 22;
            // 
            // MeldButton
            // 
            this.MeldButton.Location = new System.Drawing.Point(264, 215);
            this.MeldButton.Name = "MeldButton";
            this.MeldButton.Size = new System.Drawing.Size(122, 25);
            this.MeldButton.TabIndex = 21;
            this.MeldButton.Text = "Meld Selected";
            this.MeldButton.UseVisualStyleBackColor = true;
            this.MeldButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MeldButton_MouseClick);
            // 
            // MeldGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 324);
            this.Controls.Add(this.InventoryGroup);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MeldGUI";
            this.Text = "Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inventory_FormClosing);
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.InventoryGroup.ResumeLayout(false);
            this.InventoryGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox InventoryList;
        private System.Windows.Forms.TextBox SelectedInventorySkill;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RadioButton head;
        private System.Windows.Forms.RadioButton torso;
        private System.Windows.Forms.RadioButton arms;
        private System.Windows.Forms.RadioButton waist;
        private System.Windows.Forms.RadioButton legs;
        private System.Windows.Forms.RadioButton charms;
        private System.Windows.Forms.Button UnfilterButton;
        private System.Windows.Forms.GroupBox InventoryGroup;
        private System.Windows.Forms.ToolStripMenuItem craftArmorToolStripMenuItem;
        private System.Windows.Forms.Button MeldButton;
        private System.Windows.Forms.TextBox skillDisplay;
    }
}

