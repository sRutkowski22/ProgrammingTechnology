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
            ReadKatalog("Katalog.csv");
        }

        private void ReadKatalog(string filename)
        {
            String line;
            FormatterCSV<Katalog> formatterCSV = new FormatterCSV<Katalog>();
            // Read the file and display it line by line.  
            StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                Katalog katalog = (Katalog) formatterCSV.Deserialize(GenerateStreamFromString(line));
                dataRepository.AddKatalog(katalog);
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
