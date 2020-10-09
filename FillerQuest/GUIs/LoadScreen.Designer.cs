namespace AscendedRPG.GUIs
{
    partial class LoadScreen
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
            this.loadPaths = new System.Windows.Forms.ListBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadPaths
            // 
            this.loadPaths.FormattingEnabled = true;
            this.loadPaths.Location = new System.Drawing.Point(12, 12);
            this.loadPaths.Name = "loadPaths";
            this.loadPaths.Size = new System.Drawing.Size(170, 147);
            this.loadPaths.TabIndex = 0;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(13, 166);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(169, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load Selected File";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.loadButton_MouseClick);
            // 
            // LoadScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 198);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.loadPaths);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoadScreen";
            this.Text = "Load Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadScreen_FormClosing);
            this.Load += new System.EventHandler(this.LoadScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox loadPaths;
        private System.Windows.Forms.Button loadButton;
    }
}