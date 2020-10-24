namespace AscendedRPG.GUIs
{
    partial class MatExchangeGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatExchangeGUI));
            this.allMats = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wishlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matType = new System.Windows.Forms.ComboBox();
            this.enemyList = new System.Windows.Forms.ListBox();
            this.enemySearch = new System.Windows.Forms.TextBox();
            this.reqInfo = new System.Windows.Forms.TextBox();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.pic = new System.Windows.Forms.PictureBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.energyButton = new System.Windows.Forms.RadioButton();
            this.shardButton = new System.Windows.Forms.RadioButton();
            this.scaleButton = new System.Windows.Forms.RadioButton();
            this.mantleButton = new System.Windows.Forms.RadioButton();
            this.crystalButton = new System.Windows.Forms.RadioButton();
            this.allButton = new System.Windows.Forms.RadioButton();
            this.filterBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.filterBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // allMats
            // 
            this.allMats.FormattingEnabled = true;
            this.allMats.Location = new System.Drawing.Point(4, 27);
            this.allMats.Name = "allMats";
            this.allMats.Size = new System.Drawing.Size(204, 212);
            this.allMats.TabIndex = 0;
            this.allMats.SelectedIndexChanged += new System.EventHandler(this.allMats_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem,
            this.wishlistToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(574, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // wishlistToolStripMenuItem
            // 
            this.wishlistToolStripMenuItem.Name = "wishlistToolStripMenuItem";
            this.wishlistToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.wishlistToolStripMenuItem.Text = "Check Wishlist";
            this.wishlistToolStripMenuItem.Click += new System.EventHandler(this.wishlistToolStripMenuItem_Click);
            // 
            // matType
            // 
            this.matType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.matType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.matType.FormattingEnabled = true;
            this.matType.Items.AddRange(new object[] {
            "Energy",
            "Shard",
            "Scale",
            "Mantle",
            "Crystal"});
            this.matType.Location = new System.Drawing.Point(214, 219);
            this.matType.Name = "matType";
            this.matType.Size = new System.Drawing.Size(117, 21);
            this.matType.TabIndex = 1;
            this.matType.TabStop = false;
            this.matType.SelectedIndexChanged += new System.EventHandler(this.matType_SelectedIndexChanged);
            // 
            // enemyList
            // 
            this.enemyList.FormattingEnabled = true;
            this.enemyList.Location = new System.Drawing.Point(394, 26);
            this.enemyList.Name = "enemyList";
            this.enemyList.Size = new System.Drawing.Size(176, 238);
            this.enemyList.TabIndex = 4;
            this.enemyList.SelectedIndexChanged += new System.EventHandler(this.enemyList_SelectedIndexChanged);
            // 
            // enemySearch
            // 
            this.enemySearch.Location = new System.Drawing.Point(394, 278);
            this.enemySearch.Name = "enemySearch";
            this.enemySearch.Size = new System.Drawing.Size(176, 20);
            this.enemySearch.TabIndex = 5;
            this.enemySearch.TextChanged += new System.EventHandler(this.enemySearch_TextChanged);
            // 
            // reqInfo
            // 
            this.reqInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.reqInfo.Location = new System.Drawing.Point(214, 192);
            this.reqInfo.Name = "reqInfo";
            this.reqInfo.ReadOnly = true;
            this.reqInfo.Size = new System.Drawing.Size(174, 20);
            this.reqInfo.TabIndex = 6;
            // 
            // quantity
            // 
            this.quantity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.quantity.Location = new System.Drawing.Point(337, 219);
            this.quantity.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(53, 20);
            this.quantity.TabIndex = 7;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.ValueChanged += new System.EventHandler(this.quantity_ValueChanged);
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(214, 27);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(174, 155);
            this.pic.TabIndex = 8;
            this.pic.TabStop = false;
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(214, 276);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(174, 23);
            this.convertButton.TabIndex = 9;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.convertButton_MouseClick);
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.resultBox.Location = new System.Drawing.Point(214, 249);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(174, 20);
            this.resultBox.TabIndex = 10;
            // 
            // energyButton
            // 
            this.energyButton.AutoSize = true;
            this.energyButton.Location = new System.Drawing.Point(12, 13);
            this.energyButton.Name = "energyButton";
            this.energyButton.Size = new System.Drawing.Size(58, 17);
            this.energyButton.TabIndex = 11;
            this.energyButton.Text = "Energy";
            this.energyButton.UseVisualStyleBackColor = true;
            this.energyButton.CheckedChanged += new System.EventHandler(this.energyButton_CheckedChanged);
            // 
            // shardButton
            // 
            this.shardButton.AutoSize = true;
            this.shardButton.Location = new System.Drawing.Point(76, 13);
            this.shardButton.Name = "shardButton";
            this.shardButton.Size = new System.Drawing.Size(53, 17);
            this.shardButton.TabIndex = 12;
            this.shardButton.Text = "Shard";
            this.shardButton.UseVisualStyleBackColor = true;
            this.shardButton.CheckedChanged += new System.EventHandler(this.shardButton_CheckedChanged);
            // 
            // scaleButton
            // 
            this.scaleButton.AutoSize = true;
            this.scaleButton.Location = new System.Drawing.Point(135, 13);
            this.scaleButton.Name = "scaleButton";
            this.scaleButton.Size = new System.Drawing.Size(52, 17);
            this.scaleButton.TabIndex = 13;
            this.scaleButton.Text = "Scale";
            this.scaleButton.UseVisualStyleBackColor = true;
            this.scaleButton.CheckedChanged += new System.EventHandler(this.scaleButton_CheckedChanged);
            // 
            // mantleButton
            // 
            this.mantleButton.AutoSize = true;
            this.mantleButton.Location = new System.Drawing.Point(12, 36);
            this.mantleButton.Name = "mantleButton";
            this.mantleButton.Size = new System.Drawing.Size(57, 17);
            this.mantleButton.TabIndex = 14;
            this.mantleButton.Text = "Mantle";
            this.mantleButton.UseVisualStyleBackColor = true;
            this.mantleButton.CheckedChanged += new System.EventHandler(this.mantleButton_CheckedChanged);
            // 
            // crystalButton
            // 
            this.crystalButton.AutoSize = true;
            this.crystalButton.Location = new System.Drawing.Point(76, 36);
            this.crystalButton.Name = "crystalButton";
            this.crystalButton.Size = new System.Drawing.Size(56, 17);
            this.crystalButton.TabIndex = 15;
            this.crystalButton.Text = "Crystal";
            this.crystalButton.UseVisualStyleBackColor = true;
            this.crystalButton.CheckedChanged += new System.EventHandler(this.crystalButton_CheckedChanged);
            // 
            // allButton
            // 
            this.allButton.AutoSize = true;
            this.allButton.Checked = true;
            this.allButton.Location = new System.Drawing.Point(135, 36);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(36, 17);
            this.allButton.TabIndex = 16;
            this.allButton.TabStop = true;
            this.allButton.Text = "All";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.CheckedChanged += new System.EventHandler(this.allButton_CheckedChanged);
            // 
            // filterBox
            // 
            this.filterBox.Controls.Add(this.energyButton);
            this.filterBox.Controls.Add(this.allButton);
            this.filterBox.Controls.Add(this.shardButton);
            this.filterBox.Controls.Add(this.crystalButton);
            this.filterBox.Controls.Add(this.scaleButton);
            this.filterBox.Controls.Add(this.mantleButton);
            this.filterBox.Location = new System.Drawing.Point(4, 240);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(204, 60);
            this.filterBox.TabIndex = 17;
            this.filterBox.TabStop = false;
            // 
            // MatExchangeGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 307);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.reqInfo);
            this.Controls.Add(this.enemySearch);
            this.Controls.Add(this.enemyList);
            this.Controls.Add(this.matType);
            this.Controls.Add(this.allMats);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MatExchangeGUI";
            this.Text = "Material Exchange";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MatExchangeGUI_FormClosing);
            this.Load += new System.EventHandler(this.MatExchangeGUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.filterBox.ResumeLayout(false);
            this.filterBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox allMats;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wishlistToolStripMenuItem;
        private System.Windows.Forms.ComboBox matType;
        private System.Windows.Forms.ListBox enemyList;
        private System.Windows.Forms.TextBox enemySearch;
        private System.Windows.Forms.TextBox reqInfo;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.RadioButton energyButton;
        private System.Windows.Forms.RadioButton shardButton;
        private System.Windows.Forms.RadioButton scaleButton;
        private System.Windows.Forms.RadioButton mantleButton;
        private System.Windows.Forms.RadioButton crystalButton;
        private System.Windows.Forms.RadioButton allButton;
        private System.Windows.Forms.GroupBox filterBox;
    }
}