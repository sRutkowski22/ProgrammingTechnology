using System;
using Biblioteka;
using System.Globalization;
using System.Linq;
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
            Katalog kat1 = new Katalog("Antygona", new AutorKsiazki("Sofokles", ""));
            Katalog kat2 = new Katalog("Potop", new AutorKsiazki("Henryk", "Sienkiewicz"));
            Client c1 = new Client(1, "Adam", "Małysz");
            Client c2 = new Client(2, "Szymon", "Maj");
            OpisStanu opis1 = new OpisStanu(1, kat1, 2, 20);
            OpisStanu opis2 = new OpisStanu(2, kat2, 4, 40);
            Zdarzenie zakup = new Zakup(1, opis1, 1, 20, DateTime.ParseExact("2018.12.12","yyyy.MM.dd", CultureInfo.CurrentCulture)); 
            Zdarzenie sprzedaz = new Sprzedaz(2,opis1,2,30,c1, DateTime.ParseExact("2018.11.07", "yyyy.MM.dd", CultureInfo.CurrentCulture));
            repo.AddKatalog(kat1);
            repo.AddKatalog(kat2);
            repo.AddClient(c1);
            repo.AddClient(c2);
            repo.AddOpisStanu(opis1);
            repo.AddOpisStanu(opis2);

            repo.AddZdarzenie(sprzedaz);
            repo.AddZdarzenie(zakup);

            FileOperations fileOp = new FileOperations();
            ZapisCSV zapisCSV = new ZapisCSV(repo);
            WczytanieCSV wczytanieCSV = new WczytanieCSV(repo2);
            int n;
            int m;
            String str;
            
    Start:
            Console.WriteLine("Wybierz co chcesz zrobic?\n" +
                "1. Zapis\n" +
                "2. Odczyt\n" +
                "3. Wypisz wszystko z wczytanego repozytorium\n"+
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
                               
                                zapisCSV.Save();
                            Console.WriteLine("Zapisano do csv");
                            Console.Read();
                                break;
                            case 2:
                               
                            
                            fileOp.AllToJson(repo, "Clients.json", "Katalogi.json", "OpisStanu.json", "Zdarzenia.json");
                            Console.WriteLine("Zapisano do jsona");
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
                                
                            wczytanieCSV.Read();
                            Console.WriteLine("Odczytano z csv");

                            Console.Read();
                            break;
                            case 2:
                            Console.WriteLine("Odczytano z jsona");
                            repo2.setClientsList(fileOp.loadClientFromJson("Clients.json"));                
                            repo2.setKatalogDict(fileOp.loadKatalogFromJson("Katalogi.json"));                   
                            repo2.setOpisStanuList(fileOp.loadOpisStanuFromJson("OpisStanu.json"));
                            repo2.setZdarzeniaList(fileOp.loadZdarzeniaFromJson("Zdarzenia.json"));
                            DuplicateExecutor.duplicateDelete(repo2.GetDataContext());
                           
                            Console.Read();
                            break;
                        }
                        Console.Read();
                        break;
                case 3:
                    wypiszWszystko(repo2);
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

        public static void wypiszWszystko(DataRepository repository)
        {
          //  repository.GetKatalogById(0).tytulKsiazki = "  hahaha podmienilem tytul  ";
            Console.WriteLine("\nKatalogi");
            foreach (Katalog kat in repository.GetAllKatalog().Values)
            { 
                Console.WriteLine("Katalog: tytuł " + kat.tytulKsiazki +" Autor: "+ kat.autorKsiazki.imie + "  " + kat.autorKsiazki.nazwisko);

            }
            Console.WriteLine("\nKlienci");
            foreach (Client c in repository.GetAllClient())
            {
                Console.WriteLine("Klient:  " + c.imie + "  " + c.nazwisko);
              
            }
            Console.WriteLine("\nOpisy Stanu");
            foreach (OpisStanu op in repository.GetAllOpisStanu())
            {
                Console.WriteLine("OpisStanu: Cena: " + op.cena + " Ilosc egzemplarzy: "+ op.cena +
                    "\nKatalog: tytuł " + op.katalog.tytulKsiazki + " Autor: " + op.katalog.autorKsiazki.imie + "  " + op.katalog.autorKsiazki.nazwisko);
            }
            Console.WriteLine("\nZdarzenia sprzedazy");
            foreach (Sprzedaz op in repository.GetAllZdarzenia().Where(a => a.GetType() == typeof(Sprzedaz)))
                            {
                                Console.WriteLine("\nSprzedarz: ile: " + op.ilosc + " cena: " + op.cena +
                                    "\nKlient:  " + op.client.imie + "  " + op.client.nazwisko +
                                    "\nOpisStanu: Cena: " + op.opisStanu.cena + " Ilosc egzemplarzy: " + op.opisStanu.cena +
                    "\nKatalog: tytuł " + op.opisStanu.katalog.tytulKsiazki + " Autor: " + op.opisStanu.katalog.autorKsiazki.imie + "  " + op.opisStanu.katalog.autorKsiazki.nazwisko);
                            }
            Console.WriteLine("\nZdarzenia kupna ");
            foreach (Zdarzenie op in repository.GetAllZdarzenia().Where(a => a.GetType() == typeof(Zakup)))
            {
                Console.WriteLine("\nKupno: ile: " + op.ilosc + " cena: " + op.cena +
                                   
                                    "\nOpisStanu: Cena: " + op.opisStanu.cena + " Ilosc egzemplarzy: " + op.opisStanu.cena +
                    "\nKatalog: tytuł " + op.opisStanu.katalog.tytulKsiazki + " Autor: " + op.opisStanu.katalog.autorKsiazki.imie + "  " + op.opisStanu.katalog.autorKsiazki.nazwisko);

            }


        }

            
        }
    }

