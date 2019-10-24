using System;


namespace Biblioteka
{
    public class OpisStanu
    {
        internal int opisuStanuId { get; }
        Katalog katalog { get; }
        internal int iloscEgzemplarzy { get; }
        internal uint cena { get; }
        public OpisStanu(int opisuStanuId, Katalog katalog, int iloscEgzemplarzy, uint cena)
        {
            this.opisuStanuId = opisuStanuId;
            this.katalog = katalog;
            this.iloscEgzemplarzy = iloscEgzemplarzy;
            this.cena = cena;
        }

    }
}
