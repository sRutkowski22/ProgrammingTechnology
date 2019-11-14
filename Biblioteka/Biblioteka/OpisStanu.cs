using System;
using System.Collections.Generic;

namespace Biblioteka
{
    public class OpisStanu
    {
        private int opisuStanuId;
        internal Katalog katalog { get; }
        internal int iloscEgzemplarzy { get; }
        internal uint cena { get; }
       
        public int OpisuStanuId { get => this.OpisuStanuId; set => this.OpisuStanuId = value; }

        public OpisStanu(int opisuStanuId, Katalog katalog, int iloscEgzemplarzy, uint cena)
        {
            this.OpisuStanuId = opisuStanuId;
            this.katalog = katalog;
            this.iloscEgzemplarzy = iloscEgzemplarzy;
            this.cena = cena;
        }

        public override bool Equals(object obj)
        {
            var stanu = obj as OpisStanu;
            return stanu != null &&
                   OpisuStanuId == stanu.OpisuStanuId &&
                   katalog.Equals(stanu.katalog) &&
                   iloscEgzemplarzy == stanu.iloscEgzemplarzy &&
                   cena == stanu.cena;
        }

        public override int GetHashCode()
        {
            var hashCode = 1663023772;
            hashCode = hashCode * -1521134295 + OpisuStanuId.GetHashCode();
            hashCode = hashCode * -1521134295 + katalog.GetHashCode();
            hashCode = hashCode * -1521134295 + iloscEgzemplarzy.GetHashCode();
            hashCode = hashCode * -1521134295 + cena.GetHashCode();
            return hashCode;
        }
    }
}
