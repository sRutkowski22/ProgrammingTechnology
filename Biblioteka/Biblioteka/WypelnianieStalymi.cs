using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class WypelnianieStalymi : Fill
    {
        public WypelnianieStalymi() { }
        public void fillIn(DataContext data)
        {
            OpisStanu opis1 = new OpisStanu(1, 1, 4, 50);
            Client c1 = new Client(1, "Szymon", "Rutkowski");
            //Wykazy klientow
            data.WykazList.Add(c1);
            data.WykazList.Add(new Client(2, "Przemek", "Lapinski"));
            data.WykazList.Add(new Client(3, "Jan", "Kowalski"));
            //Zdarzenia
            data.zdarzenieObservableCollection.Add(new Sprzedaz(1, opis1,1,c1,DateTime.Today));
            data.zdarzenieObservableCollection.Add(new Sprzedaz(2, opis1, 1, c1, DateTime.Today));
            data.zdarzenieObservableCollection.Add(new Sprzedaz(3, opis1, 1, c1, DateTime.Today));
            //Katalog
            data.dictionaryKatalog.Add(1, new Katalog(1, "Romeo i Julia", new AutorKsiazki("William", "Shakespear"),"dramat"));
            data.dictionaryKatalog.Add(2, new Katalog(2, "Gra Endera", new AutorKsiazki("Orson Scott", "Card"), "sci-fi"));
            data.dictionaryKatalog.Add(3, new Katalog(3, "Antygona", new AutorKsiazki("", "Sofokles"), "tragedia"));
            //opisStanu
            data.opisStanuList.Add(opis1);
            data.opisStanuList.Add(new OpisStanu(2, 2, 5, 50));
            data.opisStanuList.Add(new OpisStanu(3, 3, 5, 50));
        }
    }
}
