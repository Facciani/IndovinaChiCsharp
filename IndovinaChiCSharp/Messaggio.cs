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
        protected byte[] packet;
        protected int lastPort;
        protected string lastIP;
        protected Condivisa c;


        public Messaggio()
        {
           
        }
        public Messaggio(IPEndPoint riceveEP, byte[] dataReceived)
        {
            packet = dataReceived;
            lastPort = 666;
            lastIP = riceveEP.Address.ToString();
            this.c = Condivisa.getInstance();
        }

        public virtual void execute()
        {

        }

        public void send(String str)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(str);
            Console.WriteLine("Dentro MESSAGGIO SEND");
            c.serverInvio.Send(buffer, buffer.Length, lastIP, lastPort); 
        }
    }
}
