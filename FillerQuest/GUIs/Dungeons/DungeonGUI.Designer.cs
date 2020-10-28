namespace AscendedRPG
{
    partial class DungeonGUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DungeonGUI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnemyGroup = new System.Windows.Forms.GroupBox();
            this.EnemyBox3 = new System.Windows.Forms.TextBox();
            this.EnemyBox2 = new System.Windows.Forms.TextBox();
            this.EnemyBox1 = new System.Windows.Forms.TextBox();
            this.EnemyBar3 = new System.Windows.Forms.ProgressBar();
            this.EnemyBar2 = new System.Windows.Forms.ProgressBar();
            this.EnemyBar1 = new System.Windows.Forms.ProgressBar();
            this.EnemyPic3 = new System.Windows.Forms.PictureBox();
            this.EnemyPic2 = new System.Windows.Forms.PictureBox();
            this.EnemyPic1 = new System.Windows.Forms.PictureBox();
            this.TurnBox = new System.Windows.Forms.TextBox();
            this.UseSkillButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ProfilePic = new System.Windows.Forms.PictureBox();
            this.FightsLeft = new System.Windows.Forms.TextBox();
            this.CurrentFight = new System.Windows.Forms.TextBox();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.TargetGroup = new System.Windows.Forms.GroupBox();
            this.Target3 = new System.Windows.Forms.RadioButton();
            this.Target2 = new System.Windows.Forms.RadioButton();
            this.Target1 = new System.Windows.Forms.RadioButton();
            this.Skills = new System.Windows.Forms.ListBox();
            this.PlayerHealth = new System.Windows.Forms.ProgressBar();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.CombatLog = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.EnemyGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePic)).BeginInit();
            this.TargetGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.enemyIndexToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(618, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // enemyIndexToolStripMenuItem
            // 
            this.enemyIndexToolStripMenuItem.Name = "enemyIndexToolStripMenuItem";
            this.enemyIndexToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.enemyIndexToolStripMenuItem.Text = "Enemy Index";
            this.enemyIndexToolStripMenuItem.Click += new System.EventHandler(this.enemyIndexToolStripMenuItem_Click);
            // 
            // EnemyGroup
            // 
            this.EnemyGroup.Controls.Add(this.EnemyBox3);
            this.EnemyGroup.Controls.Add(this.EnemyBox2);
            this.EnemyGroup.Controls.Add(this.EnemyBox1);
            this.EnemyGroup.Controls.Add(this.EnemyBar3);
            this.EnemyGroup.Controls.Add(this.EnemyBar2);
            this.EnemyGroup.Controls.Add(this.EnemyBar1);
            this.EnemyGroup.Controls.Add(this.EnemyPic3);
            this.EnemyGroup.Controls.Add(this.EnemyPic2);
            this.EnemyGroup.Controls.Add(this.EnemyPic1);
            this.EnemyGroup.Location = new System.Drawing.Point(7, 27);
            this.EnemyGroup.Name = "EnemyGroup";
            this.EnemyGroup.Size = new System.Drawing.Size(601, 257);
            this.EnemyGroup.TabIndex = 7;
            this.EnemyGroup.TabStop = false;
            // 
            // EnemyBox3
            // 
            this.EnemyBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.EnemyBox3.Location = new System.Drawing.Point(402, 226);
            this.EnemyBox3.Name = "EnemyBox3";
            this.EnemyBox3.ReadOnly = true;
            this.EnemyBox3.Size = new System.Drawing.Size(192, 20);
            this.EnemyBox3.TabIndex = 8;
            this.EnemyBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnemyBox2
            // 
            this.EnemyBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.EnemyBox2.Location = new System.Drawing.Point(204, 226);
            this.EnemyBox2.Name = "EnemyBox2";
            this.EnemyBox2.ReadOnly = true;
            this.EnemyBox2.Size = new System.Drawing.Size(192, 20);
            this.EnemyBox2.TabIndex = 7;
            this.EnemyBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnemyBox1
            // 
            this.EnemyBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.EnemyBox1.Location = new System.Drawing.Point(6, 226);
            this.EnemyBox1.Name = "EnemyBox1";
            this.EnemyBox1.ReadOnly = true;
            this.EnemyBox1.Size = new System.Drawing.Size(192, 20);
            this.EnemyBox1.TabIndex = 6;
            this.EnemyBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnemyBar3
            // 
            this.EnemyBar3.Location = new System.Drawing.Point(402, 201);
            this.EnemyBar3.Name = "EnemyBar3";
            this.EnemyBar3.Size = new System.Drawing.Size(192, 23);
            this.EnemyBar3.TabIndex = 5;
            // 
            // EnemyBar2
            // 
            this.EnemyBar2.Location = new System.Drawing.Point(204, 201);
            this.EnemyBar2.Name = "EnemyBar2";
            this.EnemyBar2.Size = new System.Drawing.Size(192, 23);
            this.EnemyBar2.TabIndex = 4;
            // 
            // EnemyBar1
            // 
            this.EnemyBar1.Location = new System.Drawing.Point(6, 201);
            this.EnemyBar1.Name = "EnemyBar1";
            this.EnemyBar1.Size = new System.Drawing.Size(192, 23);
            this.EnemyBar1.TabIndex = 3;
            // 
            // EnemyPic3
            // 
            this.EnemyPic3.Location = new System.Drawing.Point(402, 19);
            this.EnemyPic3.Name = "EnemyPic3";
            this.EnemyPic3.Size = new System.Drawing.Size(192, 179);
            this.EnemyPic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnemyPic3.TabIndex = 2;
            this.EnemyPic3.TabStop = false;
            // 
            // EnemyPic2
            // 
            this.EnemyPic2.Location = new System.Drawing.Point(204, 19);
            this.EnemyPic2.Name = "EnemyPic2";
            this.EnemyPic2.Size = new System.Drawing.Size(192, 179);
            this.EnemyPic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnemyPic2.TabIndex = 1;
            this.EnemyPic2.TabStop = false;
            // 
            // EnemyPic1
            // 
            this.EnemyPic1.ErrorImage = null;
            this.EnemyPic1.InitialImage = null;
            this.EnemyPic1.Location = new System.Drawing.Point(6, 19);
            this.EnemyPic1.Name = "EnemyPic1";
            this.EnemyPic1.Size = new System.Drawing.Size(192, 179);
            this.EnemyPic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnemyPic1.TabIndex = 0;
            this.EnemyPic1.TabStop = false;
            // 
            // TurnBox
            // 
            this.TurnBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TurnBox.Location = new System.Drawing.Point(7, 290);
            this.TurnBox.Name = "TurnBox";
            this.TurnBox.ReadOnly = true;
            this.TurnBox.Size = new System.Drawing.Size(601, 20);
            this.TurnBox.TabIndex = 8;
            // 
            // UseSkillButton
            // 
            this.UseSkillButton.Location = new System.Drawing.Point(7, 480);
            this.UseSkillButton.Name = "UseSkillButton";
            this.UseSkillButton.Size = new System.Drawing.Size(174, 23);
            this.UseSkillButton.TabIndex = 11;
            this.UseSkillButton.Text = "Use Skill";
            this.UseSkillButton.UseVisualStyleBackColor = true;
            this.UseSkillButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UseSkillButton_MouseClick);
            // 
            // timer
            // 
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ProfilePic
            // 
            this.ProfilePic.Location = new System.Drawing.Point(7, 316);
            this.ProfilePic.Name = "ProfilePic";
            this.ProfilePic.Size = new System.Drawing.Size(174, 155);
            this.ProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProfilePic.TabIndex = 34;
            this.ProfilePic.TabStop = false;
            // 
            // FightsLeft
            // 
            this.FightsLeft.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FightsLeft.Location = new System.Drawing.Point(7, 534);
            this.FightsLeft.Name = "FightsLeft";
            this.FightsLeft.ReadOnly = true;
            this.FightsLeft.Size = new System.Drawing.Size(174, 20);
            this.FightsLeft.TabIndex = 35;
            this.FightsLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CurrentFight
            // 
            this.CurrentFight.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CurrentFight.Location = new System.Drawing.Point(7, 508);
            this.CurrentFight.Name = "CurrentFight";
            this.CurrentFight.ReadOnly = true;
            this.CurrentFight.Size = new System.Drawing.Size(174, 20);
            this.CurrentFight.TabIndex = 36;
            this.CurrentFight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(368, 340);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(26, 23);
            this.leftButton.TabIndex = 47;
            this.leftButton.Text = "<";
            this.leftButton.UseVisualStyleBackColor = true;
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(396, 340);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(26, 23);
            this.rightButton.TabIndex = 46;
            this.rightButton.Text = ">";
            this.rightButton.UseVisualStyleBackColor = true;
            // 
            // TargetGroup
            // 
            this.TargetGroup.Controls.Add(this.Target3);
            this.TargetGroup.Controls.Add(this.Target2);
            this.TargetGroup.Controls.Add(this.Target1);
            this.TargetGroup.Location = new System.Drawing.Point(428, 504);
            this.TargetGroup.Name = "TargetGroup";
            this.TargetGroup.Size = new System.Drawing.Size(180, 50);
            this.TargetGroup.TabIndex = 45;
            this.TargetGroup.TabStop = false;
            this.TargetGroup.Text = "Targets";
            // 
            // Target3
            // 
            this.Target3.AutoSize = true;
            this.Target3.Enabled = false;
            this.Target3.Location = new System.Drawing.Point(117, 19);
            this.Target3.Name = "Target3";
            this.Target3.Size = new System.Drawing.Size(49, 17);
            this.Target3.TabIndex = 2;
            this.Target3.TabStop = true;
            this.Target3.Text = "three";
            this.Target3.UseVisualStyleBackColor = true;
            // 
            // Target2
            // 
            this.Target2.AutoSize = true;
            this.Target2.Enabled = false;
            this.Target2.Location = new System.Drawing.Point(69, 19);
            this.Target2.Name = "Target2";
            this.Target2.Size = new System.Drawing.Size(42, 17);
            this.Target2.TabIndex = 1;
            this.Target2.TabStop = true;
            this.Target2.Text = "two";
            this.Target2.UseVisualStyleBackColor = true;
            // 
            // Target1
            // 
            this.Target1.AutoSize = true;
            this.Target1.Checked = true;
            this.Target1.Location = new System.Drawing.Point(20, 19);
            this.Target1.Name = "Target1";
            this.Target1.Size = new System.Drawing.Size(43, 17);
            this.Target1.TabIndex = 0;
            this.Target1.TabStop = true;
            this.Target1.Text = "one";
            this.Target1.UseVisualStyleBackColor = true;
            // 
            // Skills
            // 
            this.Skills.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Skills.FormattingEnabled = true;
            this.Skills.Location = new System.Drawing.Point(187, 368);
            this.Skills.Name = "Skills";
            this.Skills.Size = new System.Drawing.Size(235, 186);
            this.Skills.TabIndex = 44;
            // 
            // PlayerHealth
            // 
            this.PlayerHealth.Location = new System.Drawing.Point(187, 316);
            this.PlayerHealth.Name = "PlayerHealth";
            this.PlayerHealth.Size = new System.Drawing.Size(235, 20);
            this.PlayerHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PlayerHealth.TabIndex = 43;
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.NameBox.Location = new System.Drawing.Point(187, 342);
            this.NameBox.Name = "NameBox";
            this.NameBox.ReadOnly = true;
            this.NameBox.Size = new System.Drawing.Size(176, 20);
            this.NameBox.TabIndex = 42;
            this.NameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CombatLog
            // 
            this.CombatLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CombatLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombatLog.Location = new System.Drawing.Point(428, 316);
            this.CombatLog.Multiline = true;
            this.CombatLog.Name = "CombatLog";
            this.CombatLog.ReadOnly = true;
            this.CombatLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CombatLog.Size = new System.Drawing.Size(180, 182);
            this.CombatLog.TabIndex = 41;
            // 
            // DungeonGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 565);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.TargetGroup);
            this.Controls.Add(this.Skills);
            this.Controls.Add(this.PlayerHealth);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.CombatLog);
            this.Controls.Add(this.CurrentFight);
            this.Controls.Add(this.FightsLeft);
            this.Controls.Add(this.ProfilePic);
            this.Controls.Add(this.UseSkillButton);
            this.Controls.Add(this.TurnBox);
            this.Controls.Add(this.EnemyGroup);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DungeonGUI";
            this.Text = "Dungeon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DungeonGUI_FormClosing);
            this.Load += new System.EventHandler(this.DungeonGUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DungeonGUI_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.EnemyGroup.ResumeLayout(false);
            this.EnemyGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyPic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfilePic)).EndInit();
            this.TargetGroup.ResumeLayout(false);
            this.TargetGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.GroupBox EnemyGroup;
        private System.Windows.Forms.TextBox TurnBox;
        private System.Windows.Forms.PictureBox EnemyPic1;
        private System.Windows.Forms.PictureBox EnemyPic3;
        private System.Windows.Forms.PictureBox EnemyPic2;
        private System.Windows.Forms.ProgressBar EnemyBar1;
        private System.Windows.Forms.ProgressBar EnemyBar3;
        private System.Windows.Forms.ProgressBar EnemyBar2;
        private System.Windows.Forms.TextBox EnemyBox1;
        private System.Windows.Forms.TextBox EnemyBox3;
        private System.Windows.Forms.TextBox EnemyBox2;
        private System.Windows.Forms.Button UseSkillButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox ProfilePic;
        private System.Windows.Forms.TextBox FightsLeft;
        private System.Windows.Forms.TextBox CurrentFight;
        private System.Windows.Forms.ToolStripMenuItem enemyIndexToolStripMenuItem;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.GroupBox TargetGroup;
        private System.Windows.Forms.RadioButton Target3;
        private System.Windows.Forms.RadioButton Target2;
        private System.Windows.Forms.RadioButton Target1;
        private System.Windows.Forms.ListBox Skills;
        private System.Windows.Forms.ProgressBar PlayerHealth;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox CombatLog;
    }
}