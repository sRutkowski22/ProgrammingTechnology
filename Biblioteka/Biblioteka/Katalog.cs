using System;


namespace Biblioteka
{
    public class Katalog
    {
        internal int katalogId { get; }
        internal String opisKsiazki { get; }
        internal AutorKsiazki autorKsiazki { get; }
        internal String tytulKsiazki { get; }
        public Katalog(int katalogId,  String tytulKsiazki, AutorKsiazki nautorKsiazki, String nopisKsiazki)
        {
            this.katalogId = katalogId;
            opisKsiazki = nopisKsiazki;
            autorKsiazki = nautorKsiazki;
            this.tytulKsiazki = tytulKsiazki;
        }
           
    } 
}