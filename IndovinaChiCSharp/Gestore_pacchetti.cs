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
        public string connectedIP = null;
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

        public void execute(IPEndPoint p, byte[] buffer)
        {
            String s = Encoding.ASCII.GetString(buffer);
            String action = s.Split(';')[0];

            string g = p.Address.ToString();

            /*if(g == "127.0.0.1")
            {
                g = "localhost";
            }*/


            Console.WriteLine("ACTION: " + action);
            switch (action)
            {
                case "a":
                    {
                        connectedIP = p.Address.ToString();
                        MessaggioApertura ma = new MessaggioApertura(p, buffer);
                        ma.execute();
                        break;
                    }
                case "t":
                    {
                        Gestore_Turno gs = new Gestore_Turno(p, buffer);
                        gs.execute();
                        break;
                    }
                case "c":
                    {
                        Messaggio_Chiusura mc = new Messaggio_Chiusura(p, buffer);
                        mc.execute();
                        connectedIP = null;
                        break;
                    }
                case "m":
                    {
                        Messaggio_Testo mt = new Messaggio_Testo(p, buffer);
                        mt.execute();
                        break;
                    }
                case "s":
                    {
                        Messaggio_Su mt = new Messaggio_Su(p, buffer);
                        mt.execute();
                        break;
                    }
                case "i":
                    {
                        Messaggio_Indovina mt = new Messaggio_Indovina(p, buffer);
                        mt.execute();
                        break;
                    }
                case "iv":
                    {
                        Messaggio_RispoIndovinato mt = new Messaggio_RispoIndovinato(p, buffer);
                        mt.execute();
                        break;
                    }
                case "ip":
                    {
                        Messaggio_RispoIndovinato mt = new Messaggio_RispoIndovinato(p, buffer);
                        mt.execute();
                        break;
                    }
                case "g":
                    {
                        Messaggio_Giu mt = new Messaggio_Giu(p, buffer);
                        mt.execute();
                        break;
                    }
                case "y":
                    {
                        connectedIP = g;
                        Messaggio_RispApertura mar = new Messaggio_RispApertura(p, buffer);
                        mar.execute();
                        break;
                    }
                case "p":
                    {
                        Messaggio_Pronto mp = new Messaggio_Pronto(p, buffer);
                        mp.execute();
                        break;
                    }
                case "r":
                    {
                        Messaggio_Rivincita mp = new Messaggio_Rivincita(p, buffer);
                        mp.execute();
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

