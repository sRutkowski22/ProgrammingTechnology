using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace zad2Extended
{
    public class ZapisCSV
    {
      /*  DataContext data;

        public ZapisCSV(DataContext data)
        {
            this.data = data;

        }

        public void Save()
        {
            SaveClassA(data.classAList, "ClassA.csv");
            SaveClassB(data.classBList, "ClassB.csv");
            SaveClassC(data.classCList, "ClassC.csv");
          
        }

        public void SaveClassA(IEnumerable<ClassA> kontener, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            foreach (ClassA iterator in kontener)
            {
                Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
                FormatterCSV<ClassA> fromatterCSV = new FormatterCSV<ClassA>();
                fromatterCSV.Serialize(stream, iterator);
                stream.Close();
            }

        }

        public void SaveClassB(IEnumerable<ClassB> kontener, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            foreach (ClassB iterator in kontener)
            {
                Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
                FormatterCSV<ClassB> fromatterCSV = new FormatterCSV<ClassB>();
                fromatterCSV.Serialize(stream, iterator);
                stream.Close();
            }

        }
        public void SaveClassC(IEnumerable<ClassC> kontener, string filename)
        {
            File.WriteAllText(filename, string.Empty);
            foreach (ClassC iterator in kontener)
            {
                Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
                FormatterCSV<ClassC> fromatterCSV = new FormatterCSV<ClassC>();
                fromatterCSV.Serialize(stream, iterator);
                stream.Close();
            }

        }

      

    */

    }
}