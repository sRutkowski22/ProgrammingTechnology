using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class ZapisCSV
    {
        DataRepository dataRepository;

        public ZapisCSV(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
          
        }

        public void Save()
        {
            SaveKatalog(dataRepository.GetAllKatalog().Values, "Katalog.csv");
            SaveOpisStanu(dataRepository.GetAllOpisStanu(), "OpisStanu.csv");
            SaveClient(dataRepository.GetAllClient(), "Client.csv");
            SaveSprzedazZdarzenia(dataRepository.GetAllZdarzenia().Where(a => a.GetType() == typeof(Sprzedaz)), "ZdarzeniaSprzedaz.csv");
            SaveZakupZdarzenia(dataRepository.GetAllZdarzenia().Where(a => a.GetType() == typeof(Zakup)), "ZdarzeniaZakup.csv");
        }

        public void SaveKatalog(IEnumerable<Katalog> kontener, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            foreach (Katalog iterator in kontener)
            {
                Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
                FormatterCSV<Katalog> fromatterCSV = new FormatterCSV<Katalog>();
                fromatterCSV.Serialize(stream, iterator);
                stream.Close();
            }
          
        }

        public void SaveOpisStanu(IEnumerable<OpisStanu> kontener, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            foreach (OpisStanu iterator in kontener)
            { 
                Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
                FormatterCSV<Katalog> fromatterCSV = new FormatterCSV<Katalog>();
                fromatterCSV.Serialize(stream, iterator);
                stream.Close();
            }

        }
        public void SaveClient(IEnumerable<Client> kontener, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            foreach (Client iterator in kontener)
            {
                Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
                FormatterCSV<Client> fromatterCSV = new FormatterCSV<Client>();
                fromatterCSV.Serialize(stream, iterator);
                stream.Close();
            }

        }

        public void SaveSprzedazZdarzenia(IEnumerable<Zdarzenie> kontener, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            foreach (Sprzedaz iterator in kontener)
            {
                Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
                FormatterCSV<Sprzedaz> fromatterCSV = new FormatterCSV<Sprzedaz>();
                fromatterCSV.Serialize(stream, iterator);
                stream.Close();
            }

        }
        public void SaveZakupZdarzenia(IEnumerable<Zdarzenie> kontener, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            foreach (Zakup iterator in kontener)
            {
                Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
                FormatterCSV<Zakup> fromatterCSV = new FormatterCSV<Zakup>();
                fromatterCSV.Serialize(stream, iterator);
                stream.Close();
            }

        }



    }
}

