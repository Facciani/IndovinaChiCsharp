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
using System.Windows.Threading;
/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO.Ports;
using System.Windows.Shapes;
using System.Threading;*/

namespace IndovinaChiCSharp
{
    public partial class GameForm : Form
    {
        Listen listen;
        Thread t;
        UdpClient u;
        int port = 666;
        Condivisa c;

        public GameForm()
        {
            InitializeComponent();
            this.listen = new Listen();
            this.t = new Thread(listen.Run);

            t.Start();

            this.txt_ip.GotFocus += RemoveText;
            this.txt_ip.LostFocus += AddText;

            c = Condivisa.getInstance();
            c.setForm(this);
        }

        public void invokeMess(string mess)
        {
            BeginInvoke(new Action(() => { infoText.Text += c.nomeDestinatario + "--> " + mess + Environment.NewLine + Environment.NewLine; }));
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
                    //Condivisa c = Condivisa.getInstance();
                    c.mittente = true;
                    String str = "a;" + c.nome + ";";
                    byte[] buffer = Encoding.ASCII.GetBytes(str);
                    string ip = ipname;
                    Gestore_pacchetti gp = Gestore_pacchetti.getInstance();
                    gp.connectedIP = ip;
                    c.serverInvio.Send(buffer, buffer.Length, ip, port);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                DialogResult dialogResult = MessageBox.Show("Connessione...", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Cancel)
                {
                    try
                    {
                        //Condivisa c = Condivisa.getInstance();
                        Gestore_pacchetti gp = Gestore_pacchetti.getInstance();
                        c.mittente = false;
                        String str = "n;" + c.nome + ";";
                        byte[] buffer = Encoding.ASCII.GetBytes(str);
                        string ip = ipname;
                        gp.connectedIP = ip;
                        c.serverInvio.Send(buffer, buffer.Length, ip, port);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    MessageBox.Show("Connessione annullata...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                if (c.connected && txt_mess.Text != "")
                {
                    try
                    {
                        Console.WriteLine("MESSAGGIO INVIATO");
                        String ipname = Gestore_pacchetti.getInstance().connectedIP;
                        String str = "m;" + txt_mess.Text + ";";
                        byte[] buffer = Encoding.ASCII.GetBytes(str);
                        string ip = ipname;
                        c.serverInvio.Send(buffer, buffer.Length, ipname, port);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    //Condivisa c = Condivisa.getInstance();
                    infoText.Text += c.nome + "--> " + txt_mess.Text + Environment.NewLine + Environment.NewLine;                    
                }
                else
                {
                    MessageBox.Show("Connettersi con un host", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void scriviMessaggio(string str)
        {
            //Condivisa c = Condivisa.getInstance();
            infoText.Text += c.nomeDestinatario + "--> " + str + Environment.NewLine + Environment.NewLine;
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (c.connected)
                {
                    try
                    {
                        c.connected = false;
                        Gestore_pacchetti gp = Gestore_pacchetti.getInstance();
                        Console.WriteLine("Messaggio chiusura");
                        String ipname = Gestore_pacchetti.getInstance().connectedIP;
                        String str = "c;";
                        byte[] buffer = Encoding.ASCII.GetBytes(str);
                        string ip = ipname;
                        c.serverInvio.Send(buffer, buffer.Length, ipname, port);
                        gp.connectedIP = null;
                        c.nomeDestinatario = "";
                        infoText.Text = "";
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Connettersi con un host", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
