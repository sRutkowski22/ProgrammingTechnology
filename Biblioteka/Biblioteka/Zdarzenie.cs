using System;
using System.Collections.Generic;

namespace Biblioteka
{
    public abstract class Zdarzenie
    {
        internal int zdarzeniaId { get; }
        internal OpisStanu opisStanu { get; } // id stanu ksiazki (konkretna ksiazka)
        internal int ilosc { get; }
        internal uint cena { get; }
      

        

        public Zdarzenie(int zdarzeniaId, OpisStanu opisStanu, int ilosc,uint cena)
        {
            this.zdarzeniaId = zdarzeniaId;
            this.cena = cena;
            this.opisStanu = opisStanu;
            this.ilosc = ilosc;
           
            
        }


        public abstract Client GetClient();
        public abstract DateTime GetDateZdarzenia(); 
        public abstract int GetIlosc();

        public override bool Equals(object obj)
        {
            var zdarzenie = obj as Zdarzenie;
            return zdarzenie != null &&
                   zdarzeniaId == zdarzenie.zdarzeniaId &&
                   opisStanu.Equals(zdarzenie.opisStanu) &&
                   ilosc == zdarzenie.ilosc &&
                   cena == zdarzenie.cena;
        }
    }
}