
namespace IndovinaChiCSharp
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_mess = new System.Windows.Forms.TextBox();
            this.btn_Resolve = new System.Windows.Forms.Button();
            this.btn_discard = new System.Windows.Forms.Button();
            this.btn_nextRound = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.infoText = new System.Windows.Forms.TextBox();
            this.pPlayer1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_connect.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.Location = new System.Drawing.Point(439, 424);
            this.btn_connect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(92, 33);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "CONNECT!";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_ip
            // 
            this.txt_ip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_ip.Font = new System.Drawing.Font("Berlin Sans FB Demi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ip.Location = new System.Drawing.Point(535, 424);
            this.txt_ip.Margin = new System.Windows.Forms.Padding(2);
            this.txt_ip.Multiline = true;
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(109, 31);
            this.txt_ip.TabIndex = 4;
            this.txt_ip.Text = "Enter ip here...";
            // 
            // txt_mess
            // 
            this.txt_mess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_mess.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mess.Location = new System.Drawing.Point(439, 372);
            this.txt_mess.Margin = new System.Windows.Forms.Padding(2);
            this.txt_mess.Multiline = true;
            this.txt_mess.Name = "txt_mess";
            this.txt_mess.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_mess.Size = new System.Drawing.Size(306, 48);
            this.txt_mess.TabIndex = 6;
            // 
            // btn_Resolve
            // 
            this.btn_Resolve.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Resolve.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Resolve.Image = ((System.Drawing.Image)(resources.GetObject("btn_Resolve.Image")));
            this.btn_Resolve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Resolve.Location = new System.Drawing.Point(439, 462);
            this.btn_Resolve.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Resolve.Name = "btn_Resolve";
            this.btn_Resolve.Size = new System.Drawing.Size(152, 27);
            this.btn_Resolve.TabIndex = 16;
            this.btn_Resolve.Text = "RESOLVE";
            this.btn_Resolve.UseVisualStyleBackColor = true;
            // 
            // btn_discard
            // 
            this.btn_discard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_discard.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_discard.Image = ((System.Drawing.Image)(resources.GetObject("btn_discard.Image")));
            this.btn_discard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_discard.Location = new System.Drawing.Point(595, 463);
            this.btn_discard.Margin = new System.Windows.Forms.Padding(2);
            this.btn_discard.Name = "btn_discard";
            this.btn_discard.Size = new System.Drawing.Size(149, 27);
            this.btn_discard.TabIndex = 15;
            this.btn_discard.Text = "DISCARD";
            this.btn_discard.UseVisualStyleBackColor = true;
            // 
            // btn_nextRound
            // 
            this.btn_nextRound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_nextRound.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nextRound.Image = ((System.Drawing.Image)(resources.GetObject("btn_nextRound.Image")));
            this.btn_nextRound.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_nextRound.Location = new System.Drawing.Point(439, 497);
            this.btn_nextRound.Margin = new System.Windows.Forms.Padding(2);
            this.btn_nextRound.Name = "btn_nextRound";
            this.btn_nextRound.Size = new System.Drawing.Size(152, 27);
            this.btn_nextRound.TabIndex = 14;
            this.btn_nextRound.Text = "NEXT TURN";
            this.btn_nextRound.UseVisualStyleBackColor = true;
            // 
            // btn_send
            // 
            this.btn_send.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_send.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(648, 424);
            this.btn_send.Margin = new System.Windows.Forms.Padding(2);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(97, 31);
            this.btn_send.TabIndex = 17;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_disconnect.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_disconnect.Image = ((System.Drawing.Image)(resources.GetObject("btn_disconnect.Image")));
            this.btn_disconnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_disconnect.Location = new System.Drawing.Point(595, 497);
            this.btn_disconnect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(149, 27);
            this.btn_disconnect.TabIndex = 18;
            this.btn_disconnect.Text = "DISCONNECT";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // infoText
            // 
            this.infoText.BackColor = System.Drawing.SystemColors.HighlightText;
            this.infoText.ForeColor = System.Drawing.SystemColors.InfoText;
            this.infoText.Location = new System.Drawing.Point(439, 11);
            this.infoText.Margin = new System.Windows.Forms.Padding(2);
            this.infoText.Multiline = true;
            this.infoText.Name = "infoText";
            this.infoText.ReadOnly = true;
            this.infoText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoText.Size = new System.Drawing.Size(307, 352);
            this.infoText.TabIndex = 19;
            // 
            // pPlayer1
            // 
            this.pPlayer1.ColumnCount = 6;
            this.pPlayer1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.pPlayer1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.pPlayer1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.pPlayer1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66889F));
            this.pPlayer1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66889F));
            this.pPlayer1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.pPlayer1.Location = new System.Drawing.Point(9, 113);
            this.pPlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.pPlayer1.Name = "pPlayer1";
            this.pPlayer1.RowCount = 4;
            this.pPlayer1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pPlayer1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pPlayer1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pPlayer1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pPlayer1.Size = new System.Drawing.Size(426, 409);
            this.pPlayer1.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66556F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(750, 115);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 409);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(1185, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pPlayer1);
            this.Controls.Add(this.infoText);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_Resolve);
            this.Controls.Add(this.btn_discard);
            this.Controls.Add(this.btn_nextRound);
            this.Controls.Add(this.txt_mess);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.btn_connect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameForm";
            this.Text = "Indovina Chi?!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_mess;
        private System.Windows.Forms.Button btn_Resolve;
        private System.Windows.Forms.Button btn_discard;
        private System.Windows.Forms.Button btn_nextRound;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.TextBox infoText;
        private System.Windows.Forms.TableLayoutPanel pPlayer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}