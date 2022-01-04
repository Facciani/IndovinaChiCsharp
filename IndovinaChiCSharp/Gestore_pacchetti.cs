using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    class Gestore_pacchetti
    {
        string connectedIP = null;
        Condivisa c;
        static Gestore_pacchetti instance = null;

        private Gestore_pacchetti()
        {
            c = Condivisa.getInstance();
        }

        public static Gestore_pacchetti getInstance()
        {
            if (instance == null)
            {
                instance = new Gestore_pacchetti();
            }
            return instance;
        }

        public void execute(IPEndPoint p,byte[] buffer)

        {
            String s = Encoding.ASCII.GetString(buffer);
            String action = s.Split(';')[0];
            
            Console.WriteLine("ACTION: " + action);
            if (action == ("a"))
            {
                connectedIP = p.Address.ToString();
                Messaggio_Apertura ma = new Messaggio_Apertura();
                ma.execute();
            }
            else if (p.Address.ToString() == connectedIP)
            {
                switch (action)
                {
                    case "c":
                        {
                            Messaggio_Chiusura mc = new Messaggio_Chiusura();
                            mc.execute();
                            connectedIP = null;
                            break;
                        }
                    case "m":
                        {
                            Messaggio_Testo mt = new Messaggio_Testo();
                            mt.execute();
                            break;
                        }
                    case "y":
                        {
                            connectedIP = p.Address.ToString();
                            Messaggio_RispApertura mar = new Messaggio_RispApertura();
                            mar.execute();
                            break;
                        }
                    case "n":
                        {
                            connectedIP = null;
                            break;
                        }
                }
            }

        }
    }
}

