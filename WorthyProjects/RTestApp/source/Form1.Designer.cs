
namespace RTestApp
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataPath = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.operationSelector = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataPath
            // 
            this.dataPath.Location = new System.Drawing.Point(12, 42);
            this.dataPath.Name = "dataPath";
            this.dataPath.Size = new System.Drawing.Size(531, 22);
            this.dataPath.TabIndex = 1;
            this.dataPath.Text = "File Path";
            this.dataPath.Enter += new System.EventHandler(this.dataPath_Enter);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(468, 13);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // operationSelector
            // 
            this.operationSelector.FormattingEnabled = true;
            this.operationSelector.Items.AddRange(new object[] {
            "Mean",
            "Median",
            "Standard Deviation",
            "Variance",
            "Relative Frequency"});
            this.operationSelector.Location = new System.Drawing.Point(12, 12);
            this.operationSelector.Name = "operationSelector";
            this.operationSelector.Size = new System.Drawing.Size(121, 24);
            this.operationSelector.TabIndex = 0;
            this.operationSelector.Text = "Operations";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 79);
            this.Controls.Add(this.operationSelector);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.dataPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox dataPath;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.ComboBox operationSelector;
    }
}

