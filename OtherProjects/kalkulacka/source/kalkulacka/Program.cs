using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulacka
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal vysledok = 0;
            decimal vypocitane = 0;
            int cislo1;
            int cislo2;
            Random random = new Random();
            char[] operators = { '+', '-', '*', '/' };       
            char op = operators[random.Next(operators.Length)];
            while (vypocitane != -1 )
            {
            cislo1 = random.Next(50, 200);
            cislo2 = random.Next(50, cislo1);
            Console.WriteLine("pre ukoncenie programu napiste -1");
            Console.WriteLine(cislo1 + op + cislo2 + " = ");
            vypocitane = Convert.ToDecimal(Console.ReadLine());
            switch(op)
            {
                case '+':
                    vysledok = cislo1 + cislo2;
                    break;
                case '-':
                    vysledok = cislo1 - cislo2;
                    break;
                case '/':
                    vysledok = cislo1 / cislo2;
                    break;
                case '*':
                    vysledok = cislo1 * cislo2;
                    break;
                }
            if (vypocitane == vysledok) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DOBRE");
            }
            if (vypocitane != -1)
            {
                if (vypocitane != vysledok)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ZLE");
                }
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
            
            Console.ReadLine();
        }
    }
}
