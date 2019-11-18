using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Web;
using System.Text;

namespace Biblioteka
{
    public class FileOperations
    {
    
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
        public void saveKatalogToJSON(DataRepository repo)
        {
           
                   
            List<Katalog> lista = new List<Katalog>();
            using (StreamWriter sw = File.AppendText("Katalog.json"))
            {
                sw.Write("{\"Katalogi\":[");
                StringBuilder json_result = new StringBuilder();
               for (int i = 0; i < repo.GetAllKatalog().Count; i++)
                {

                    var obj = repo.GetAllKatalog()[i];
                    var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                    json_result.Append(jsonString + ",");
                }
                json_result.Remove(json_result.Length - 1, 1);
                sw.Write(json_result);
                sw.Write("]}");
               
            }

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
