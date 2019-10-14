using System;


namespace Biblioteka
{
    public class AutorKsiazki
    {
        private int ID { get; }
        private String imie { get; }
        private String nazwisko { get; }
        AutorKsiazki(int nID, String nimie, String nnazwisko)
        {
            ID = nID;
            imie = nimie;
            nazwisko = nnazwisko;
              
        }
    }
}
