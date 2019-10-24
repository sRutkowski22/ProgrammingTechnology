using System;


namespace Biblioteka
{
    public class Zdarzenie
    {
        internal int zdarzeniaId { get; }
       // Client client { get; }//id wypozyczajacego
        OpisStanu opisStanu { get; } // id stanu ksiazki (konkretna ksiazka)
        internal int ilosc { get; }
       // internal DateTime dataKupienia { get; }

        

        public Zdarzenie(int zdarzeniaId, OpisStanu opisStanu, int ilosc)
        {
            this.zdarzeniaId = zdarzeniaId;
            
            this.opisStanu = opisStanu;
            this.ilosc = ilosc;
           
            
        }
    }
}