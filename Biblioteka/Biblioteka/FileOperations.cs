using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace Biblioteka
{
    public class FileOperations
    {
        public void saveKatalogToJson(IEnumerable<Katalog> kat, string path)
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
            saveKatalogToJson(repo.GetAllKatalog().Values, katalogPath);
            saveOpisStanuToJson(repo.GetAllOpisStanu(), opisStanuPath);
            saveZdarzeniaToJson(repo.GetAllZdarzenia(), zdarzeniePath);
        }
        public void loadFromJson(DataContext data)
        {
            using (StreamReader r = new StreamReader("Biblioteka.json"))
            {
                var json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<DataContext>(json);
            }
                
        }
    
        public XElement xmlKatalog(DataRepository repo)
        {
            XElement rootKat = new XElement("Katalogi");
            Dictionary<int, Katalog>.KeyCollection keys = repo.GetAllKatalog().Keys;
            XElement kat = new XElement("Katalog");
            
                foreach(int key in keys)
            {
               
                kat.Add(new XAttribute("value", repo.GetAllKatalog()[key].autorKsiazki.imie + " "+ repo.GetAllKatalog()[key].autorKsiazki.nazwisko));
            }
            rootKat.Add(kat);

            return rootKat;

        }
        public void saveClientToXML(DataRepository repo)
        {
           
            XmlRootAttribute theRoot = new XmlRootAttribute();
            
            theRoot.ElementName = "Biblioteka";
            theRoot.IsNullable = true;
            
            XmlRootAttribute clientRoot = new XmlRootAttribute();
            clientRoot.ElementName = "Clients";
            clientRoot.IsNullable = true;
            XmlSerializer oSerializerClient = new XmlSerializer(typeof(List<Client>),clientRoot);
            XmlSerializer oSerializerOpisStanu = new XmlSerializer(typeof(List<OpisStanu>), clientRoot );
            StreamWriter oStreamWriter = new StreamWriter("Clients.xml");
            oSerializerClient.Serialize(oStreamWriter, repo.GetAllClient());
            //oSerializerOpisStanu.Serialize(oStreamWriter, repo.GetAllOpisStanu());


        }       
       
        public void loadClientFromXML(DataRepository repo)
        {
            List<Client> lista;
            using (var reader = new StreamReader("Clients.xml"))
            {
               
                XmlRootAttribute clientRoot = new XmlRootAttribute();
                clientRoot.ElementName = "Clients";
                clientRoot.IsNullable = true;
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Client>),clientRoot);
                lista = (List<Client>)deserializer.Deserialize(reader);
            }
            foreach (Client c in lista)
            {
                repo.AddClient(c);

            }        
        }

    }
}
