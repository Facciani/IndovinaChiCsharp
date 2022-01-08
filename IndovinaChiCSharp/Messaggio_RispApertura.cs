using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    class Messaggio_RispApertura : Messaggio
    {
        String nomeDest;

        public Messaggio_RispApertura(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {

        }

        public override void execute()
        {
            Console.WriteLine("DENTRO MESS_RISP_APER_EXEC");
            String[] csv = Encoding.ASCII.GetString(packet).Split(';');
            String risp = csv[0];
            if (risp=="y" && c.isMittente())
            {
                c.connected = true;
                c.nomeDestinatario = csv[1];
                c.form.invokeLabelSfida(1);
                c.form.invokeReady();
                String str = "y;";
                send(str);
            }
            else if (risp=="y")
            {
                c.connected = true;
            }
            else if (risp=="n")
            {

            }

        }
    }
}




