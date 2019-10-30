using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Biblioteka
{
    internal interface IDataRepository
    {
        //C.R.U.D ADD GET ALL GET UPDATE DELETE

        // ADD
        void AddClient(Client client);
        void AddKatalog(Katalog katalog);
        void AddOpisStanu(OpisStanu opisStanu);
        void AddZdarzenie(Zdarzenie zdarzenie);
        // GET ALL
        Dictionary<int, Katalog> GetAllKatalog();
        List<Client> GetAllClient();
        ObservableCollection<Zdarzenie> GetAllZdarzenia();
        List<OpisStanu> GetAllOpisStanu();
        List<string> GetEventChangeList();
        // GET 
        Zdarzenie GetZdarzenieById(int zdarzenieId);
        Client GetClientById(int clientId);
        OpisStanu GetOpisStanuById(int opisStanuId);
        Katalog GetKatalogById(int katalogId);
        // UPDATE
        void UpdateClient(int id,Client client);
        void UpdateKatalog(int id, Katalog katalog);
        void UpdateOpisStanu(int id, OpisStanu opisStanu);
        void UpdateZdarzenie(int id, Zdarzenie zdarzenie);
        // DELETE
        void DeleteClientByID(int id);
        void DeleteKatalogByID(int id);
        void DeleteOpisStanuByID(int id);
        void DeleteZdarzenieByID(int id);

    }
}