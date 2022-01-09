using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndovinaChiCSharp
{
    internal class Game
    {
        Random r;
        public int personaggioScelto;
        public static Game instance = null;
        public const int MAXPERSONAGGI =24;

        public Game()
        {
            personaggioScelto = 0;
            r = new Random();
        }

        public static Game Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Game();
                }
                return instance;
            }
        }

        public static Game getInstance()
        {
            if (instance == null)
            {
                instance = new Game();
            }
            return instance;
        }

        public void EstraiPrescelto()
        {
            personaggioScelto = r.Next(MAXPERSONAGGI);
        }
    }
}
