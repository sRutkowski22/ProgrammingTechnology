using System;


namespace Biblioteka
{
    public class Katalog
    {
        private int ID { get; }
        private String opisKsiazki { get; }
        private AutorKsiazki autorKsiazki { get; }
        private String tytulKsiazki { get; }
        Katalog(int nID, String nopisKsiazki, AutorKsiazki nautorKsiazki, String tytulKsiazki)
        {
            ID = nID;
            opisKsiazki = nopisKsiazki;
            autorKsiazki = nautorKsiazki;
            this.tytulKsiazki = tytulKsiazki;
        }
           
    } 
}