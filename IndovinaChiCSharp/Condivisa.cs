﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    public class Condivisa
    {
        public UdpClient serverRicezione;
        public string nome;
        public string nomeDestinatario;
        public static Condivisa instance = null;
        public bool mittente;
        public UdpClient serverInvio;
        public string messaggio = "";
        public bool connected = false;

        private Condivisa()
        {
            // gPacket = new Gestore_Packet();
            this.serverRicezione = new UdpClient(12345);
            serverInvio = new UdpClient();
            mittente = false;
            nomeDestinatario = "";
            nome = "";
        }


        public static Condivisa Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Condivisa();
                }
                return instance;
            }
        }


        public bool isMittente()
        {
            bool temp = mittente;
            mittente = false;
            return temp;
        }


        public static Condivisa getInstance()
        {
            if (instance == null)
            {
                instance = new Condivisa();
            }
            return instance;
        }
    }
}
