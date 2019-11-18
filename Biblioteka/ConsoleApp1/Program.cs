using System;
using Biblioteka;
namespace ConsoleApp1
{
    public class Program
    {
        public void whatsNext(String str)
        {
            
            
        }
        public static void Main(string[] args)
        {
            DataContext data = new DataContext();
            DataContext data2 = new DataContext();
            DataRepository repo = new DataRepository(data);
            DataRepository repo2 = new DataRepository(data2);
            Katalog kat1 = new Katalog("Potop", new AutorKsiazki("Henryk", "Sienkiewicz"), "PolskavsSzwecja");
            Katalog kat2 = new Katalog("Potop2", new AutorKsiazki("Henryk", "Sienkiewicz"), "PolskavsSzwecja");
            Client c1 = new Client(1, "Adam", "Małysz");
            Client c2 = new Client(1, "Szymon", "Maj");
            OpisStanu opis1 = new OpisStanu(1, kat1, 2, 20);
            Zdarzenie zakup = new Zakup(1, opis1, 1, 20, DateTime.Parse("2018.12.12"));      
            Zdarzenie sprzedaz = new Sprzedaz(2,opis1,2,30,c1, DateTime.Parse("2018.12.10"));
            repo.AddKatalog(kat1);
            repo.AddKatalog(kat2);
            repo.AddClient(c1);
            repo.AddClient(c2);
            repo.AddOpisStanu(opis1);
            repo.AddZdarzenie(zakup);
            repo.AddZdarzenie(sprzedaz);

            FileOperations fileOp = new FileOperations();
            int n;
            int m;
            String str;
            
    Start:
            Console.WriteLine("Wybierz co chcesz zrobic?\n" +
                "1. Zapis\n" +
                "2. Odczyt\n" +
                "0. Exit");
            str = Console.ReadLine();
            n = int.Parse(str);        
                switch (n)
                {
                    case 1:
                        Console.WriteLine("jestes w zapisie");
                        Console.WriteLine("Wybierz co chcesz zrobic?\n" +
                    "1. Do Xmla\n" +
                    "2. Do Jsona");
                        str = Console.ReadLine();
                        m = int.Parse(str);
                        switch (m)
                        {
                            case 1:
                                Console.WriteLine("Zapis do xmla");
                                fileOp.saveClientToXML(repo);
                                Console.Read();
                                break;
                            case 2:
                                Console.WriteLine("zapis do Jsona");
                            //fileOp.saveKatalogToJSON(repo);
                            fileOp.AllToJson(repo, "Clients.json", "Katalogi.json", "OpisStanu.json", "Zdarzenia.json");

                                Console.Read();
                                break;
                        }
                        Console.Read();
                        break;
                    case 2:
                        Console.WriteLine("jestes w odczycie");
                        Console.WriteLine("Odczyt:\n" +
                    "1. Z Xmla\n" +
                    "2. Z Jsona");
                        str = Console.ReadLine();
                        m = int.Parse(str);
                        switch (m) { 
                            case 1:
                                Console.WriteLine("Odczyt z xmla");
                            fileOp.loadClientFromXML(repo);
                                Console.Read();
                            Console.Read();
                            break;
                            case 2:
                                Console.WriteLine("Odczyt z jsona");
                                fileOp.loadFromJson(repo2.GetDataContext());
                                Console.Read();
                                break;
                        }
                        Console.Read();
                        break;
                    case 0:
                        Environment.Exit(0);
                    break;
                    default:
                        Console.WriteLine("Nic nie wybrales");
                        goto Start;                      
                       
                }
                goto Start;
            }

            
        }
    }

