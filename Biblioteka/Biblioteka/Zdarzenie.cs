using System;


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
    }
}