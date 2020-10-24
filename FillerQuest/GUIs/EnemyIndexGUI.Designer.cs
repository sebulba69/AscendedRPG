namespace AscendedRPG.GUIs
{
    partial class EnemyIndexGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnemyIndexGUI));
            this.enemyList = new System.Windows.Forms.ListBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.description = new System.Windows.Forms.TextBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // enemyList
            // 
            this.enemyList.FormattingEnabled = true;
            this.enemyList.Location = new System.Drawing.Point(13, 13);
            this.enemyList.Name = "enemyList";
            this.enemyList.Size = new System.Drawing.Size(135, 251);
            this.enemyList.TabIndex = 0;
            this.enemyList.SelectedIndexChanged += new System.EventHandler(this.enemyList_SelectedIndexChanged);
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(155, 13);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(174, 155);
            this.pic.TabIndex = 1;
            this.pic.TabStop = false;
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.description.Location = new System.Drawing.Point(155, 174);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Size = new System.Drawing.Size(174, 116);
            this.description.TabIndex = 2;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(13, 270);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(135, 20);
            this.searchBox.TabIndex = 3;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // EnemyIndexGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 302);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.description);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.enemyList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EnemyIndexGUI";
            this.Text = "Enemy Index";
            this.Load += new System.EventHandler(this.EnemyIndexGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox enemyList;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.TextBox searchBox;
    }
}