using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    class Messaggio
    {
        byte[] packet;
        int lastPort;
        string lastIP;
        Condivisa c;

        public Messaggio(IPEndPoint riceveEP, byte[] dataReceived)
        {
            packet = dataReceived;
            lastPort = 666;
            lastIP = riceveEP.Address.ToString();
            this.c = Condivisa.getInstance();
        }

        public void send(String str)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(str);
            Console.WriteLine("Dentro MESSAGGIO SEND");
            c.serverInvio.Send(buffer, buffer.Length, lastIP, lastPort); 
        }
    }
}
