﻿using System;
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
    public partial class GameForm : Form
    {
        Listen listen;
        Thread t;
        UdpClient u;
        int port = 666;
        public GameForm()
        {
            InitializeComponent();
            this.u = new UdpClient(12345);
            this.listen = new Listen(u);
            this.t = new Thread(listen.Run);
            
            t.Start();

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

        private void btn_connect_Click(object sender, EventArgs e)
        {
            String ipname = txt_ip.Text;
            if (ipname != "")
            {
                try
                {
                    Console.WriteLine("P inviato");
                    Condivisa c = Condivisa.getInstance();
                    c.mittente = true;
                    String str = "a;" + c.nome + ";";
                    byte[] buffer = Encoding.ASCII.GetBytes(str);
                    string ip = ipname;
                    Gestore_pacchetti gp = Gestore_pacchetti.getInstance();
                    gp.connectedIP = ip;
                    Condivisa.getInstance().serverInvio.Send(buffer, buffer.Length, ip, port);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                DialogResult dialogResult = MessageBox.Show("Connessione...", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Cancel)
                {
                    try
                    {
                        Condivisa c = Condivisa.getInstance();
                        Gestore_pacchetti gp = Gestore_pacchetti.getInstance();
                        c.mittente = false;
                        String str = "n;" + c.nome + ";";
                        byte[] buffer = Encoding.ASCII.GetBytes(str);
                        string ip = ipname;
                        gp.connectedIP = ip;
                        Condivisa.getInstance().serverInvio.Send(buffer, buffer.Length, ip, port);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    MessageBox.Show("Connessione annullata...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
