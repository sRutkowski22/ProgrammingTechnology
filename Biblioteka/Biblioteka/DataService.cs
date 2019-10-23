using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Biblioteka
{
    class DataService
    {
        private IDataRepository dataRepository;
        DataService(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public Dictionary<int, Katalog> GetAllKatalog()
        {
            return dataRepository.GetAllKatalog();
        }
        private List<Client> GetAllClient()
        {
            return dataRepository.GetAllClient();
        }
        public ObservableCollection<Zdarzenie> GetAllZdarzenia()
        {
            return dataRepository.GetAllZdarzenia();
        }
        public List<OpisStanu> GetAllOpisStanu()
        {
            return dataRepository.GetAllOpisStanu();
        }

        public ObservableCollection<Zdarzenie> GetAllZdarzeniaThisClient(int clientID)
        {

            ObservableCollection<Zdarzenie> zdarzenies = dataRepository.GetAllZdarzenia();
            ObservableCollection<Zdarzenie> resultZdarzenies = new ObservableCollection<Zdarzenie>();
            foreach (Zdarzenie zdarzenie in zdarzenies)
            {
                if(zdarzenie.clientId== clientID)
                {
                    resultZdarzenies.Add(zdarzenie);
                }
            }
            return resultZdarzenies;
        }

        public ObservableCollection<Zdarzenie> GetAllZdarzeniaThisDay(DateTime dateTime)
        {
            ObservableCollection<Zdarzenie> zdarzenies = dataRepository.GetAllZdarzenia();
            ObservableCollection<Zdarzenie> resultZdarzenies = new ObservableCollection<Zdarzenie>();
            foreach (Zdarzenie zdarzenie in zdarzenies)
            {
                if (zdarzenie.dataKupienia.Day.Equals(dateTime.Day))
                {
                    resultZdarzenies.Add(zdarzenie);
                }
            }
            return resultZdarzenies;
        }

        public HashSet<Katalog> GetAllKatalogBuyByThisClient(int clientID)
        {

            ObservableCollection<Zdarzenie> zdarzeniesThisClient = GetAllZdarzeniaThisClient(clientID);
            HashSet<Katalog> resultKatalog = new HashSet<Katalog>();
            foreach (Zdarzenie zdarzenie in zdarzeniesThisClient)
            {
                resultKatalog.Add(findKatalogByZdarzenie(zdarzenie));
            }
            return resultKatalog;
        }

        public HashSet<Katalog> GetAllKatalogBuyByThisClientAndThisDay(int clientID,DateTime dateTime)
        {

            ObservableCollection<Zdarzenie> zdarzeniesThisClient = GetAllZdarzeniaThisClient(clientID);
            ObservableCollection<Zdarzenie> zdarzeniesThisDay = GetAllZdarzeniaThisDay(dateTime);
            HashSet<Katalog> resultKatalog = new HashSet<Katalog>();
            foreach (Zdarzenie zdarzenieClient in zdarzeniesThisClient)
            {
                foreach(Zdarzenie zdarzenieDay in zdarzeniesThisDay)
                {
                    if (zdarzenieDay.zdarzeniaId.Equals(zdarzenieClient.zdarzeniaId))
                    {
                        resultKatalog.Add(findKatalogByZdarzenie(zdarzenieDay));
                    }
                }
                        

            }
            return resultKatalog;
        }

        public void AddClient(Client client)
        {
            dataRepository.AddClient(client);
        }
        public void AddKatalog(Katalog katalog)
        {
            dataRepository.AddKatalog(katalog);
        }
        public void AddOpisStanu(OpisStanu opisStanu)
        {
            dataRepository.AddOpisStanu(opisStanu);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            dataRepository.AddZdarzenie(zdarzenie);
        }


        private Katalog findKatalogByZdarzenie(Zdarzenie zdarzenie)
        {
            int katalogId = dataRepository.GetOpisStanuById(zdarzenie.opisStanuId).katalogId;
            return dataRepository.GetKatalogById(katalogId);
        }

    }
}
