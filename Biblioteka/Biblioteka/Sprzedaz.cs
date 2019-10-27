using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Sprzedaz : Zdarzenie
    {
        Client client;
        internal DateTime dataSprzedazy;
        public Sprzedaz(int zdarzeniaId, OpisStanu opisStanu, int ilosc,Client client, DateTime dataSprzedazy) : base(zdarzeniaId, opisStanu, ilosc)
        {
            this.client = client;
            this.dataSprzedazy = dataSprzedazy;
        }

        public override Client GetClient()
        {
            return this.client;
        }

        public override DateTime GetDateZdarzenia()
        {
            return dataSprzedazy;
        }

        public override int GetIlosc()
        {
            return -ilosc;
        }
    }
}
