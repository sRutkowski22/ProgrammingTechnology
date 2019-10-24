using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class Zakup : Zdarzenie
    {
        internal DateTime dataZakupu;
        public Zakup(int zdarzeniaId, OpisStanu opisStanu, int ilosc, DateTime dataZakupu) : base(zdarzeniaId, opisStanu, ilosc)
        {
            this.dataZakupu = dataZakupu;
        }
    }
}
