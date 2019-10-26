using System;


namespace Biblioteka
{
    public class Katalog
    {
        
        internal String opisKsiazki { get; }
        internal AutorKsiazki autorKsiazki { get; }
        internal String tytulKsiazki { get; }
        public Katalog(  String tytulKsiazki, AutorKsiazki nautorKsiazki, String nopisKsiazki)
        {        
            opisKsiazki = nopisKsiazki;
            autorKsiazki = nautorKsiazki;
            this.tytulKsiazki = tytulKsiazki;
        }
           
    } 
}