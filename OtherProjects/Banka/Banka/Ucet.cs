using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka
{
    class Ucet
    {
        int stavuctu = 0;
        public Ucet(int pociatocnyVklad)
        {
            stavuctu = pociatocnyVklad;
        }
        public void Vklad(int suma)
        {
            stavuctu = stavuctu + suma;
        }
        public void Vyber(int suma)
        {
            stavuctu = stavuctu - suma;
        }
        public int StavUctu()
        {

            return stavuctu;
        }
        public void PrevodNaInyUcet(Ucet ucet,  int suma)
        {
            Vyber(suma);
            ucet.Vklad(suma);  
        }
    }
}
