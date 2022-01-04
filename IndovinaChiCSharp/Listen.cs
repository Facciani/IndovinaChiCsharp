using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    class Listen
    {
        Condivisa c;
        Gestore_pacchetti gPacket;
        UdpClient client;

        public Listen(UdpClient c)
        {
            client = c;
            this.c = Condivisa.getInstance();
            gPacket = Gestore_pacchetti.getInstance();
        }

        public void Run()
        {
            while(true)
            {
                IPEndPoint riceveEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataReceived = client.Receive(ref riceveEP);
                String risposta = Encoding.ASCII.GetString(dataReceived);
            }
        }

    }
}
