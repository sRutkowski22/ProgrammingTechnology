using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Biblioteka
{
    public class DataRepository : IDataRepository
    {
        private DataContext data { get; }

        public DataRepository(DataContext dataContext, Fill fill)
        {
           
            this.data = dataContext;
            fill.fillIn(dataContext);
            data.zdarzenieObservableCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler
(CollectionChangedMethod);

        }   
        public DataRepository(DataContext data)
        {
            this.data = data;
            data.zdarzenieObservableCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler
(CollectionChangedMethod);
        }
        //C.R.U.D ADD GET ALL GET UPDATE DELETE

        public void AddClient(Client client)
        {
            data.clientList.Add(client);
        }

        public void AddKatalog(Katalog katalog)
        {
            int length = data.dictionaryKatalog.Count;
            data.dictionaryKatalog[length+1]=katalog;
        }

        public void AddOpisStanu(OpisStanu opisStanu)
        {
            data.opisStanuList.Add(opisStanu);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            data.zdarzenieObservableCollection.Add(zdarzenie);
        }

        public Dictionary<int, Katalog> GetAllKatalog()
        {
            return data.dictionaryKatalog;
        }

        public List<Client> GetAllClient()
        {
            return data.clientList;
        }

        public ObservableCollection<Zdarzenie> GetAllZdarzenia()
        {
            return data.zdarzenieObservableCollection;
        }

        public List<OpisStanu> GetAllOpisStanu()
        {
            return data.opisStanuList;
        }

        public Zdarzenie GetZdarzenieById(int zdarzeniaID)
        {
            foreach (Zdarzenie zd in data.zdarzenieObservableCollection)
            {
                if (zd.zdarzeniaId == zdarzeniaID)
                {
                    return zd;
                }
            }
            return null;
        }

        public Client GetClientById(int clientID)
        {
            foreach (Client cl in data.clientList)
            {
                if (cl.clientId == clientID)
                {
                    return cl;
                }
            }
            return null;
        }

        public OpisStanu GetOpisStanuById(int opisStanuId)
        {
            foreach (OpisStanu opis in data.opisStanuList)
            {
                if (opis.opisuStanuId == opisStanuId)
                {
                    return opis;
                }
            }
            return null;
        }

        public Katalog GetKatalogById(int katalogId)
        {
            return data.dictionaryKatalog[katalogId];
        }

        public void UpdateClient(int id, Client client)
        {
            for (int i = 0; i < data.clientList.Count; i++)
            {
                if (data.clientList[i].clientId == id)
                {
                    data.clientList[i] = client;
                }
            }
        }

        public void UpdateKatalog(int id, Katalog katalog)
        {
            data.dictionaryKatalog[id] = katalog;
        }

        public void UpdateOpisStanu(int id, OpisStanu opisStanu)
        {
            for (int i = 0; i < data.opisStanuList.Count; i++)
            {
                if (data.opisStanuList[i].opisuStanuId == id)
                {
                    data.opisStanuList[i] = opisStanu;
                }
            }
        }

        public void UpdateZdarzenie(int id, Zdarzenie zdarzenie)
        {
            for (int i = 0; i < data.zdarzenieObservableCollection.Count; i++)
            {
                if (data.zdarzenieObservableCollection[i].zdarzeniaId == id)
                {
                    data.zdarzenieObservableCollection[i] = zdarzenie;
                }
            }
        }

        public void DeleteClientByID(int id)
        {
            for (int i = 0; i < data.clientList.Count; i++)
            {
                if (data.clientList[i].clientId == id)
                {
                    data.clientList.Remove(data.clientList[i]);
                }
            }

        }

        public void DeleteKatalogByID(int id)
        {
            data.dictionaryKatalog.Remove(id);
        }

        public void DeleteOpisStanuByID(int id)
        {
            for (int i = 0; i < data.opisStanuList.Count; i++)
            {
                if (data.opisStanuList[i].opisuStanuId == id)
                {
                    data.opisStanuList.Remove(data.opisStanuList[i]);
                }
            }
        }

        public void DeleteZdarzenieByID(int id)
        {
            for (int i = 0; i < data.zdarzenieObservableCollection.Count; i++)
            {
                if (data.zdarzenieObservableCollection[i].zdarzeniaId == id)
                {
                    data.zdarzenieObservableCollection.Remove(data.zdarzenieObservableCollection[i]);
                }
            }
        }

        private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
           
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.Write("Dodaje cos");
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                //your code
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                //your code
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {
                //your code
            }
        }



    }
}