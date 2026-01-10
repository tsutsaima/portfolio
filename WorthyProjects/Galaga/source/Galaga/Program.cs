using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga
{
    class Program
    {
        static void Main(string[] args)
        {
            HraGalaga GameOn = new HraGalaga();
            GameOn.Hra(); 
            ConsoleKeyInfo key = Console.ReadKey(true);
            bool a = true;
            while (a)
            {
                switch (key.Key)
                {
                    case ConsoleKey.R:
                        Console.Clear();
                        HraGalaga Game = new HraGalaga();
                        Game.Hra();
                        break;
                    default:
                        a = false;
                        break;
                }
            }
        }
    }
}
