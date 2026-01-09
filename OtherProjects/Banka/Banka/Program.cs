using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka
{
    class Program
    {
        static void Main(string[] args)
        {
            Ucet MarekovUcet = new Ucet(500);
            Ucet PetovUcet = new Ucet(0);
            MarekovUcet.Vklad(100);
            PetovUcet.Vklad(1000);
            MarekovUcet.PrevodNaInyUcet(PetovUcet, 10);
            Console.WriteLine("stav Marekovho uctu: " + MarekovUcet.StavUctu() + " eur");
            Console.WriteLine("stav Petovho uctu: " + PetovUcet.StavUctu() + " eur");
            Console.ReadLine();

            string test;
            test = "abc";
            if (test.EndsWith("c"));
        }
    }
}
