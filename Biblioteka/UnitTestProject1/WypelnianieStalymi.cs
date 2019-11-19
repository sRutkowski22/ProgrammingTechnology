using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;
namespace UnitTestProject1
{
    public class WypelnianieStalymi : Fill
    {
        public WypelnianieStalymi() { }
        public void fillIn(DataContext data)
        {
            Katalog k1 = new Katalog( "Romeo i Julia", new AutorKsiazki("William", "Shakespear"));
            Katalog k2 = new Katalog( "Gra Endera", new AutorKsiazki("Orson Scott", "Card"));
            Katalog k3 = new Katalog( "Antygona", new AutorKsiazki("", "Sofokles"));
            OpisStanu opis1 = new OpisStanu(1, k1, 4, 50);
            Client c1 = new Client(1, "Szymon", "Rutkowski");
            //Wykazy klientow
            data.clientList.Add(c1);
            data.clientList.Add(new Client(2, "Przemek", "Lapinski"));
            data.clientList.Add(new Client(3, "Jan", "Kowalski"));
            //Zdarzenia
           /* data.zdarzenieObservableCollection.Add(new Sprzedaz(1, opis1,1,c1,DateTime.Today));
            data.zdarzenieObservableCollection.Add(new Sprzedaz(2, opis1, 1, c1, DateTime.Today));
            data.zdarzenieObservableCollection.Add(new Sprzedaz(3, opis1, 1, c1, DateTime.Today));
            //Katalog
            data.dictionaryKatalog.Add(1,  k1);
            data.dictionaryKatalog.Add(2, k2);
            data.dictionaryKatalog.Add(3, k3);
            //opisStanu
            data.opisStanuList.Add(opis1);
            data.opisStanuList.Add(new OpisStanu(2, k2, 5, 50));
            data.opisStanuList.Add(new OpisStanu(3, k3, 5, 50));*/
        }
    }
}
