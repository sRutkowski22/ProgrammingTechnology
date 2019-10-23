using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class WypelnianieStalymi : Fill
    {
        public void fillIn(DataContext data)
        {
            //Wykazy klientow
            data.WykazList.Add(new Client(1, "Szymon", "Rutkowski"));
            data.WykazList.Add(new Client(2, "Przemek", "Lapinski"));
            data.WykazList.Add(new Client(3, "Jan", "Kowalski"));
            //Zdarzenia
            data.zdarzenieObservableCollection.Add(new Zdarzenie(1, 1, 1,1,DateTime.Today));
            data.zdarzenieObservableCollection.Add(new Zdarzenie(2, 2, 2,2, DateTime.Today));
            data.zdarzenieObservableCollection.Add(new Zdarzenie(3, 3, 3,1, DateTime.Today));
            //Katalog
            data.dictionaryKatalog.Add(1, new Katalog(1, "Romeo i Julia", new AutorKsiazki("William", "Shakespear"),"dramat"));
            data.dictionaryKatalog.Add(2, new Katalog(2, "Gra Endera", new AutorKsiazki("Orson Scott", "Card"), "sci-fi"));
            data.dictionaryKatalog.Add(3, new Katalog(3, "Antygona", new AutorKsiazki("", "Sofokles"), "tragedia"));
            //opisStanu
            data.opisStanuList.Add(new OpisStanu(1, 1, 4, 50));
            data.opisStanuList.Add(new OpisStanu(2, 2, 5, 50));
            data.opisStanuList.Add(new OpisStanu(3, 3, 5, 50));
        }
    }
}
