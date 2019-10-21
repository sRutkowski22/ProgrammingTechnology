using System;


namespace Biblioteka
{
    public class OpisStanu
    {
        private int iloscEgzemplarzy { get; }
        private int IDOpisuStanu { get; }
        private int katalogID { get; }
        private DateTime dataKupieniaKsiazki { get; }
        private uint cena { get; }
        public OpisStanu(int nID, int nkatalogID, int iloscEgzemplarzy, uint cena)
        {
            IDOpisuStanu = nID;
            this.katalogID = katalogID;
            this.iloscEgzemplarzy = iloscEgzemplarzy;
            this.cena = cena;
        }

    }
}
