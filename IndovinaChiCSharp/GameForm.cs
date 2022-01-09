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
        int port = 12345;
        Condivisa c;
        Game g;
        RossoVerde[] rossoVerde = new RossoVerde[24];

        public GameForm()
        {
            InitializeComponent();
            this.listen = new Listen();
            this.t = new Thread(listen.Run);

            t.Start();

            this.txt_ip.GotFocus += RemoveText;
            this.txt_ip.LostFocus += AddText;

            c = Condivisa.getInstance();
            g = Game.getInstance();
            c.setForm(this);

            string[] p = {"a1m", "a2m", "a3m" , "a4m" , "a5m" , "a6m",
                              "b1m", "b2m", "b3m", "b4m", "b5m", "b6m",
                              "c1m", "c2m", "c3m", "c4m", "c5m", "c6m",
                              "d1m", "d2m", "d3m", "d4m", "d5m", "d6m"};

            for (int i = 0; i < rossoVerde.Length; i++)
            {
                rossoVerde[i].str = p[i];
                rossoVerde[i].b = true;
            }

        }

        public void invokeAbilitaClick()
        {
            BeginInvoke(new Action(() => { abilitaClick(); }));
        }

        public void invokeDisabilitaClick()
        {
            BeginInvoke(new Action(() => { disabilitaClick(); }));
        }

        public void invokeMess(string mess)
        {
            BeginInvoke(new Action(() => { infoText.Text += c.nomeDestinatario + "--> " + mess + Environment.NewLine + Environment.NewLine; }));
        }

        public void invokeReady()
        {
            BeginInvoke(new Action(() => { btnReady.Enabled = !btnReady.Enabled; }));
        }

        public void invokeTurn()
        {
            BeginInvoke(new Action(() => { btn_nextRound.Enabled = true; }));
        }

        public void invokeReadyFalse()
        {
            BeginInvoke(new Action(() => { btnReady.Enabled = false; }));
        }

        public void invokePrescelto()
        {
            BeginInvoke(new Action(() =>
            {
                g.EstraiPrescelto();
                Image image = Image.FromFile(@"..\..\Images\" + g.personaggioScelto + ".png");
                prescelto.Image = image;
            }));
        }

        public void invokePresceltoNull()
        {
            BeginInvoke(new Action(() =>
            {
                prescelto.Image = null;
            }));
        }




        public void invokeLabelSfida(int i)
        {
            if (i == 1)
            {
                BeginInvoke(new Action(() => { titoloSfida.Text += c.nome + " vs " + c.nomeDestinatario; }));
            }
            else
            {
                BeginInvoke(new Action(() => { titoloSfida.Text = ""; }));
            }

        }


        public void invokeMess()
        {
            BeginInvoke(new Action(() => { infoText.Text = ""; }));
        }

        public void invokeIMG()
        {
            BeginInvoke(new Action(() => { assegnaImg(); }));
        }

        public void invokeCancIMG()
        {
            BeginInvoke(new Action(() => { cancellaImg(); }));
        }

        public void invokeGreenIMG()
        {
            BeginInvoke(new Action(() => { addGreenImg(); }));
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
                    Thread.Sleep(1000);
                    txt_mess.Text = "";
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
                        //infoText.Text += c.nome + "--> HA ESEGUITO LA DISCONNESSIONE(la chat verrà eliminata in 3 secondi!)";
                        infoText.Text = "";
                        gp.connectedIP = null;
                        c.nomeDestinatario = "";
                        infoText.Text = "";
                        titoloSfida.Text = "";
                        btnReady.Enabled = false;
                        c.Game = false;
                        c.isReady = false;
                        c.isReadyDest = false;
                        prescelto.Image = null;
                        cancellaImg();
                        g.personaggi = new List<int>();
                        disabilitaClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Connettersi con un host", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (c.connected)
            {
                try
                {
                    Console.WriteLine("inizio invio pronto");
                    String ipname = Gestore_pacchetti.getInstance().connectedIP;
                    String str = "p;";
                    byte[] buffer = Encoding.ASCII.GetBytes(str);
                    string pronto = ipname;
                    c.serverInvio.Send(buffer, buffer.Length, ipname, port);
                    c.isReady = true;
                    if (c.isReady && c.isReadyDest)
                    {
                        MessageBox.Show("IL GIOCO E' INIZIATO", "AVVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        c.Game = true;
                        c.turno = true;
                        //btn_discard.Enabled = true;
                        btn_nextRound.Enabled = true;
                        btnReady.Enabled = false;
                        g.EstraiPrescelto();
                        Image image = Image.FromFile(@"..\..\Images\" + g.personaggioScelto + ".png");
                        prescelto.Image = image;
                        assegnaImg();
                        addGreenImg();
                        abilitaClick();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }


        }


        public void disabilitaClick()
        {
            PictureBox[] p = {a1m, a2m , a3m , a4m , a5m , a6m,
                              b1m, b2m, b3m, b4m, b5m, b6m,
                              c1m, c2m, c3m, c4m, c5m, c6m,
                              d1m, d2m, d3m, d4m, d5m, d6m};
            for (int i = 0; i < p.Length; i++)
            {
                p[i].Enabled = false;
            }
        }

        public void abilitaClick()
        {
            PictureBox[] p = {a1m, a2m , a3m , a4m , a5m , a6m,
                              b1m, b2m, b3m, b4m, b5m, b6m,
                              c1m, c2m, c3m, c4m, c5m, c6m,
                              d1m, d2m, d3m, d4m, d5m, d6m};
            for (int i = 0; i < p.Length; i++)
            {
                p[i].Enabled = true;
            }
        }
        public void assegnaImg()
        {
            PictureBox[] p = {a1m, a2m , a3m , a4m , a5m , a6m,
                              b1m, b2m, b3m, b4m, b5m, b6m,
                              c1m, c2m, c3m, c4m, c5m, c6m,
                              d1m, d2m, d3m, d4m, d5m, d6m};
            g.InsertRandomP();
            for (int i = 0; i < g.personaggi.Count; i++)
            {
                Image image = Image.FromFile(@"..\..\Images\" + g.personaggi[i] + ".png");
                p[i].Image = image;
            }
        }

        public void cancellaImg()
        {
            PictureBox[] p = {a1m, a2m , a3m , a4m , a5m , a6m,
                              b1m, b2m, b3m, b4m, b5m, b6m,
                              c1m, c2m, c3m, c4m, c5m, c6m,
                              d1m, d2m, d3m, d4m, d5m, d6m,
                                                            };
            PictureBox[] s = {a1d, a2d , a3d , a4d , a5d , a6d,
                              b1d, b2d, b3d, b4d, b5d, b6d,
                              c1d, c2d, c3d, c4d, c5d, c6d,
                              d1d, d2d, d3d, d4d, d5d, d6d};
            for (int i = 0; i < p.Length; i++)
            {
                p[i].Image = null;
            }
            for (int i = 0; i < s.Length; i++)
            {
                s[i].BackColor = Color.DarkTurquoise;
            }
        }

        public void addGreenImg()
        {
            PictureBox[] p = {a1d, a2d , a3d , a4d , a5d , a6d,
                              b1d, b2d, b3d, b4d, b5d, b6d,
                              c1d, c2d, c3d, c4d, c5d, c6d,
                              d1d, d2d, d3d, d4d, d5d, d6d};
            for (int i = 0; i < p.Length; i++)
            {
                p[i].BackColor = Color.Green;
            }
        }


        private void btn_nextRound_Click(object sender, EventArgs e)
        {
            if (c.connected && c.Game)
            {
                try
                {
                    Console.WriteLine("inizio invio turno");
                    String ipname = Gestore_pacchetti.getInstance().connectedIP;
                    String str = "t;";
                    byte[] buffer = Encoding.ASCII.GetBytes(str);
                    string pronto = ipname;
                    c.serverInvio.Send(buffer, buffer.Length, ipname, port);

                    btn_nextRound.Enabled = false;
                    disabilitaClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void a1m_Click(object sender, EventArgs e)
        {
            if (a1m.BackColor == Color.DarkTurquoise)
            {
                a1m.BackColor = Color.Green;
            }
            else if (a1m.BackColor == Color.Red)
            {
                a1m.BackColor = Color.Green;
            }
            else if (a1m.BackColor == Color.Green)
            {
                if (rossoVerde[0].b == false)
                {
                    a1m.BackColor = Color.Red;
                }
                else
                {
                    a1m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        struct RossoVerde
        {
            public bool b;
            public string str;
        }

        private void a2m_Click(object sender, EventArgs e)
        {
            if (a2m.BackColor == Color.DarkTurquoise)
            {
                a2m.BackColor = Color.Green;
            }
            else if (a1m.BackColor == Color.Red)
            {
                a2m.BackColor = Color.Green;
            }
            else if (a2m.BackColor == Color.Green)
            {
                if (rossoVerde[1].b == false)
                {
                    a2m.BackColor = Color.Red;
                }
                else
                {
                    a2m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void a3m_Click(object sender, EventArgs e)
        {
            if (a3m.BackColor == Color.DarkTurquoise)
            {
                a3m.BackColor = Color.Green;
            }
            else if (a3m.BackColor == Color.Red)
            {
                a3m.BackColor = Color.Green;
            }
            else if (a3m.BackColor == Color.Green)
            {
                if (rossoVerde[2].b == false)
                {
                    a3m.BackColor = Color.Red;
                }
                else
                {
                    a3m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void a4m_Click(object sender, EventArgs e)
        {
            if (a4m.BackColor == Color.DarkTurquoise)
            {
                a4m.BackColor = Color.Green;
            }
            else if (a4m.BackColor == Color.Red)
            {
                a4m.BackColor = Color.Green;
            }
            else if (a4m.BackColor == Color.Green)
            {
                if (rossoVerde[3].b == false)
                {
                    a4m.BackColor = Color.Red;
                }
                else
                {
                    a4m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void a5m_Click(object sender, EventArgs e)
        {
            if (a5m.BackColor == Color.DarkTurquoise)
            {
                a5m.BackColor = Color.Green;
            }
            else if (a5m.BackColor == Color.Red)
            {
                a5m.BackColor = Color.Green;
            }
            else if (a5m.BackColor == Color.Green)
            {
                if (rossoVerde[4].b == false)
                {
                    a5m.BackColor = Color.Red;
                }
                else
                {
                    a5m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void a6m_Click(object sender, EventArgs e)
        {
            if (a6m.BackColor == Color.DarkTurquoise)
            {
                a6m.BackColor = Color.Green;
            }
            else if (a6m.BackColor == Color.Red)
            {
                a6m.BackColor = Color.Green;
            }
            else if (a6m.BackColor == Color.Green)
            {
                if (rossoVerde[5].b == false)
                {
                    a6m.BackColor = Color.Red;
                }
                else
                {
                    a6m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void b1m_Click(object sender, EventArgs e)
        {
            if (b1m.BackColor == Color.DarkTurquoise)
            {
                b1m.BackColor = Color.Green;
            }
            else if (b1m.BackColor == Color.Red)
            {
                b1m.BackColor = Color.Green;
            }
            else if (b1m.BackColor == Color.Green)
            {
                if (rossoVerde[6].b == false)
                {
                    b1m.BackColor = Color.Red;
                }
                else
                {
                    b1m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void b2m_Click(object sender, EventArgs e)
        {
            if (b2m.BackColor == Color.DarkTurquoise)
            {
                b2m.BackColor = Color.Green;
            }
            else if (b2m.BackColor == Color.Red)
            {
                b2m.BackColor = Color.Green;
            }
            else if (b2m.BackColor == Color.Green)
            {
                if (rossoVerde[7].b == false)
                {
                    b2m.BackColor = Color.Red;
                }
                else
                {
                    b2m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void b3m_Click(object sender, EventArgs e)
        {
            if (b3m.BackColor == Color.DarkTurquoise)
            {
                b3m.BackColor = Color.Green;
            }
            else if (b3m.BackColor == Color.Red)
            {
                b3m.BackColor = Color.Green;
            }
            else if (b3m.BackColor == Color.Green)
            {
                if (rossoVerde[8].b == false)
                {
                    b3m.BackColor = Color.Red;
                }
                else
                {
                    b3m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void b4m_Click(object sender, EventArgs e)
        {
            if (b4m.BackColor == Color.DarkTurquoise)
            {
                b4m.BackColor = Color.Green;
            }
            else if (b4m.BackColor == Color.Red)
            {
                b4m.BackColor = Color.Green;
            }
            else if (b4m.BackColor == Color.Green)
            {
                if (rossoVerde[9].b == false)
                {
                    b4m.BackColor = Color.Red;
                }
                else
                {
                    b4m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void b5m_Click(object sender, EventArgs e)
        {
            if (b5m.BackColor == Color.DarkTurquoise)
            {
                b5m.BackColor = Color.Green;
            }
            else if (b5m.BackColor == Color.Red)
            {
                b5m.BackColor = Color.Green;
            }
            else if (b5m.BackColor == Color.Green)
            {
                if (rossoVerde[10].b == false)
                {
                    b5m.BackColor = Color.Red;
                }
                else
                {
                    b5m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void b6m_Click(object sender, EventArgs e)
        {
            if (b6m.BackColor == Color.DarkTurquoise)
            {
                b6m.BackColor = Color.Green;
            }
            else if (b6m.BackColor == Color.Red)
            {
                b6m.BackColor = Color.Green;
            }
            else if (b6m.BackColor == Color.Green)
            {
                if (rossoVerde[11].b == false)
                {
                    b6m.BackColor = Color.Red;
                }
                else
                {
                    b6m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void c1m_Click(object sender, EventArgs e)
        {
            if (c1m.BackColor == Color.DarkTurquoise)
            {
                c1m.BackColor = Color.Green;
            }
            else if (c1m.BackColor == Color.Red)
            {
                c1m.BackColor = Color.Green;
            }
            else if (c1m.BackColor == Color.Green)
            {
                if (rossoVerde[12].b == false)
                {
                    c1m.BackColor = Color.Red;
                }
                else
                {
                    c1m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void c2m_Click(object sender, EventArgs e)
        {
            if (c2m.BackColor == Color.DarkTurquoise)
            {
                c2m.BackColor = Color.Green;
            }
            else if (c2m.BackColor == Color.Red)
            {
                c2m.BackColor = Color.Green;
            }
            else if (c2m.BackColor == Color.Green)
            {
                if (rossoVerde[13].b == false)
                {
                    c2m.BackColor = Color.Red;
                }
                else
                {
                    c2m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void c3m_Click(object sender, EventArgs e)
        {
            if (c3m.BackColor == Color.DarkTurquoise)
            {
                c3m.BackColor = Color.Green;
            }
            else if (c3m.BackColor == Color.Red)
            {
                c3m.BackColor = Color.Green;
            }
            else if (c3m.BackColor == Color.Green)
            {
                if (rossoVerde[14].b == false)
                {
                    c3m.BackColor = Color.Red;
                }
                else
                {
                    c3m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void c4m_Click(object sender, EventArgs e)
        {
            if (c4m.BackColor == Color.DarkTurquoise)
            {
                c4m.BackColor = Color.Green;
            }
            else if (c4m.BackColor == Color.Red)
            {
                c4m.BackColor = Color.Green;
            }
            else if (c4m.BackColor == Color.Green)
            {
                if (rossoVerde[15].b == false)
                {
                    c4m.BackColor = Color.Red;
                }
                else
                {
                    c4m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void c5m_Click(object sender, EventArgs e)
        {
            if (c5m.BackColor == Color.DarkTurquoise)
            {
                c5m.BackColor = Color.Green;
            }
            else if (c5m.BackColor == Color.Red)
            {
                c5m.BackColor = Color.Green;
            }
            else if (c5m.BackColor == Color.Green)
            {
                if (rossoVerde[16].b == false)
                {
                    c5m.BackColor = Color.Red;
                }
                else
                {
                    c5m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void c6m_Click(object sender, EventArgs e)
        {
            if (c6m.BackColor == Color.DarkTurquoise)
            {
                c6m.BackColor = Color.Green;
            }
            else if (c6m.BackColor == Color.Red)
            {
                c6m.BackColor = Color.Green;
            }
            else if (c6m.BackColor == Color.Green)
            {
                if (rossoVerde[17].b == false)
                {
                    c6m.BackColor = Color.Red;
                }
                else
                {
                    c6m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void d1m_Click(object sender, EventArgs e)
        {
            if (d1m.BackColor == Color.DarkTurquoise)
            {
                d1m.BackColor = Color.Green;
            }
            else if (d1m.BackColor == Color.Red)
            {
                d1m.BackColor = Color.Green;
            }
            else if (d1m.BackColor == Color.Green)
            {
                if (rossoVerde[18].b == false)
                {
                    d1m.BackColor = Color.Red;
                }
                else
                {
                    d1m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void d2m_Click(object sender, EventArgs e)
        {
            if (d2m.BackColor == Color.DarkTurquoise)
            {
                d2m.BackColor = Color.Green;
            }
            else if (d2m.BackColor == Color.Red)
            {
                d2m.BackColor = Color.Green;
            }
            else if (d2m.BackColor == Color.Green)
            {
                if (rossoVerde[19].b == false)
                {
                    d2m.BackColor = Color.Red;
                }
                else
                {
                    d2m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void d3m_Click(object sender, EventArgs e)
        {
            if (d3m.BackColor == Color.DarkTurquoise)
            {
                d3m.BackColor = Color.Green;
            }
            else if (d3m.BackColor == Color.Red)
            {
                d3m.BackColor = Color.Green;
            }
            else if (d3m.BackColor == Color.Green)
            {
                if (rossoVerde[20].b == false)
                {
                    d3m.BackColor = Color.Red;
                }
                else
                {
                    d3m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void d4m_Click(object sender, EventArgs e)
        {
            if (d4m.BackColor == Color.DarkTurquoise)
            {
                d4m.BackColor = Color.Green;
            }
            else if (d4m.BackColor == Color.Red)
            {
                d4m.BackColor = Color.Green;
            }
            else if (d4m.BackColor == Color.Green)
            {
                if (rossoVerde[21].b == false)
                {
                    d4m.BackColor = Color.Red;
                }
                else
                {
                    d4m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void d5m_Click(object sender, EventArgs e)
        {
            if (d5m.BackColor == Color.DarkTurquoise)
            {
                d5m.BackColor = Color.Green;
            }
            else if (d5m.BackColor == Color.Red)
            {
                d5m.BackColor = Color.Green;
            }
            else if (d5m.BackColor == Color.Green)
            {
                if (rossoVerde[22].b == false)
                {
                    d5m.BackColor = Color.Red;
                }
                else
                {
                    d5m.BackColor = Color.DarkTurquoise;
                }
            }
        }

        private void d6m_Click(object sender, EventArgs e)
        {
            if (d6m.BackColor == Color.DarkTurquoise)
            {
                d6m.BackColor = Color.Green;
            }
            else if (d6m.BackColor == Color.Red)
            {
                d6m.BackColor = Color.Green;
            }
            else if (d6m.BackColor == Color.Green)
            {
                if (rossoVerde[23].b == false)
                {
                    d6m.BackColor = Color.Red;
                }
                else
                {
                    d6m.BackColor = Color.DarkTurquoise;
                }
            }
        }
    }
}
