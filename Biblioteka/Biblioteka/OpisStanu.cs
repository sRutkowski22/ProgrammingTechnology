using System;
using System.Collections.Generic;

namespace Biblioteka
{
    public class OpisStanu
    {
        internal int opisuStanuId { get; }
        internal Katalog katalog { get; }
        internal int iloscEgzemplarzy { get; }
        internal uint cena { get; }
        public OpisStanu(int opisuStanuId, Katalog katalog, int iloscEgzemplarzy, uint cena)
        {
            this.opisuStanuId = opisuStanuId;
            this.katalog = katalog;
            this.iloscEgzemplarzy = iloscEgzemplarzy;
            this.cena = cena;
        }

        public override bool Equals(object obj)
        {
            var stanu = obj as OpisStanu;
            return stanu != null &&
                   opisuStanuId == stanu.opisuStanuId &&
                   katalog.Equals(stanu.katalog) &&
                   iloscEgzemplarzy == stanu.iloscEgzemplarzy &&
                   cena == stanu.cena;
        }
    }
}
