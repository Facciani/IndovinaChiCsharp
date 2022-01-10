using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndovinaChiCSharp
{
    class Gestore_Turno : Messaggio
    {
        String nomeDest;

        public Gestore_Turno(IPEndPoint riceveEP, byte[] dataReceived) : base(riceveEP, dataReceived)
        {

        }

        public override void execute()
        {
            Console.WriteLine("DENTRO MESS_Turno");
            String[] csv = Encoding.ASCII.GetString(packet).Split(';');
            String risp = csv[0];
            if (risp == "t")
            {
                c.turno = true;
                c.form.invokeTurn();
                c.form.invokeAbilitaClick();
                c.form.invokeDiscardAC();
            }
        }
    }
}
