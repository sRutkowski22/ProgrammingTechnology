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
            Katalog kat1 = new Katalog("Potop", new AutorKsiazki("Henryk", "Sienkiewicz"), "Potoppp");
            Katalog kat2 = new Katalog("Potop2", new AutorKsiazki("Kante", "Sienkiewicz"), "PolskavsSzwecja");
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
            
            repo.AddZdarzenie(sprzedaz);
            repo.AddZdarzenie(zakup);

            FileOperations fileOp = new FileOperations();
            ZapisCSV zapisCSV = new ZapisCSV(repo);
            WczytanieCSV wczytanieCSV = new WczytanieCSV(repo);
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
                    "1. Z CSV\n" +
                    "2. Z Jsona");
                        str = Console.ReadLine();
                        m = int.Parse(str);
                        switch (m) { 
                            case 1:
                                Console.WriteLine("Odczyt z csv");
                            wczytanieCSV.Read();


                            Console.Read();
                            Console.Read();
                            break;
                            case 2:
                                Console.WriteLine("Odczyt z jsona");
                            Console.WriteLine("liczba clientow przed wczytaniem" + repo2.GetAllClient().Count);
                            repo2.setClientsList(fileOp.loadClientFromJson("Clients.json"));
                            Console.WriteLine("liczba clientow po wczytaniem" + repo2.GetAllClient().Count);
                            foreach (Client c in repo2.GetAllClient()){
                                Console.Write(c.ClientId + c.clientId + c.imie + c.nazwisko);
                            }
                            repo2.setKatalogDict(fileOp.loadKatalogFromJson("Katalogi.json"));
                            Console.WriteLine("dict values kat" +repo2.GetAllKatalog()[0].autorKsiazki.imie+ repo2.GetAllKatalog()[1].autorKsiazki.imie);
                            
                            repo2.setOpisStanuList(fileOp.loadOpisStanuFromJson("OpisStanu.json"));
                            foreach (OpisStanu op in repo2.GetAllOpisStanu())
                            {
                                Console.WriteLine("OpisStanu:"+op.cena+ op.katalog.autorKsiazki.imie+op.katalog.opisKsiazki);
                            }
                            repo2.setZdarzeniaList(fileOp.loadZdarzeniaFromJson("Zdarzenia.json"));
                            foreach (Zdarzenie op in repo2.GetAllZdarzenia())
                            {
                                Console.WriteLine("Zdarzenia: " + op.ilosc+ op.opisStanu.katalog.opisKsiazki+op.cena );
                            }
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

