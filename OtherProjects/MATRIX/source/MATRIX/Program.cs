using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATRIX
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                for (int p = 160; p > 0; p = p - 1)
                {
                    int pes = rnd.Next(0, 9);
                    //Console.ForegroundColor = (ConsoleColor) pes;
                    Console.Write(pes);
                    
                }
                
            } while (true);



            
        }
    }
}
