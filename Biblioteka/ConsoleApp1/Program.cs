using System;
using Biblioteka;
namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataContext data = new DataContext();
            DataRepository repo = new DataRepository(data);
            Katalog kat1 = new Katalog("Potop", new AutorKsiazki("Henryk", "Sienkiewicz"), "PolskavsSzwecja");
            
            //Zakup(int zdarzeniaId, OpisStanu opisStanu, int ilosc, uint cena, DateTime dataZakupu)
            Zdarzenie zdarzenie = new Zakup(1, null, 1, 1, DateTime.Parse("26.10.2018 00:00:00"));
            repo.AddKatalog(kat1);
            repo.AddZdarzenie(zdarzenie);
            Console.WriteLine(repo.GetAllKatalog().Count);
            Console.Read();
        }
    }
}
