using System;


namespace Biblioteka
{
    public class Zdarzenie
    {
        private int ID;
        private Wykaz wykaz; //wypozyczajacy
        private OpisStanu opisStanu; // ksiazka
        private DateTime dataWypozyczenia;
        private DateTime dataZwrotu;
        Zdarzenie(int nID, int nwykaz, int nopisStanu, DateTime ndataWypozyczenia, DateTime ndataZwrotu)
        {
            ID = nID;
            wykaz = nwykaz;
            opisStanu = nopisStanu;
            dataWypozyczenia = ndataWypozyczenia;
            dataZwrotu = ndataZwrotu;
        }
    }
}