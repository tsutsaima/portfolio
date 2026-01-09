using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPola
{
    class Program
    {
        static void Main(string[] args)
        {
            int najmensie = 5000;
            int najvacsie = 0;
            Random r = new Random();
            List<int> poleCisiel = new List<int>();
            for (int i = 0; i < 100; i++)
            {

            
                poleCisiel.Add(r.Next(0, 5000));
                Console.Write(poleCisiel[i] + " ");
                if (poleCisiel[i] < najmensie)
                    najmensie = poleCisiel[i];
                if (poleCisiel[i] > najvacsie)
                    najvacsie = poleCisiel[i];
            }
            Console.WriteLine("");
            Console.WriteLine("Pocet cisiel je: " + poleCisiel.Count.ToString());
            int sucet = 0;
            for (int i = 0; i < poleCisiel.Count; i++)
            {
                sucet = sucet + poleCisiel[i];
            }
            Console.WriteLine("najvacsie cislo je: " + najvacsie);
            Console.WriteLine("najmensie cislo je: " + najmensie);
            Console.WriteLine("sucet tychto cisel je: " + sucet);

            int PomocnyInt = 0 ;
            for (int b = 0; b < poleCisiel.Count - 1; b++ )
            {
                for (int i = 0; i < poleCisiel.Count - 1; i++)
                {
                    if (poleCisiel[i] > poleCisiel[i + 1])
                    {
                        PomocnyInt = poleCisiel[i];
                        poleCisiel[i] = poleCisiel[i + 1];
                        poleCisiel[i + 1] = PomocnyInt;
                    }
                    PomocnyInt = 0;
                }
            }
 
            for (int i = 0; i < poleCisiel.Count; i++)
            {
                Console.Write(poleCisiel[i] + " ");
            }
                Console.ReadLine();
        }
    }
}
