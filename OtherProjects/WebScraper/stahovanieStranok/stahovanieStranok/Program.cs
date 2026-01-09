using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stahovanieStranok
{
    class Program
    {
        static void Main(string[] args)
        {
            Downloader down = new Downloader();
            down.Stahuj("http://www.orsr.sk/hladaj_subjekt.asp?OBMENO=ab&PF=0&SID=0&R=on");
            Console.ReadLine();

        }
    }
}
