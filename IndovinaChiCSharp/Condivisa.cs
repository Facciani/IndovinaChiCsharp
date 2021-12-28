using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    class Condivisa
    {
        UdpClient serverRicezione;
        String nome;
        String nomeDestinatario;
        static Condivisa instance = null;
        bool mittente;
        UdpClient serverInvio;
        Login frame;
        String messaggio = "";
        bool connected = false;

        private Condivisa()
        {
            // gPacket = new Gestore_Packet();
            this.serverRicezione = new UdpClient(12345);
            serverInvio = new UdpClient();
            mittente = false;
            nomeDestinatario = "";
            nome = "Pluto";
        }

        /*public static Condivisa getInstance() {
            if (instance == null) {
                    synchronized(Condivisa.class) {
                    if (instance == null) {
                        instance = new Condivisa();
    }
        
    }
}
        return instance;
    
        */

        public void setFrame(Login frame)
        {
            this.frame = frame;
        }

        public bool isMittente()
        {
            bool temp = mittente;
            mittente = false;
            return temp;
        }
    }

}
