using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace objemobsah
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("vyber si bud vypocet obsahu alebo objemu");
            string vyber = Console.ReadLine();
            Console.WriteLine("vyber si utvar bud obdlznik alebo stvorec");
            string utvar = Console.ReadLine();
            int vypocet = 0;
            int parameter1 = 0;
            int parameter2 = 0;
            int parameter3 = 0;
            if (vyber == "obsah") 
            {
                if (utvar == "obdlznik")
                { 
                Console.WriteLine("zadaj sranu 1");
                    parameter1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("zadaj stranu 2");
                    parameter2 = Convert.ToInt32(Console.ReadLine());
                    vypocet = parameter1 * parameter2;
                    Console.WriteLine("obsah je " + vypocet);
                }
                else if (utvar == "stvorec")
                {
                    Console.WriteLine("zadaj sranu 1");
                    parameter1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("zadaj stranu 2");
                    parameter2 = Convert.ToInt32(Console.ReadLine());
                    vypocet = parameter1 * parameter2;
                    Console.WriteLine("obsah je " + vypocet);
                }
            }
            else if (vyber == "objem")
             {
                if (utvar == "obdlznik")
                { 
                Console.WriteLine("zadaj sranu 1");
                    parameter1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("zadaj stranu 2");
                    parameter2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("zadaj vysku");
                    parameter3 = Convert.ToInt32(Console.ReadLine());
                    vypocet = parameter1 * parameter2 * parameter3;
                    Console.WriteLine("obsah je " + vypocet);
                }
                else if (utvar == "stvorec")
                {
                    Console.WriteLine("zadaj sranu 1");
                    parameter1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("zadaj stranu 2");
                    parameter2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("zadaj vysku");
                    parameter3 = Convert.ToInt32(Console.ReadLine());
                    vypocet = parameter1 * parameter2 * parameter3;
                    Console.WriteLine("obsah je " + vypocet);
                    }
            }
            Console.ReadLine();
        }
    }
}
