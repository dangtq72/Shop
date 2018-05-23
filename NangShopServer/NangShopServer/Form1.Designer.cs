namespace NangShopServer
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
            this.txtJsonString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtJsonString
            // 
            this.txtJsonString.Location = new System.Drawing.Point(12, 12);
            this.txtJsonString.Multiline = true;
            this.txtJsonString.Name = "txtJsonString";
            this.txtJsonString.ReadOnly = true;
            this.txtJsonString.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtJsonString.Size = new System.Drawing.Size(566, 316);
            this.txtJsonString.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 340);
            this.Controls.Add(this.txtJsonString);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nắng shop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtJsonString;
    }
}

