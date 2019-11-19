using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Sprzedaz : Zdarzenie
    {
        public Client client { get; set; }
        public DateTime dataSprzedazy { get; set; }
        public Sprzedaz(int zdarzeniaId, OpisStanu opisStanu, int ilosc, uint cena,Client client, DateTime dataSprzedazy) : base(zdarzeniaId, opisStanu, ilosc, cena)
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

        public override bool Equals(object obj)
        {
            var sprzedaz = obj as Sprzedaz;
            return sprzedaz != null &&
                   client.Equals(sprzedaz.client) &&
                   dataSprzedazy == sprzedaz.dataSprzedazy;
        }

        public override int GetHashCode()
        {
            var hashCode = 328395893;
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(client);
            hashCode = hashCode * -1521134295 + dataSprzedazy.GetHashCode();
            return hashCode;
        }
    }
}
