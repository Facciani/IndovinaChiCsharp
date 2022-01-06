using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    public class Listen
    {
        Condivisa c;
        Gestore_pacchetti gPacket;

        public Listen()
        {
            this.c = Condivisa.getInstance();
            gPacket = Gestore_pacchetti.getInstance();
        }

        public void Run()
        {
            while(true)
            {
                try
                {
                    IPEndPoint riceveEP = new IPEndPoint(IPAddress.Any, 0);
                    

                    //String risposta = Encoding.ASCII.GetString(dataReceived);

                    byte[] b = c.serverRicezione.Receive(ref riceveEP);
                    gPacket.execute(riceveEP, b);

                    Console.WriteLine("messaggio ricevuto");

                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Thread.Sleep(150);
            }
        }

    }
}
