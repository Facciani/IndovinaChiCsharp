using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    class Messaggio_Chiusura : Messaggio
    {
        String messaggio;
        public Messaggio_Chiusura(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {
        }
        public override void execute()
        {
            string[] csv = Encoding.ASCII.GetString(packet).Split(';');
            messaggio = csv[1];
            c.form.invokeMess("HA ESEGUITO LA DISCONNESSIONE(la chat verrà eliminata in 5 secondi!)");
            Thread.Sleep(5000);
            c.form.invokeMess();
            c.form.invokeLabelSfida(2);
            c.connected = false;
        }
    }
}
