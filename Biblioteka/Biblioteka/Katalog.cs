using System;


namespace Biblioteka
{
    public class Katalog
    {
        private int ID { get; }
        private String opisKsiazki { get; }
        private AutorKsiazki autorKsiazki { get; }
        private String tytulKsiazki { get; }
        public Katalog(int nID,  String tytulKsiazki, AutorKsiazki nautorKsiazki, String nopisKsiazki)
        {
            ID = nID;
            opisKsiazki = nopisKsiazki;
            autorKsiazki = nautorKsiazki;
            this.tytulKsiazki = tytulKsiazki;
        }
           
    } 
}