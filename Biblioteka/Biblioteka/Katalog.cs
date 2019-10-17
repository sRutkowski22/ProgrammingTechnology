using System;


namespace Biblioteka
{
    public class Katalog
    {
        private int ID { get; }
        private String opisKsiazki { get; }
        private AutorKsiazki autorKsiazki { get; }
        
        Katalog(int nID, String nopisKsiazki, AutorKsiazki nautorKsiazki)
        {
            ID = nID;
            opisKsiazki = nopisKsiazki;
            autorKsiazki = nautorKsiazki;
            
        }
           
    } 
}