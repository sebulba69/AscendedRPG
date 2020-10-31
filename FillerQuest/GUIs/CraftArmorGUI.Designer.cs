namespace AscendedRPG.GUIs
{
    partial class CraftArmorGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CraftArmorGUI));
            this.recipeList = new System.Windows.Forms.ListBox();
            this.recipeIngredients = new System.Windows.Forms.ListBox();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.craftButton = new System.Windows.Forms.Button();
            this.deleteRecipe = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillBox = new System.Windows.Forms.ListBox();
            this.saveRecipe = new System.Windows.Forms.Button();
            this.headButton = new System.Windows.Forms.RadioButton();
            this.torsoButton = new System.Windows.Forms.RadioButton();
            this.armsButton = new System.Windows.Forms.RadioButton();
            this.waistButton = new System.Windows.Forms.RadioButton();
            this.legButton = new System.Windows.Forms.RadioButton();
            this.allButton = new System.Windows.Forms.RadioButton();
            this.wlistButton = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // recipeList
            // 
            this.recipeList.FormattingEnabled = true;
            this.recipeList.Location = new System.Drawing.Point(12, 27);
            this.recipeList.Name = "recipeList";
            this.recipeList.Size = new System.Drawing.Size(336, 147);
            this.recipeList.TabIndex = 0;
            this.recipeList.SelectedIndexChanged += new System.EventHandler(this.recipeList_SelectedIndexChanged);
            // 
            // recipeIngredients
            // 
            this.recipeIngredients.FormattingEnabled = true;
            this.recipeIngredients.Location = new System.Drawing.Point(354, 116);
            this.recipeIngredients.Name = "recipeIngredients";
            this.recipeIngredients.Size = new System.Drawing.Size(241, 108);
            this.recipeIngredients.TabIndex = 2;
            // 
            // resultBox
            // 
            this.resultBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.resultBox.Location = new System.Drawing.Point(354, 27);
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(241, 20);
            this.resultBox.TabIndex = 3;
            this.resultBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // craftButton
            // 
            this.craftButton.Location = new System.Drawing.Point(127, 201);
            this.craftButton.Name = "craftButton";
            this.craftButton.Size = new System.Drawing.Size(107, 20);
            this.craftButton.TabIndex = 38;
            this.craftButton.Text = "Craft Armor";
            this.craftButton.UseVisualStyleBackColor = true;
            this.craftButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.craftButton_MouseClick);
            // 
            // deleteRecipe
            // 
            this.deleteRecipe.Location = new System.Drawing.Point(240, 201);
            this.deleteRecipe.Name = "deleteRecipe";
            this.deleteRecipe.Size = new System.Drawing.Size(108, 20);
            this.deleteRecipe.TabIndex = 39;
            this.deleteRecipe.Text = "Delete Recipe";
            this.deleteRecipe.UseVisualStyleBackColor = true;
            this.deleteRecipe.Click += new System.EventHandler(this.deleteRecipe_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryToolStripMenuItem,
            this.enemyIndexToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(607, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.inventoryToolStripMenuItem.Text = "Move";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
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
            this.skillBox.Location = new System.Drawing.Point(354, 54);
            this.skillBox.Name = "skillBox";
            this.skillBox.Size = new System.Drawing.Size(241, 56);
            this.skillBox.TabIndex = 41;
            // 
            // saveRecipe
            // 
            this.saveRecipe.Location = new System.Drawing.Point(12, 201);
            this.saveRecipe.Name = "saveRecipe";
            this.saveRecipe.Size = new System.Drawing.Size(109, 20);
            this.saveRecipe.TabIndex = 42;
            this.saveRecipe.Text = "Save Recipe";
            this.saveRecipe.UseVisualStyleBackColor = true;
            this.saveRecipe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.saveRecipe_MouseClick);
            // 
            // headButton
            // 
            this.headButton.AutoSize = true;
            this.headButton.Location = new System.Drawing.Point(40, 180);
            this.headButton.Name = "headButton";
            this.headButton.Size = new System.Drawing.Size(33, 17);
            this.headButton.TabIndex = 43;
            this.headButton.Text = "H";
            this.headButton.UseVisualStyleBackColor = true;
            this.headButton.CheckedChanged += new System.EventHandler(this.headButton_CheckedChanged);
            // 
            // torsoButton
            // 
            this.torsoButton.AutoSize = true;
            this.torsoButton.Location = new System.Drawing.Point(79, 180);
            this.torsoButton.Name = "torsoButton";
            this.torsoButton.Size = new System.Drawing.Size(32, 17);
            this.torsoButton.TabIndex = 44;
            this.torsoButton.Text = "T";
            this.torsoButton.UseVisualStyleBackColor = true;
            this.torsoButton.CheckedChanged += new System.EventHandler(this.torsoButton_CheckedChanged);
            // 
            // armsButton
            // 
            this.armsButton.AutoSize = true;
            this.armsButton.Location = new System.Drawing.Point(117, 180);
            this.armsButton.Name = "armsButton";
            this.armsButton.Size = new System.Drawing.Size(32, 17);
            this.armsButton.TabIndex = 45;
            this.armsButton.Text = "A";
            this.armsButton.UseVisualStyleBackColor = true;
            this.armsButton.CheckedChanged += new System.EventHandler(this.armsButton_CheckedChanged);
            // 
            // waistButton
            // 
            this.waistButton.AutoSize = true;
            this.waistButton.Location = new System.Drawing.Point(155, 180);
            this.waistButton.Name = "waistButton";
            this.waistButton.Size = new System.Drawing.Size(36, 17);
            this.waistButton.TabIndex = 46;
            this.waistButton.Text = "W";
            this.waistButton.UseVisualStyleBackColor = true;
            this.waistButton.CheckedChanged += new System.EventHandler(this.waistButton_CheckedChanged);
            // 
            // legButton
            // 
            this.legButton.AutoSize = true;
            this.legButton.Location = new System.Drawing.Point(197, 180);
            this.legButton.Name = "legButton";
            this.legButton.Size = new System.Drawing.Size(31, 17);
            this.legButton.TabIndex = 47;
            this.legButton.Text = "L";
            this.legButton.UseVisualStyleBackColor = true;
            this.legButton.CheckedChanged += new System.EventHandler(this.legButton_CheckedChanged);
            // 
            // allButton
            // 
            this.allButton.AutoSize = true;
            this.allButton.Checked = true;
            this.allButton.Location = new System.Drawing.Point(234, 180);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(36, 17);
            this.allButton.TabIndex = 48;
            this.allButton.TabStop = true;
            this.allButton.Text = "All";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.CheckedChanged += new System.EventHandler(this.allButton_CheckedChanged);
            // 
            // wlistButton
            // 
            this.wlistButton.AutoSize = true;
            this.wlistButton.Location = new System.Drawing.Point(276, 180);
            this.wlistButton.Name = "wlistButton";
            this.wlistButton.Size = new System.Drawing.Size(55, 17);
            this.wlistButton.TabIndex = 49;
            this.wlistButton.Text = "W.List";
            this.wlistButton.UseVisualStyleBackColor = true;
            this.wlistButton.CheckedChanged += new System.EventHandler(this.wlistButton_CheckedChanged);
            // 
            // CraftArmorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 236);
            this.Controls.Add(this.wlistButton);
            this.Controls.Add(this.allButton);
            this.Controls.Add(this.legButton);
            this.Controls.Add(this.waistButton);
            this.Controls.Add(this.armsButton);
            this.Controls.Add(this.torsoButton);
            this.Controls.Add(this.headButton);
            this.Controls.Add(this.saveRecipe);
            this.Controls.Add(this.skillBox);
            this.Controls.Add(this.deleteRecipe);
            this.Controls.Add(this.craftButton);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.recipeIngredients);
            this.Controls.Add(this.recipeList);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "CraftArmorGUI";
            this.Text = "Craft Armor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CraftArmorGUI_FormClosing);
            this.Load += new System.EventHandler(this.CraftArmorGUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox recipeList;
        private System.Windows.Forms.ListBox recipeIngredients;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Button craftButton;
        private System.Windows.Forms.Button deleteRecipe;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ListBox skillBox;
        private System.Windows.Forms.ToolStripMenuItem enemyIndexToolStripMenuItem;
        private System.Windows.Forms.Button saveRecipe;
        private System.Windows.Forms.RadioButton headButton;
        private System.Windows.Forms.RadioButton torsoButton;
        private System.Windows.Forms.RadioButton armsButton;
        private System.Windows.Forms.RadioButton waistButton;
        private System.Windows.Forms.RadioButton legButton;
        private System.Windows.Forms.RadioButton allButton;
        private System.Windows.Forms.RadioButton wlistButton;
    }
}