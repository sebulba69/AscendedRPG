namespace AscendedRPG.GUIs
{
    partial class UpgradeGUI
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
            this.lootList = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipBox = new System.Windows.Forms.ListBox();
            this.skillDisplay = new System.Windows.Forms.ListBox();
            this.boostButton = new System.Windows.Forms.Button();
            this.materialBox = new System.Windows.Forms.TextBox();
            this.lootQuantity = new System.Windows.Forms.NumericUpDown();
            this.xpBar = new System.Windows.Forms.ProgressBar();
            this.reqXP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.totalValue = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lootQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lootList
            // 
            this.lootList.FormattingEnabled = true;
            this.lootList.Location = new System.Drawing.Point(3, 27);
            this.lootList.Name = "lootList";
            this.lootList.Size = new System.Drawing.Size(143, 160);
            this.lootList.TabIndex = 0;
            this.lootList.SelectedIndexChanged += new System.EventHandler(this.lootList_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(360, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.inventoryToolStripMenuItem.Text = "Move";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // equipBox
            // 
            this.equipBox.FormattingEnabled = true;
            this.equipBox.Location = new System.Drawing.Point(152, 27);
            this.equipBox.Name = "equipBox";
            this.equipBox.Size = new System.Drawing.Size(203, 108);
            this.equipBox.TabIndex = 2;
            this.equipBox.SelectedIndexChanged += new System.EventHandler(this.equipBox_SelectedIndexChanged);
            // 
            // skillDisplay
            // 
            this.skillDisplay.FormattingEnabled = true;
            this.skillDisplay.Location = new System.Drawing.Point(152, 143);
            this.skillDisplay.Name = "skillDisplay";
            this.skillDisplay.Size = new System.Drawing.Size(203, 69);
            this.skillDisplay.TabIndex = 3;
            // 
            // boostButton
            // 
            this.boostButton.Location = new System.Drawing.Point(3, 243);
            this.boostButton.Name = "boostButton";
            this.boostButton.Size = new System.Drawing.Size(143, 23);
            this.boostButton.TabIndex = 4;
            this.boostButton.Text = "Boost Armor";
            this.boostButton.UseVisualStyleBackColor = true;
            this.boostButton.Click += new System.EventHandler(this.boostButton_Click);
            this.boostButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.boostButton_MouseClick);
            // 
            // materialBox
            // 
            this.materialBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.materialBox.Location = new System.Drawing.Point(3, 193);
            this.materialBox.Name = "materialBox";
            this.materialBox.ReadOnly = true;
            this.materialBox.Size = new System.Drawing.Size(143, 20);
            this.materialBox.TabIndex = 5;
            // 
            // lootQuantity
            // 
            this.lootQuantity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lootQuantity.Location = new System.Drawing.Point(3, 218);
            this.lootQuantity.Name = "lootQuantity";
            this.lootQuantity.ReadOnly = true;
            this.lootQuantity.Size = new System.Drawing.Size(60, 20);
            this.lootQuantity.TabIndex = 6;
            this.lootQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lootQuantity.ValueChanged += new System.EventHandler(this.lootQuantity_ValueChanged);
            // 
            // xpBar
            // 
            this.xpBar.Location = new System.Drawing.Point(152, 214);
            this.xpBar.Name = "xpBar";
            this.xpBar.Size = new System.Drawing.Size(203, 23);
            this.xpBar.TabIndex = 7;
            // 
            // reqXP
            // 
            this.reqXP.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.reqXP.Location = new System.Drawing.Point(152, 244);
            this.reqXP.Name = "reqXP";
            this.reqXP.ReadOnly = true;
            this.reqXP.Size = new System.Drawing.Size(203, 20);
            this.reqXP.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "WARNING: Your game will save after each click of \"Boost Armor.\"";
            // 
            // totalValue
            // 
            this.totalValue.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.totalValue.Location = new System.Drawing.Point(69, 218);
            this.totalValue.Name = "totalValue";
            this.totalValue.ReadOnly = true;
            this.totalValue.Size = new System.Drawing.Size(77, 20);
            this.totalValue.TabIndex = 10;
            this.totalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UpgradeGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 294);
            this.Controls.Add(this.totalValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reqXP);
            this.Controls.Add(this.xpBar);
            this.Controls.Add(this.lootQuantity);
            this.Controls.Add(this.materialBox);
            this.Controls.Add(this.boostButton);
            this.Controls.Add(this.skillDisplay);
            this.Controls.Add(this.equipBox);
            this.Controls.Add(this.lootList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "UpgradeGUI";
            this.Text = "Upgrade Armor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpgradeGUI_FormClosing);
            this.Load += new System.EventHandler(this.UpgradeGUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lootQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lootList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ListBox equipBox;
        private System.Windows.Forms.ListBox skillDisplay;
        private System.Windows.Forms.Button boostButton;
        private System.Windows.Forms.TextBox materialBox;
        private System.Windows.Forms.NumericUpDown lootQuantity;
        private System.Windows.Forms.ProgressBar xpBar;
        private System.Windows.Forms.TextBox reqXP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox totalValue;
    }
}