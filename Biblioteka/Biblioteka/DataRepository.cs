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
            data.wykazList.Add(w);
        }
        void GetAll()
        {
            foreach(Client w in data.wykazList)
            {
                w.ToString();
            }
        }

        private Client GetWykaz(Client w)
        {
            for(int i=0; i < data.wykazList.Count;i++)
            {
                if (data.wykazList.Contains(w))
                {
                    return data.wykazList[i];
                }
                
            }
            return null;
        }

        public void AddClient(Client client)
        {
            throw new NotImplementedException();
        }

        void IDataRepository.AddKatalog(Katalog katalog)
        {
            throw new NotImplementedException();
        }

        public void AddOpisStanu(OpisStanu opisStanu)
        {
            throw new NotImplementedException();
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            throw new NotImplementedException();
        }

        Dictionary<int, Katalog> IDataRepository.GetAllKatalog()
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllClient()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Zdarzenie> GetAllZdarzenia()
        {
            throw new NotImplementedException();
        }

        public List<OpisStanu> GetAllOpisStanu()
        {
            throw new NotImplementedException();
        }

        public Zdarzenie GetZdarzenieById(int zdarzenieId)
        {
            throw new NotImplementedException();
        }

        public Client GetClientById(int clientId)
        {
            throw new NotImplementedException();
        }

        public OpisStanu GetOpisStanuById(int opisStanuId)
        {
            throw new NotImplementedException();
        }

        public Katalog GetKatalogById(int katalogId)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(int Id, Client client)
        {
            throw new NotImplementedException();
        }

        void IDataRepository.UpdateKatalog(int Id, Katalog katalog)
        {
            throw new NotImplementedException();
        }

        public void UpdateOpisStanu(int Id, OpisStanu opisStanu)
        {
            throw new NotImplementedException();
        }

        public void UpdateZdarzenie(int Id, Zdarzenie zdarzenie)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(int Id)
        {
            throw new NotImplementedException();
        }

        void IDataRepository.DeleteKatalog(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteOpisStanu(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteZdarzenie(int Id)
        {
            throw new NotImplementedException();
        }
    }
}