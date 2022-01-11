using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndovinaChiCSharp
{
    class Messaggio_RispoIndovinato : Messaggio
    {
        public Messaggio_RispoIndovinato(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {

        }

        public override void execute()
        {
            Console.WriteLine("DENTRO MESS_RispostaIndovina");
            String[] csv = Encoding.ASCII.GetString(packet).Split(';');
            String risp = csv[0];
            if (risp == "iv")
            {
                MessageBox.Show("HAI VINTO!!!!!");
            }
            else
            {
                c.form.invokeNHIndovinato();
            }


        }
    }
}
