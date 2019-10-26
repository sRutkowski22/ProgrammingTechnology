using System;


namespace Biblioteka
{
    public abstract class Zdarzenie
    {
        internal int zdarzeniaId { get; }
        internal OpisStanu opisStanu { get; } // id stanu ksiazki (konkretna ksiazka)
        internal int ilosc { get; }
      

        

        public Zdarzenie(int zdarzeniaId, OpisStanu opisStanu, int ilosc)
        {
            this.zdarzeniaId = zdarzeniaId;
            
            this.opisStanu = opisStanu;
            this.ilosc = ilosc;
           
            
        }

        public abstract Client GetClient();
        public abstract DateTime GetDateZdarzenia(); 
        public abstract int GetIlosc();
    }
}