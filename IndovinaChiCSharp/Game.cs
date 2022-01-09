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
        public List<int> personaggi;


        public Game()
        {
            personaggi = new List<int>();
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
            personaggioScelto = r.Next(1, MAXPERSONAGGI + 1);
        }


        public void InsertRandomP()
        {
            int number = 0;
            for (int i = 0; i < 24; i++)
            {
                do
                {
                    number = r.Next(1, MAXPERSONAGGI+1);
                } while (personaggi.Contains(number));
                personaggi.Add(number);
            }
        }
    }
}
