namespace AscendedRPG.GUIs
{
    partial class MinionGUI
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
            this.minionBox = new System.Windows.Forms.ListBox();
            this.mpicBox = new System.Windows.Forms.PictureBox();
            this.minionName = new System.Windows.Forms.TextBox();
            this.minionWeapon = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            this.minionSkills = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipButton = new System.Windows.Forms.Button();
            this.msCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mpicBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // minionBox
            // 
            this.minionBox.FormattingEnabled = true;
            this.minionBox.Location = new System.Drawing.Point(12, 61);
            this.minionBox.Name = "minionBox";
            this.minionBox.Size = new System.Drawing.Size(179, 147);
            this.minionBox.TabIndex = 0;
            this.minionBox.SelectedIndexChanged += new System.EventHandler(this.minionBox_SelectedIndexChanged);
            // 
            // mpicBox
            // 
            this.mpicBox.Location = new System.Drawing.Point(197, 37);
            this.mpicBox.Name = "mpicBox";
            this.mpicBox.Size = new System.Drawing.Size(174, 155);
            this.mpicBox.TabIndex = 1;
            this.mpicBox.TabStop = false;
            // 
            // minionName
            // 
            this.minionName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.minionName.Location = new System.Drawing.Point(197, 198);
            this.minionName.Name = "minionName";
            this.minionName.ReadOnly = true;
            this.minionName.Size = new System.Drawing.Size(174, 20);
            this.minionName.TabIndex = 30;
            this.minionName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minionWeapon
            // 
            this.minionWeapon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.minionWeapon.Location = new System.Drawing.Point(197, 224);
            this.minionWeapon.Name = "minionWeapon";
            this.minionWeapon.ReadOnly = true;
            this.minionWeapon.Size = new System.Drawing.Size(174, 20);
            this.minionWeapon.TabIndex = 31;
            this.minionWeapon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(12, 241);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(179, 23);
            this.delete.TabIndex = 32;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.delete_MouseClick);
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(12, 270);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(179, 23);
            this.create.TabIndex = 33;
            this.create.Text = "Summon (10 MS)";
            this.create.UseVisualStyleBackColor = true;
            this.create.MouseClick += new System.Windows.Forms.MouseEventHandler(this.create_MouseClick);
            // 
            // minionSkills
            // 
            this.minionSkills.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.minionSkills.Location = new System.Drawing.Point(197, 250);
            this.minionSkills.Multiline = true;
            this.minionSkills.Name = "minionSkills";
            this.minionSkills.ReadOnly = true;
            this.minionSkills.Size = new System.Drawing.Size(174, 42);
            this.minionSkills.TabIndex = 34;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(381, 24);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // equipButton
            // 
            this.equipButton.Location = new System.Drawing.Point(12, 212);
            this.equipButton.Name = "equipButton";
            this.equipButton.Size = new System.Drawing.Size(179, 23);
            this.equipButton.TabIndex = 36;
            this.equipButton.Text = "Equip Selected";
            this.equipButton.UseVisualStyleBackColor = true;
            this.equipButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.equipButton_MouseClick);
            // 
            // msCount
            // 
            this.msCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.msCount.Location = new System.Drawing.Point(12, 37);
            this.msCount.Name = "msCount";
            this.msCount.ReadOnly = true;
            this.msCount.Size = new System.Drawing.Size(179, 20);
            this.msCount.TabIndex = 37;
            this.msCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinionGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 300);
            this.Controls.Add(this.msCount);
            this.Controls.Add(this.equipButton);
            this.Controls.Add(this.minionSkills);
            this.Controls.Add(this.create);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.minionWeapon);
            this.Controls.Add(this.minionName);
            this.Controls.Add(this.mpicBox);
            this.Controls.Add(this.minionBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MinionGUI";
            this.Text = "Minion Hut";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MinionGUI_FormClosing);
            this.Load += new System.EventHandler(this.MinionGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mpicBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox minionBox;
        private System.Windows.Forms.PictureBox mpicBox;
        private System.Windows.Forms.TextBox minionName;
        private System.Windows.Forms.TextBox minionWeapon;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.TextBox minionSkills;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button equipButton;
        private System.Windows.Forms.TextBox msCount;
    }
}