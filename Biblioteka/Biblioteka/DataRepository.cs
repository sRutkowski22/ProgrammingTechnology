using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Biblioteka
{
    public class DataRepository : IDataRepository
    {
        private DataContext data { get; }

        public DataRepository(DataContext dataContext, Fill fill)
        {
           
            this.data = dataContext;
            fill.fillIn(dataContext);

        }   
        public DataRepository(DataContext data)
        {
            this.data = data;
        }
      //C.R.U.D ADD GET ALL GET UPDATE DELETE
      void AddKatalog(Katalog k)
        {
            data.dictionaryKatalog.Add((data.dictionaryKatalog.Count + 1),k);
        }
      void GetKatalog(Katalog k)
        {
            for(int i=0; i<data.dictionaryKatalog.Count; i++)
            {
                if (data.dictionaryKatalog.ContainsValue(k))
                {
                    //TODO: do zrobienia wypisywanie
                    Console.WriteLine(data.dictionaryKatalog);
                }
            }
        }
        void GetAllKatalog()
        {
            for (int i = 0; i < data.dictionaryKatalog.Count; i++)
            {
                Console.WriteLine(data.dictionaryKatalog.ToString());
            }
        }
        void UpdateKatalog(int ID, Katalog k)
        {
            if (data.dictionaryKatalog.ContainsKey(ID))
            {
                data.dictionaryKatalog[ID] = k;
            }
                      
        }
        void DeleteKatalog( int key)
        {
            data.dictionaryKatalog.Remove(key);
        }
        void AddWykaz( Client w)
        {
            data.clientList.Add(w);
        }
        void GetAll()
        {
            foreach(Client w in data.clientList)
            {
                w.ToString();
            }
        }

        private Client GetWykaz(Client w)
        {
            for(int i=0; i < data.clientList.Count;i++)
            {
                if (data.clientList.Contains(w))
                {
                    return data.clientList[i];
                }
                
            }
            return null;
        }

        public void AddClient(Client client)
        {
            data.clientList.Add(client);
        }

        void IDataRepository.AddKatalog(Katalog katalog)
        {
            int length = data.dictionaryKatalog.Count;
            data.dictionaryKatalog.Add(length + 1, katalog);
        }

        public void AddOpisStanu(OpisStanu opisStanu)
        {
            data.opisStanuList.Add(opisStanu);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            data.zdarzenieObservableCollection.Add(zdarzenie);
        }

        Dictionary<int, Katalog> IDataRepository.GetAllKatalog()
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
            foreach(Zdarzenie zd in data.zdarzenieObservableCollection)
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
            foreach(OpisStanu opis in data.opisStanuList)
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
            for(int i=0; i<data.clientList.Count; i++)
            {
                if (data.clientList[i].clientId==id)
                {
                    data.clientList[i] = client;
                }
            }
        }

        void IDataRepository.UpdateKatalog(int id, Katalog katalog)
        {
            data.dictionaryKatalog[id] = katalog;
        }

        public void UpdateOpisStanu(int id, OpisStanu opisStanu)
        {
           for(int i=0; i<data.opisStanuList.Count; i++)
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

        public void DeleteClient(int id)
        {
            for (int i = 0; i < data.clientList.Count; i++)
            {
                if (data.clientList[i].clientId == id)
                {
                    data.clientList.Remove(data.clientList[i]);
                }
            }

        }

        void IDataRepository.DeleteKatalog(int id)
        {
            data.dictionaryKatalog.Remove(id);
        }

        public void DeleteOpisStanu(int id)
        {
            for (int i = 0; i < data.opisStanuList.Count; i++)
            {
                if (data.opisStanuList[i].opisuStanuId == id)
                {
                    data.opisStanuList.Remove(data.opisStanuList[i]);
                }
            }
        }

        public void DeleteZdarzenie(int id)
        {
            for (int i = 0; i < data.zdarzenieObservableCollection.Count; i++)
            {
                if (data.zdarzenieObservableCollection[i].zdarzeniaId == id)
                {
                    data.zdarzenieObservableCollection.Remove(data.zdarzenieObservableCollection[i]);
                }
            }
        }
    }
}