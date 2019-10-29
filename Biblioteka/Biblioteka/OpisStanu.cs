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

        public override int GetHashCode()
        {
            var hashCode = 1663023772;
            hashCode = hashCode * -1521134295 + opisuStanuId.GetHashCode();
            hashCode = hashCode * -1521134295 + katalog.GetHashCode();
            hashCode = hashCode * -1521134295 + iloscEgzemplarzy.GetHashCode();
            hashCode = hashCode * -1521134295 + cena.GetHashCode();
            return hashCode;
        }
    }
}
