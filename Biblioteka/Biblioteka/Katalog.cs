using System;


namespace Biblioteka
{
    public class Katalog
    {
        private int ID;
        private String opisKsiazki { get; }
        private AutorKsiazki autorKsiazki { get; }
        private uint cena { get; }
        Katalog(int nID, String nopisKsiazki, AutorKsiazki nautorKsiazki, uint cena)
        {
            ID = nID;
            opisKsiazki = nopisKsiazki;
            autorKsiazki = nautorKsiazki;
            this.cena = cena;
        }

    }
}