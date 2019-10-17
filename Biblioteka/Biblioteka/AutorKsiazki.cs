using System;


namespace Biblioteka
{
    public class AutorKsiazki
    {
        //dane osobowe autora
        private int ID { get; }
        private String imie;
        private String nazwisko;

        AutorKsiazki(int ID, String imie, String nazwisko)
        {
            this.ID = ID;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}