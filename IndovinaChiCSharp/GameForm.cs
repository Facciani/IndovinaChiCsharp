using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndovinaChiCSharp
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            this.txt_ip.GotFocus += RemoveText;
            this.txt_ip.LostFocus += AddText;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (this.txt_ip.Text == "Enter ip here...")
            {
                this.txt_ip.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txt_ip.Text))
                this.txt_ip.Text = "Enter ip here...";
        }

    }
}
