using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga
{
    class Raketaa
    {
        int Y;
        int MaxX;
        int X;
        public Raketaa(int y, int maxX)
        {
            Y = y;
            MaxX = maxX;
            X = MaxX / 2;
            Nakresli(false);
        }
        private void Nakresli(bool vymaz)
        {
            if (vymaz)
                Console.ForegroundColor = ConsoleColor.Black;
            else 
                Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(X, Y-2);
            Console.Write("˄");
            Console.SetCursorPosition(X, Y-1);
            Console.Write("█");
            if (!vymaz)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(X, Y);
            Console.Write("M");
           Console.ForegroundColor = ConsoleColor.White;
        }
        public bool PosunVlavo()
        {
            if (X > 1)
            {
                // zmaze raketu
                Nakresli(true);
                X--;
                // nakresli raketu
                Nakresli(false);
                return true;
            }
            return false;
        }
        public bool PosunVpravo()
        {
            if (X < MaxX -3)
            {
                Nakresli(true);
                X++;
                Nakresli(false);
                return true;
            }
            return false;

        }
        public bool JeBuracka(int XMeteoritu)
        {
            if (XMeteoritu == X)
            {
                return true;
            }
            return false;
        }
    }
}
