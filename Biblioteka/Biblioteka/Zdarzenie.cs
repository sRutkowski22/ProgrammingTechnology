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

        //public abstract bool Equals(object obj);
       

        public override int GetHashCode()
        {
            var hashCode = -937264338;
            hashCode = hashCode * -1521134295 + zdarzeniaId.GetHashCode();
            hashCode = hashCode * -1521134295 + opisStanu.GetHashCode();
            hashCode = hashCode * -1521134295 + ilosc.GetHashCode();
            hashCode = hashCode * -1521134295 + cena.GetHashCode();
            return hashCode;
        }
    }
}