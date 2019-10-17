using System;


namespace Biblioteka
{
    public class OpisStanu
    {
        private int ID { get; }
        private Katalog katalog;
        private DateTime dataKupieniaKsiazki { get; }
        private uint cena { get; }
        OpisStanu(int nID, Katalog nkatalog, DateTime ndataKupieniaKsiazki, uint cena)
        {
            ID = nID;
            katalog = nkatalog;
            dataKupieniaKsiazki = ndataKupieniaKsiazki;
            this.cena = cena;
        }

    }
}
