using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    class Messaggio_Chiusura : Messaggio
    {
        public Messaggio_Chiusura(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {
        }
        public override void execute()
        {
            c.connected = false;
        }
    }
}
