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
        Condivisa c;
        public Login()
        {
            InitializeComponent();
            this.c = Condivisa.getInstance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(tbUser1.Text=="")
           {
                MessageBox.Show("Attenzione inserire nome utente prima di proseguire", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
            else
            {
                c.nome = tbUser1.Text;
                GameForm g = new GameForm();
                g.Show();
                this.Hide();
            }
        }
    }
}
