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
            DataRepository repo = new DataRepository(data);
            Katalog kat1 = new Katalog("Potop", new AutorKsiazki("Henryk", "Sienkiewicz"), "PolskavsSzwecja");
            Katalog kat2 = new Katalog("Potop2", new AutorKsiazki("Henryk", "Sienkiewicz"), "PolskavsSzwecja");
            Client c1 = new Client(1, "Adam", "Małysz");
            Client c2 = new Client(1, "Szymon", "Maj");
            //Zakup(int zdarzeniaId, OpisStanu opisStanu, int ilosc, uint cena, DateTime dataZakupu)
            Zdarzenie zdarzenie = new Zakup(1, null, 1, 1, DateTime.Parse("26.10.2018 00:00:00"));
            repo.AddKatalog(kat1);
            repo.AddKatalog(kat2);
            repo.AddClient(c1);
            repo.AddClient(c2);
            repo.AddZdarzenie(zdarzenie);
            FileOperations fileOp = new FileOperations();
            ZapisCSV zapisCSV = new ZapisCSV(data);
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
                    "1. Do CSV\n" +
                    "2. Do Jsona");
                        str = Console.ReadLine();
                        m = int.Parse(str);
                        switch (m)
                        {
                            case 1:
                                Console.WriteLine("Zapis do csv");
                                zapisCSV.Save();
                                Console.Read();
                                break;
                            case 2:
                                Console.WriteLine("zapis do Jsona");
                                fileOp.saveKatalogToJSON(repo);

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
                                Console.WriteLine("Odczyt z naszego s");
                          
                          
                            Console.Read();
                            Console.Read();
                            break;
                            case 2:
                                Console.WriteLine("Odczyt z jsona");
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

