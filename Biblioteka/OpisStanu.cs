using System;


namespace Biblioteka
{
    public class OpisStanu
    {
        private int ID { get; }
        private Katalog katalog;
        private DateTime dataKupieniaKsiazki { get; }
        OpisStanu(int nID, Katalog nkatalog, DateTime ndataKupieniaKsiazki)
        {
            ID = nID;
            katalog = nkatalog;
            dataKupieniaKsiazki = ndataKupieniaKsiazki;
        }

    }
}
