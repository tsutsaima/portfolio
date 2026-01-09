namespace SongiGhost
{
    partial class Form1
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
            this.panel = new System.Windows.Forms.Panel();
            this.pohyb = new System.Windows.Forms.Timer(this.components);
            this.DUCH = new System.Windows.Forms.Timer(this.components);
            this.pohyb_ducha = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1284, 651);
            this.panel.TabIndex = 0;
            // 
            // pohyb
            // 
            this.pohyb.Interval = 10;
            this.pohyb.Tick += new System.EventHandler(this.pohyb_Tick);
            // 
            // DUCH
            // 
            this.DUCH.Interval = 10000;
            this.DUCH.Tick += new System.EventHandler(this.DUCH_Tick);
            // 
            // pohyb_ducha
            // 
            this.pohyb_ducha.Interval = 30;
            this.pohyb_ducha.Tick += new System.EventHandler(this.pohyb_ducha_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 651);
            this.Controls.Add(this.panel);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TOO SPOOKY";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Timer pohyb;
        private System.Windows.Forms.Timer DUCH;
        private System.Windows.Forms.Timer pohyb_ducha;
        private System.Windows.Forms.PictureBox podlaha;
    }
}

