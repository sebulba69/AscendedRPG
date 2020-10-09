using System;

namespace AscendedRPG
{
    partial class SelectDungeon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDungeon));
            this.label1 = new System.Windows.Forms.Label();
            this.GoBack = new System.Windows.Forms.Button();
            this.EmbarkButton = new System.Windows.Forms.Button();
            this.TierBox = new System.Windows.Forms.NumericUpDown();
            this.recentTier = new System.Windows.Forms.Button();
            this.normalButton = new System.Windows.Forms.RadioButton();
            this.exButton = new System.Windows.Forms.RadioButton();
            this.ascButton = new System.Windows.Forms.RadioButton();
            this.bountyCheckbox = new System.Windows.Forms.CheckBox();
            this.elderButton = new System.Windows.Forms.RadioButton();
            this.keyBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TierBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tier";
            // 
            // GoBack
            // 
            this.GoBack.Location = new System.Drawing.Point(8, 61);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(58, 23);
            this.GoBack.TabIndex = 3;
            this.GoBack.Text = "Go back";
            this.GoBack.UseVisualStyleBackColor = true;
            this.GoBack.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GoBack_MouseClick);
            // 
            // EmbarkButton
            // 
            this.EmbarkButton.Location = new System.Drawing.Point(72, 61);
            this.EmbarkButton.Name = "EmbarkButton";
            this.EmbarkButton.Size = new System.Drawing.Size(58, 23);
            this.EmbarkButton.TabIndex = 4;
            this.EmbarkButton.Text = "Embark";
            this.EmbarkButton.UseVisualStyleBackColor = true;
            this.EmbarkButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EmbarkButton_MouseClick);
            // 
            // TierBox
            // 
            this.TierBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TierBox.Location = new System.Drawing.Point(42, 12);
            this.TierBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.TierBox.Name = "TierBox";
            this.TierBox.Size = new System.Drawing.Size(55, 20);
            this.TierBox.TabIndex = 5;
            this.TierBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TierBox.ValueChanged += new System.EventHandler(this.TierBox_ValueChanged);
            // 
            // recentTier
            // 
            this.recentTier.Location = new System.Drawing.Point(136, 61);
            this.recentTier.Name = "recentTier";
            this.recentTier.Size = new System.Drawing.Size(102, 23);
            this.recentTier.TabIndex = 6;
            this.recentTier.UseVisualStyleBackColor = true;
            this.recentTier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.recentTier_MouseClick);
            // 
            // normalButton
            // 
            this.normalButton.AutoSize = true;
            this.normalButton.Location = new System.Drawing.Point(14, 38);
            this.normalButton.Name = "normalButton";
            this.normalButton.Size = new System.Drawing.Size(58, 17);
            this.normalButton.TabIndex = 7;
            this.normalButton.Text = "Normal";
            this.normalButton.UseVisualStyleBackColor = true;
            this.normalButton.CheckedChanged += new System.EventHandler(this.normalButton_CheckedChanged);
            // 
            // exButton
            // 
            this.exButton.AutoSize = true;
            this.exButton.Location = new System.Drawing.Point(78, 38);
            this.exButton.Name = "exButton";
            this.exButton.Size = new System.Drawing.Size(39, 17);
            this.exButton.TabIndex = 8;
            this.exButton.Text = "EX";
            this.exButton.UseVisualStyleBackColor = true;
            this.exButton.CheckedChanged += new System.EventHandler(this.exButton_CheckedChanged);
            // 
            // ascButton
            // 
            this.ascButton.AutoSize = true;
            this.ascButton.Location = new System.Drawing.Point(123, 38);
            this.ascButton.Name = "ascButton";
            this.ascButton.Size = new System.Drawing.Size(46, 17);
            this.ascButton.TabIndex = 9;
            this.ascButton.Text = "ASC";
            this.ascButton.UseVisualStyleBackColor = true;
            this.ascButton.CheckedChanged += new System.EventHandler(this.ascButton_CheckedChanged);
            // 
            // bountyCheckbox
            // 
            this.bountyCheckbox.AutoSize = true;
            this.bountyCheckbox.Location = new System.Drawing.Point(175, 15);
            this.bountyCheckbox.Name = "bountyCheckbox";
            this.bountyCheckbox.Size = new System.Drawing.Size(59, 17);
            this.bountyCheckbox.TabIndex = 10;
            this.bountyCheckbox.Text = "Bounty";
            this.bountyCheckbox.UseVisualStyleBackColor = true;
            this.bountyCheckbox.CheckedChanged += new System.EventHandler(this.bountyCheckbox_CheckedChanged);
            // 
            // elderButton
            // 
            this.elderButton.AutoSize = true;
            this.elderButton.Location = new System.Drawing.Point(175, 38);
            this.elderButton.Name = "elderButton";
            this.elderButton.Size = new System.Drawing.Size(49, 17);
            this.elderButton.TabIndex = 11;
            this.elderButton.Text = "Elder";
            this.elderButton.UseVisualStyleBackColor = true;
            this.elderButton.CheckedChanged += new System.EventHandler(this.elderButton_CheckedChanged);
            // 
            // keyBox
            // 
            this.keyBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.keyBox.Location = new System.Drawing.Point(103, 12);
            this.keyBox.Name = "keyBox";
            this.keyBox.ReadOnly = true;
            this.keyBox.Size = new System.Drawing.Size(66, 20);
            this.keyBox.TabIndex = 12;
            this.keyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SelectDungeon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 93);
            this.Controls.Add(this.keyBox);
            this.Controls.Add(this.elderButton);
            this.Controls.Add(this.bountyCheckbox);
            this.Controls.Add(this.ascButton);
            this.Controls.Add(this.exButton);
            this.Controls.Add(this.normalButton);
            this.Controls.Add(this.recentTier);
            this.Controls.Add(this.TierBox);
            this.Controls.Add(this.EmbarkButton);
            this.Controls.Add(this.GoBack);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectDungeon";
            this.Text = "Select Dungeon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectDungeon_FormClosing);
            this.Load += new System.EventHandler(this.SelectDungeon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TierBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GoBack;
        private System.Windows.Forms.Button EmbarkButton;
        private System.Windows.Forms.NumericUpDown TierBox;
        private System.Windows.Forms.Button recentTier;
        private System.Windows.Forms.RadioButton normalButton;
        private System.Windows.Forms.RadioButton exButton;
        private System.Windows.Forms.RadioButton ascButton;
        private System.Windows.Forms.CheckBox bountyCheckbox;
        private System.Windows.Forms.RadioButton elderButton;
        private System.Windows.Forms.TextBox keyBox;
    }
}