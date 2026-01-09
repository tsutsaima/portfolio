    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace stahovanieStranok
{
    class Downloader
    {

        private WebClient client;

        public Downloader()
        {
            client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        }

        public void Stahuj(string url)
        {

            int index;
            String obsah = downloadWebPage(url);


            string searchText = "<div class=\"bmk\">\r\n                        \r\n                        <a href=\"";
            while (true)
            {
                index = obsah.IndexOf(searchText);
                if (index < 0)
                    break;

                obsah = obsah.Substring(index + searchText.Length);
                string link = obsah.Substring(0, obsah.IndexOf("\" class=\"link\">Ak"));
                link = link.Replace("&amp;", "&");
                spracujLink("http://www.orsr.sk/" + link);


                
            }
            Console.WriteLine();
        }


        private string NajdiText(ref string text, string zaciatok, string koniec)
        {
            int index = text.IndexOf(zaciatok);
            text = text.Substring(index + zaciatok.Length);
            index = text.IndexOf(koniec);
            string najdenaHodnota = text.Substring(0, index);
            text = text.Substring(index + koniec.Length);
            return najdenaHodnota.Trim();
        }
        private void spracujLink(string url)
        {
            string obsah = downloadWebPage(url);
            /*
            string obsah2 = obsah;
            // nazov firmy
            string searchText = "<td width=\"67%\"> <span class='ra'>  ";
            int index = obsah.IndexOf(searchText);
            obsah = obsah.Substring(index + searchText.Length);
            index = obsah.IndexOf(" </span><br></td>");
            string nazov = obsah.Substring(0, index);
            Console.WriteLine(nazov);
            */
            Console.WriteLine(url);
            string nazov = NajdiText(ref obsah, "<td width=\"67%\"> <span class='ra'>", "</span><br></td>");
            Console.WriteLine(nazov);

            // adresa 1 
            obsah = obsah.Substring(obsah.IndexOf("<table"));

            string adresa1 = NajdiText(ref obsah, "<td width=\"67%\"> <span class='ra'>", "</span>");
            string cislo1 = NajdiText(ref obsah, "<span class='ra'>", "</span>");
            string adresa2 = NajdiText(ref obsah, "<span class='ra'>", "</span>");
            string psc = NajdiText(ref obsah, "<span class='ra'>", "</span>");
            if (psc.StartsWith("(od:"))
            {
                psc = adresa2;
                adresa2 = cislo1;
                cislo1 = adresa1;
                adresa1 = "";
            }
            Console.WriteLine(adresa1 + " " + cislo1);
            Console.WriteLine(adresa2);
            Console.WriteLine(psc);
            obsah = obsah.Substring(obsah.IndexOf("<table"));
            string ico = NajdiText(ref obsah, "<span class='ra'>", "</span><br></td>");
            Console.WriteLine(ico);
            Console.WriteLine(" ");
            
        }
        private string downloadWebPage(string theURL)
        {
            Stream data = client.OpenRead(theURL);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            return s;

        }



    }
}
