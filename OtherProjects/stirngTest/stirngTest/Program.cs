using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stirngTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadaj text.");
            string txt = Console.ReadLine();
            Console.WriteLine(txt + ".");
            int index = txt.IndexOf("a");
            Console.WriteLine("Znak 'a' sa nachadeza na pozicii " + index.ToString());
            if (index > 0)
            {
                string orezane = txt.Substring(index);
                Console.WriteLine("Text oreazany od pozicie " + index + " je :" + orezane);
            }
            Console.ReadLine();
        }
    }
}
