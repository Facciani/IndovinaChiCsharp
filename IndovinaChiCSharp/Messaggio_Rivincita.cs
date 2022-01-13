using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndovinaChiCSharp
{
    class Messaggio_Rivincita : Messaggio
    {
        public Messaggio_Rivincita(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {

        }

        public override void execute()
        {
            Console.WriteLine("DENTRO MESS_PRONTO");
            String[] csv = Encoding.ASCII.GetString(packet).Split(';');
            String risp = csv[0];
            if (risp == "r" && c.riv)
            {
                MessageBox.Show("LA RIVINCITA E' INIZIATA", "AVVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                c.form.invokeReadyTrue();
                c.form.invokeDisabilitaRivi();
                g.personaggi = new List<int>();
                c.rivDest = false;
                c.riv = false;
            }
            else if (risp == "r" && !c.riv)
            {
                c.rivDest = true;
                MessageBox.Show("il tuo sfidante è pronto per rifare la partita, se anche tu desideri esserlo fai click sul bottone pronto", "AVVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
