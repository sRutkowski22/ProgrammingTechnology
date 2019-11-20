using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class WczytanieCSV 
    {
      
        DataRepository dataRepository;

        public WczytanieCSV(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository; 
        }

        public void Read()
        {
            dataRepository.clearData();
            ReadKatalog("Katalog.csv");
            ReadOpisStanu("OpisStanu.csv");
            ReadClient("Client.csv");
            ReadZdarzeniaSprzedaz("ZdarzeniaSprzedaz.csv");
            ReadZdarzeniaZakup("ZdarzeniaZakup.csv");
        }

        public void ReadKatalog(string filename)
        {
            String line;
            FormatterCSV<Katalog> formatterCSV = new FormatterCSV<Katalog>();
            // Read the file and display it line by line.  
            StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                Katalog obj = (Katalog) formatterCSV.Deserialize(GenerateStreamFromString(line));
                dataRepository.AddKatalog(obj);
            }

            file.Close();

        }

        public void ReadOpisStanu(string filename)
        {
            String line;
            FormatterCSV<OpisStanu> formatterCSV = new FormatterCSV<OpisStanu>();
            // Read the file and display it line by line.  
            StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                OpisStanu obj = (OpisStanu)formatterCSV.Deserialize(GenerateStreamFromString(line));
                dataRepository.AddOpisStanu(obj);
            }

            file.Close();
        }
        public void ReadClient(string filename)
        {
            String line;
            FormatterCSV<Client> formatterCSV = new FormatterCSV<Client>();
            // Read the file and display it line by line.  
            StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                Client obj = (Client)formatterCSV.Deserialize(GenerateStreamFromString(line));
                dataRepository.AddClient(obj);
            }

            file.Close();
        }

        public void ReadZdarzeniaSprzedaz(string filename)
        {
            String line;
            FormatterCSV<Sprzedaz> formatterCSV = new FormatterCSV<Sprzedaz>();
            // Read the file and display it line by line.  
            StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                Sprzedaz obj = (Sprzedaz)formatterCSV.Deserialize(GenerateStreamFromString(line));
                dataRepository.AddZdarzenie(obj);
            }

            file.Close();
        }
        public void ReadZdarzeniaZakup(string filename)
        {
            String line;
            FormatterCSV<Zakup> formatterCSV = new FormatterCSV<Zakup>();
            // Read the file and display it line by line.  
            StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                Zakup obj = (Zakup)formatterCSV.Deserialize(GenerateStreamFromString(line));
                dataRepository.AddZdarzenie(obj);
            }

            file.Close();
        }



        private Stream GenerateStreamFromString(string s)
            {
                var stream = new MemoryStream();
                var writer = new StreamWriter(stream);
                writer.Write(s);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
        }
}
