using System;


namespace Biblioteka
{
    public class Zdarzenie
    {
        internal int zdarzeniaId { get; }
        internal int clientId { get; } //id wypozyczajacego
        internal int opisStanuId { get; } // id stanu ksiazki (konkretna ksiazka)
        internal int ilosc { get; }
        internal DateTime dataKupienia { get; }

        

        public Zdarzenie(int zdarzeniaId, int clientId, int opisStanuId, int ilosc, DateTime dataKupienia)
        {
            this.zdarzeniaId = zdarzeniaId;
            this.clientId = clientId;
            this.opisStanuId = opisStanuId;
            this.ilosc = ilosc;
            this.dataKupienia = dataKupienia;
            
        }
    }
}