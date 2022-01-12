
namespace IndovinaChiCSharp
{
    partial class Risultato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Risultato));
            this.pic_result = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_result)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_result
            // 
            this.pic_result.Location = new System.Drawing.Point(-1, 0);
            this.pic_result.Name = "pic_result";
            this.pic_result.Size = new System.Drawing.Size(410, 110);
            this.pic_result.TabIndex = 0;
            this.pic_result.TabStop = false;
            // 
            // Risultato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(409, 110);
            this.Controls.Add(this.pic_result);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Risultato";
            ((System.ComponentModel.ISupportInitialize)(this.pic_result)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_result;
    }
}