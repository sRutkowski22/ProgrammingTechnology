using Biblioteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class Graf : Fill
    {
        public void fillIn(DataContext data)
        {
            
            
            Katalog kat1 = new Katalog("MyszkaMiki", new AutorKsiazki("Henryk", "Sienkiewicz"));
            Katalog kat2 = new Katalog("Przemoniewkurwiajsie", new AutorKsiazki("Kante", "Sienkiewicz"));
            Client c1 = new Client(1, "Adam", "Małysz");
            Client c2 = new Client(2, "Szymon", "Maj");
            OpisStanu opis1 = new OpisStanu(1, kat1, 2, 20);
            OpisStanu opis2 = new OpisStanu(2, kat2, 4, 40);
            Zdarzenie zakup = new Zakup(1, opis1, 1, 20, DateTime.Parse("2018.12.12"));
            Zdarzenie sprzedaz = new Sprzedaz(2, opis1, 2, 30, c1, DateTime.Parse("2018.12.12"));
            data.dictionaryKatalog.Add(1,kat1);
            data.dictionaryKatalog.Add(2, kat2);
            data.clientList.Add(c1);
            data.clientList.Add(c2);
            data.opisStanuList.Add(opis1);
            data.opisStanuList.Add(opis2);
            data.zdarzenieObservableCollection.Add(sprzedaz);
            data.zdarzenieObservableCollection.Add(zakup);
            
        }
    }
}
