using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class DuplicateExecutor
    {
        public static void duplicateDelete(DataContext dataContext)
        {
            deleteKatalogDuplicateFromOpisStanu(dataContext);
            deleteOpisStanuDuplicateFromZdarzenia(dataContext);
            deleteClientDuplicateFromSprzedaz(dataContext);
        }

        private static void deleteKatalogDuplicateFromOpisStanu(DataContext dataContext)
        {
            foreach(OpisStanu opisStanu in dataContext.opisStanuList)
            {
                foreach(Katalog katalog in dataContext.dictionaryKatalog.Values)
                {
                    if (opisStanu.katalog.Equals(katalog))
                    {
                        opisStanu.katalog = katalog;
                    }
                }
            }
        }

        private static void deleteOpisStanuDuplicateFromZdarzenia(DataContext dataContext)
        {
            foreach (Zdarzenie zdarzenie in dataContext.zdarzenieObservableCollection)
            {
                foreach (OpisStanu opisStanu in dataContext.opisStanuList)
                {
                    if (zdarzenie.opisStanu.Equals(opisStanu))
                    {
                        zdarzenie.opisStanu = opisStanu;
                    }
                }
            }
        }

        private static void deleteClientDuplicateFromSprzedaz(DataContext dataContext)
        {
            foreach (Sprzedaz sprzedaz in dataContext.zdarzenieObservableCollection.Where(a => a.GetType() == typeof(Sprzedaz)))
            {
                foreach (Client client in dataContext.clientList)
                {
                    if (sprzedaz.client.Equals(client))
                    {
                        sprzedaz.client = client;
                    }
                }
            }
        }
    }
}
