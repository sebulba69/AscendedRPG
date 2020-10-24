namespace AscendedRPG.GUIs
{
    partial class MoveGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveGUI));
            this.locals = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // locals
            // 
            this.locals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locals.FormattingEnabled = true;
            this.locals.ItemHeight = 20;
            this.locals.Location = new System.Drawing.Point(13, 13);
            this.locals.Name = "locals";
            this.locals.Size = new System.Drawing.Size(217, 164);
            this.locals.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // MoveGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 218);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.locals);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MoveGUI";
            this.Text = "Move";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MoveGUI_FormClosing);
            this.Load += new System.EventHandler(this.MoveGUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox locals;
        private System.Windows.Forms.Button button1;
    }
}