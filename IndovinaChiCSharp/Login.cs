using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndovinaChiCSharp
{
    public partial class Login : Form
    {
        Listen l;
        UdpClient client = new UdpClient(666);
        public Login()
        {
            l = new Listen(client);
            InitializeComponent();
            Thread t = new Thread(l.Run);
            t.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
