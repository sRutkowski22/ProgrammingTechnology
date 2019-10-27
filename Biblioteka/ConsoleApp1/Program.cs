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
            repo.AddKatalog(kat1);
            Console.WriteLine(repo.GetAllKatalog().Count);
            Console.Read();
        }
    }
}
