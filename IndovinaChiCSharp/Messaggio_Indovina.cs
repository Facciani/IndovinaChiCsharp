using System;
using System.Collections.Generic;
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
            }
            else
            {
                send("ip;");
            }


        }
    }
}
