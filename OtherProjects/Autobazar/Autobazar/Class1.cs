using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobazar
{
    public static class Extensions
    {
        static Random rand = new Random();
        public static Auto GenerateRandomAuto()
        {
            Auto bmw = new Auto();
            
            bmw.Year = rand.Next(1980, 2018);
            bmw.Price = rand.Next(5000, 20000);
            bmw.Power = rand.Next(67, 196);



            bmw.ColorCar = (Color)rand.Next(5);
            bmw.TypeOfEngine = (EngineType)rand.Next(7);
            bmw.Type = (AutoType)rand.Next(7);

            return bmw;
        }
    }
}
