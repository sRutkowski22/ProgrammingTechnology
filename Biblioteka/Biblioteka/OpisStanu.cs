using System;


namespace Biblioteka
{
    public class OpisStanu
    {
        internal int opisuStanuId { get; }
        internal int katalogId { get; }
        internal int iloscEgzemplarzy { get; }
        internal uint cena { get; }
        public OpisStanu(int opisuStanuId, int katalogId, int iloscEgzemplarzy, uint cena)
        {
            this.opisuStanuId = opisuStanuId;
            this.katalogId = katalogId;
            this.iloscEgzemplarzy = iloscEgzemplarzy;
            this.cena = cena;
        }

    }
}
