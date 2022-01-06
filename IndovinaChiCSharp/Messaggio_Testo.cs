using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    class Messaggio_Testo : Messaggio
    {
        String messaggio;

        public Messaggio_Testo(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {
            messaggio = "";
        }
        public override void execute()
        {
            string[] csv = Encoding.ASCII.GetString(packet).Split(';');
            messaggio = csv[1];
            c.form.invokeMess(messaggio);
            c.messaggio = messaggio;
        }
    }
}

