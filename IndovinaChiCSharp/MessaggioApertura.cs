using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndovinaChiCSharp
{
    class MessaggioApertura : Messaggio
    {
        String nomeMittente;

        public MessaggioApertura(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP,dataReceived)
        {
            nomeMittente = "";
        }

        public override void execute()
        {
            String[] csv = (Encoding.ASCII.GetString(packet)).Split(';');
            DialogResult dialogResult = MessageBox.Show("Desideri accettare la connessione con: \n" + csv[1], "Avviso di connessione", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            String str = "";
            if (dialogResult == DialogResult.Yes)
            {
               
                c.connected = true;
                str = ("y;" + c.nome + ";");
                c.nomeDestinatario = csv[1];

            }
            else
            {
                str = "n;";
            }
            try
            {
                send(str);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
