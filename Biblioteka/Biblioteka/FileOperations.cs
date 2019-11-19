﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Biblioteka
{
    public class FileOperations
    {
        public void saveKatalogToJson(Dictionary<int,Katalog> kat, string path)
        {
            var json = JsonConvert.SerializeObject(kat,Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(@path,json);
        }

        public void saveClientToJson(List<Client> clients, string path)
        {
            var json = JsonConvert.SerializeObject(clients, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(@path, json);
        }

        public void saveZdarzeniaToJson(IEnumerable<Zdarzenie>zdarzenia, string path)
        {
            
            var json = JsonConvert.SerializeObject(zdarzenia, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling=TypeNameHandling.Auto });
            File.WriteAllText(@path, json);
        }

        public void saveOpisStanuToJson(IEnumerable<OpisStanu> opisStanu, string path)
        {

            var json = JsonConvert.SerializeObject(opisStanu, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(@path, json);
        }
        public void AllToJson(DataRepository repo, string clientPath,string katalogPath, string opisStanuPath, string zdarzeniePath)
        {
            saveClientToJson(repo.GetAllClient(), clientPath);
            saveKatalogToJson(repo.GetAllKatalog(), katalogPath);
            saveOpisStanuToJson(repo.GetAllOpisStanu(), opisStanuPath);
            saveZdarzeniaToJson(repo.GetAllZdarzenia(), zdarzeniePath);
        }

        public List<Client> loadClientFromJson(string path)
        {
            using (StreamReader r = new StreamReader(@path))
            {
                var json = r.ReadToEnd();
                List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(json,  new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.Auto });
                return clients;
            }
        }
        public Dictionary<int,Katalog> loadKatalogFromJson(string path)
        {
            using (StreamReader r = new StreamReader(@path))
            {
                var json = r.ReadToEnd();
                Dictionary<int,Katalog> kat = JsonConvert.DeserializeObject<Dictionary<int,Katalog>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.Auto });
                return kat;
            }
        }
        public List<OpisStanu> loadOpisStanuFromJson(string path)
        {
            using (StreamReader r = new StreamReader(@path))
            {
                var json = r.ReadToEnd();
                List<OpisStanu> opisStanuList = JsonConvert.DeserializeObject<List<OpisStanu>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.Auto });
                return opisStanuList;
            }
        }
        public ObservableCollection<Zdarzenie> loadZdarzeniaFromJson(string path)
        {
            using (StreamReader r = new StreamReader(@path))
            {
                var json = r.ReadToEnd();
                ObservableCollection<Zdarzenie> zdarzenia = JsonConvert.DeserializeObject<ObservableCollection<Zdarzenie>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects, TypeNameHandling = TypeNameHandling.Auto });
                return zdarzenia;
            }
        }

    }
}
