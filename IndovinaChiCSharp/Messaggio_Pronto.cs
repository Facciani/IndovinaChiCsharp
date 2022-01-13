using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndovinaChiCSharp
{
    internal class Messaggio_Pronto : Messaggio
    {
        String nomeDest;

        public Messaggio_Pronto(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {

        }

        public override void execute()
        {
            Console.WriteLine("DENTRO MESS_PRONTO");
            String[] csv = Encoding.ASCII.GetString(packet).Split(';');
            String risp = csv[0];
            if (risp == "p" && c.isReady)
            {
                c.isReadyDest = true;
                c.Game = true;
                MessageBox.Show("IL GIOCO E' INIZIATO", "AVVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                c.form.invokeReady();
                c.form.invokePrescelto();
                c.form.invokeIMG();
                c.form.invokeGreenIMG();
                c.form.invokeDisabilitaClick();
                c.form.invokeLabelVisibili();
            }
            else if (risp == "p" && !c.isReady)
            {
                c.isReadyDest = true;
                MessageBox.Show("il tuo sfidante è pronto per iniziare la partita, se anche tu desideri esserlo fai click sul bottone pronto", "AVVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
