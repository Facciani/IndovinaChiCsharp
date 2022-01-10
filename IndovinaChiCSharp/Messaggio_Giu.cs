using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndovinaChiCSharp
{
    internal class Messaggio_Giu : Messaggio
    {
        public Messaggio_Giu(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {

        }

        public override void execute()
        {
            Console.WriteLine("DENTRO MESS_Giu");
            String[] csv = Encoding.ASCII.GetString(packet).Split(';');
            String risp = csv[0];
            if (risp == "g" && c.isReady)
            {
                String[] csv1 = csv[1].Split(',');
                for (int i = 0; i < csv1.Length; i++)
                {
                    csv1[i] += "d";
                    c.form.invokeRed(csv1[i]);
                }

            }


        }
    }
}
