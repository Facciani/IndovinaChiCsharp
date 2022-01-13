using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndovinaChiCSharp
{
    class Messaggio_RispoIndovinato : Messaggio
    {
        public Messaggio_RispoIndovinato(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {

        }

        public override void execute()
        {
            Console.WriteLine("DENTRO MESS_RispostaIndovina");
            String[] csv = Encoding.ASCII.GetString(packet).Split(';');
            String risp = csv[0];
            if (risp == "iv")
            {
                c.form.invokeIMGWOL(1);
                
                c.form.invokeCancIMG();
                c.form.invokeDisabilitaClick();
                c.form.invokeDisabilitaDiscard();
                c.form.invokeDisableResolve();
                c.form.invokeDisabilitaNextTurn();

                c.form.invokeIstaziaVettori();

                c.isReady = false;
                c.isReadyDest = false;

                c.form.invokeAbiitaRivincita();

                c.form.invokeCANCPRes();

                /*g.personaggi = new List<int>();
                c.Game = false;
                c.isReady = false;
                c.isReadyDest = false;*/
            }
            else
            {
                c.form.sendRispo();
            }


        }
    }
}
