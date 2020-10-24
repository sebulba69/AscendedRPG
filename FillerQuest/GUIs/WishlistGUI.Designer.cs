namespace AscendedRPG.GUIs
{
    partial class WishlistGUI
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
            this.recipeList = new System.Windows.Forms.ListBox();
            this.recipeIngredients = new System.Windows.Forms.ListBox();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.enemyIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillBox = new System.Windows.Forms.ListBox();
            this.deleteRecipe = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // recipeList
            // 
            this.recipeList.FormattingEnabled = true;
            this.recipeList.Location = new System.Drawing.Point(12, 27);
            this.recipeList.Name = "recipeList";
            this.recipeList.Size = new System.Drawing.Size(216, 147);
            this.recipeList.TabIndex = 0;
            this.recipeList.SelectedIndexChanged += new System.EventHandler(this.recipeList_SelectedIndexChanged);
            // 
            // recipeIngredients
            // 
            this.recipeIngredients.FormattingEnabled = true;
            this.recipeIngredients.Location = new System.Drawing.Point(235, 118);
            this.recipeIngredients.Name = "recipeIngredients";
            this.recipeIngredients.Size = new System.Drawing.Size(220, 82);
            this.recipeIngredients.TabIndex = 2;
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.resultBox.Location = new System.Drawing.Point(235, 27);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(220, 20);
            this.resultBox.TabIndex = 3;
            this.resultBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enemyIndexToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(467, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // enemyIndexToolStripMenuItem
            // 
            this.enemyIndexToolStripMenuItem.Name = "enemyIndexToolStripMenuItem";
            this.enemyIndexToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.enemyIndexToolStripMenuItem.Text = "Enemy Index";
            this.enemyIndexToolStripMenuItem.Click += new System.EventHandler(this.enemyIndexToolStripMenuItem_Click);
            // 
            // skillBox
            // 
            this.skillBox.FormattingEnabled = true;
            this.skillBox.Location = new System.Drawing.Point(235, 56);
            this.skillBox.Name = "skillBox";
            this.skillBox.Size = new System.Drawing.Size(220, 56);
            this.skillBox.TabIndex = 41;
            // 
            // deleteRecipe
            // 
            this.deleteRecipe.Location = new System.Drawing.Point(12, 180);
            this.deleteRecipe.Name = "deleteRecipe";
            this.deleteRecipe.Size = new System.Drawing.Size(216, 20);
            this.deleteRecipe.TabIndex = 39;
            this.deleteRecipe.Text = "Delete from Wishlist";
            this.deleteRecipe.UseVisualStyleBackColor = true;
            this.deleteRecipe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deleteRecipe_MouseClick);
            // 
            // WishlistGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 211);
            this.Controls.Add(this.skillBox);
            this.Controls.Add(this.deleteRecipe);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.recipeIngredients);
            this.Controls.Add(this.recipeList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "WishlistGUI";
            this.Text = "Craft Armor";
            this.Load += new System.EventHandler(this.WishlistGUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox recipeList;
        private System.Windows.Forms.ListBox recipeIngredients;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListBox skillBox;
        private System.Windows.Forms.ToolStripMenuItem enemyIndexToolStripMenuItem;
        private System.Windows.Forms.Button deleteRecipe;
    }
}