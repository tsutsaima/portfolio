using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobazar
{









    public class Auto
    {
        public int Price { get; set; }
        public int Year { get; set; }
        public int Power { get; set; }

        public EngineType TypeOfEngine { get; set; }
        public Color ColorCar { get; set; }
        public AutoType Type { get; set; }

        public Auto()
        {

        }
        public Auto(int price, int year, int power, EngineType engine, Color CarColor, AutoType typ )
        {
            Price = price;
            Year = year;
            Power = power;
            TypeOfEngine = engine;
            ColorCar = CarColor;
            Type = typ;
        }
        
        public void Vypis()
        {
            Console.WriteLine("Cena auta je: " + Price + ".");
            Console.WriteLine("Rok vyroby je: " + Year + ".");
            Console.WriteLine("Vykon auta je: " + Power + ".");
            Console.WriteLine("Typ motora je: " + TypeOfEngine + ".");
            Console.WriteLine("Farba auta je: " + ColorCar + ".");
            Console.WriteLine("Typ auta je: " + Type + ".");

        }
    }
}
