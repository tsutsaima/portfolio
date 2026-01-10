using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga
{
    class Meteorit
    {
        public enum TypMeteoritu
        {
            hviezda = 1,
            kruh = 2,
            nulka = 3
        }
        private TypMeteoritu typMeteoritu;
        public int Y {get; private set;}
        public int X {get; private set;}
        int MaxY;
        public Meteorit(int x, int maxY, TypMeteoritu typMeteoritu)
        {
            this.typMeteoritu = typMeteoritu;
            X = x ;
            MaxY = maxY;
            Y = 0;
            Nakresli(false);
        }
        private void Nakresli(bool vymaz)
        {
            if (vymaz)
            
                Console.ForegroundColor = ConsoleColor.Black;
            else
                Console.ForegroundColor = ConsoleColor.White;
           
            Console.SetCursorPosition(X,Y + 2);
            switch (typMeteoritu)
            {
                case TypMeteoritu.hviezda:
                    Console.Write("*");
                    break;
                case TypMeteoritu.nulka:
                    Console.Write("*");
                    break;
                case TypMeteoritu.kruh:
                    Console.Write("*");
                    break;
                    
            }
            
        }
        
        public bool Posun()
        {
            Nakresli(true);
            if (Y < MaxY-7)
            {
                Y++;
                Nakresli(false);
                return true;
            }
            return false;
        }

  /*      public bool Posun()
        {
            Nakresli(true);
            if (Y < MaxY)
            {
                Y++;
                Nakresli(false);
                return true;
            }
            return false;
        }*/
    }
}
