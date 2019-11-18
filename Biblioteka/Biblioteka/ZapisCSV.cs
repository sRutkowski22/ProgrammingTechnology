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
        DataContext dataContext;

        public ZapisCSV(DataContext dataContext)
        {
            this.dataContext = dataContext;
          
        }

        public void Save()
        {
            SaveKatalog(dataContext.dictionaryKatalog.Values, "Katalog.csv");
        }

        public void SaveKatalog(IEnumerable<Katalog> kontener, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            foreach (Katalog katalog in kontener)
            {
              
                Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
                FormatterCSV<Katalog> fromatterCSV = new FormatterCSV<Katalog>();
                fromatterCSV.Serialize(stream, katalog);
                stream.Close();
            }
          
        }

       

    }
}

