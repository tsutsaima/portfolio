using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobazar
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoBazar Informacie = new AutoBazar();
            for (int i = 0; i < 100; i++)
            {
                Informacie.cars.Add(Extensions.GenerateRandomAuto());
            }
            int pocetx2 = 0;
            int poicetV4 = 0;
            int pocetSplnajucich = 0;
            for (int i = 0; i < Informacie.cars.Count; i++ )
            {
                if (Informacie.cars[i].Type == AutoType.X2)
                {
                    pocetx2++;
                }
                if (Informacie.cars[i].TypeOfEngine == EngineType.V4)
                {
                    poicetV4++;
                }
                if (Informacie.cars[i].Type == AutoType.X2 && Informacie.cars[i].TypeOfEngine == EngineType.V4)
                {
                    pocetSplnajucich++;
                }
                // pocet v4
                // pocet aut ktore splnaju oba paramtetre
            }
            Console.WriteLine("X2 je: " + pocetx2 + ".");
            Console.WriteLine("V4 je: " + poicetV4 + ".");
            Console.WriteLine("Splnajucich oba parametre je: " + pocetSplnajucich + ".");
                Console.ReadLine();
        }
         
    }
}