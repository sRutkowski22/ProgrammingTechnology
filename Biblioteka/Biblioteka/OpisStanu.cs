using System;


namespace Biblioteka
{
    public class OpisStanu
    {
        private int ID { get; }
        private int katalogID { get; }
        private DateTime dataKupieniaKsiazki { get; }
        private uint cena { get; }
        OpisStanu(int nID, int nkatalogID, DateTime ndataKupieniaKsiazki, uint cena)
        {
            ID = nID;
            this.katalogID = katalogID;
            dataKupieniaKsiazki = ndataKupieniaKsiazki;
            this.cena = cena;
        }

    }
}
