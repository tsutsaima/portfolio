using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hocico
{
    class Program
    {
        static void Main(string[] args)
        {
            int cislo1;
                int cislo2 ;
                Console.WriteLine("zadaj prve cislo");
                cislo1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("zadaj druhe cislo");
                cislo2 = Convert.ToInt32(Console.ReadLine());
                int rozdiel = 0;
                Console.WriteLine("vyber funkciu");
                Console.WriteLine("+ plus, - minus, . krat, : delene");
                string znamienko = Console.ReadLine();
            if (znamienko == "+" )
            {
                rozdiel = cislo1 + cislo2;
            }
            else if (znamienko == "-" )
            {
                rozdiel = cislo1 - cislo2;
            }
            else if (znamienko == ":" )
            {
                rozdiel = cislo1 / cislo2;
            }
                        else if (znamienko == "." )
            {
                rozdiel = cislo1 * cislo2;
            }
                Console.WriteLine(cislo1 + " " + znamienko + " " + cislo2);
                
                Console.WriteLine("vysledok je " + rozdiel);
            Console.ReadLine();
        }
    }
}
