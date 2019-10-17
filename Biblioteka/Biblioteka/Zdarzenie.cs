using System;


namespace Biblioteka
{
    public class Zdarzenie
    {
        private int ID { get; }
        private int wykazID { get; } //id wypozyczajacego
        private int opisStanuID { get; } // id stanu ksiazki (konkretna ksiazka)
        private DateTime dataWypozyczenia { get; }
        private DateTime dataZwrotu { get; }
        Zdarzenie(int nID, int wykazID, int opisStanuID, DateTime ndataWypozyczenia, DateTime ndataZwrotu)
        {
            ID = nID;
            this.wykazID = wykazID;
            this.opisStanuID = opisStanuID;
            dataWypozyczenia = ndataWypozyczenia;
            dataZwrotu = ndataZwrotu;
        }
    }
}