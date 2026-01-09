using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyramida
{
    class Program
    {
        static void Main(string[] args)
        {
            int velkost; Console.WriteLine("ZADAJTE VELKOST PYRAMIDY");
            velkost = Int32.Parse(Console.ReadLine());
            for (int i = 1; i < velkost; i = i + 1)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                for (int a = 1; a < velkost - i; a = a + 1)
                {
                    Console.Write(" ");
                }

                Console.BackgroundColor = ConsoleColor.Red;
                for (int b = 1; b < i; b = b + 1)
                {
                    Console.Write("  ");
                }


                Console.WriteLine();
            }
                Console.ReadKey();
        }
    }
}
