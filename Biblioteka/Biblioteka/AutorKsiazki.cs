using System;


namespace Biblioteka
{
    public class AutorKsiazki
    {
        //dane osobowe autora
        private int ID { get; }
        private String imie;
        private String nazwisko;

        public AutorKsiazki( String imie, String nazwisko)
        {  
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}