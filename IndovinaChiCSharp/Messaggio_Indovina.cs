using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    class Messaggio_Indovina : Messaggio
    {
        public Messaggio_Indovina(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {

        }

        public override void execute()
        {
            Console.WriteLine("DENTRO MESS_Indovina");
            String[] csv = Encoding.ASCII.GetString(packet).Split(';');
            int risp = int.Parse(csv[1]);
            if (risp == g.personaggioScelto)
            {
                send("iv;");
                c.form.invokeIMGWOL(2);

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
            }
            else
            {
                send("ip;");
            }


        }
    }
}
