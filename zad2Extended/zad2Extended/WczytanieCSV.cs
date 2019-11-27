using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace zad2Extended
{
    public class WczytanieCSV
    {

     /*   DataContext dataContext;

        public WczytanieCSV(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Read()
        {
            this.dataContext= new DataContext();
            ReadClassA("ClassA.csv");
            ReadClassB("ClassB.csv");
            ReadClassC("ClassC.csv");
         
            DuplicateExecutor.duplicateDelete(dataContext);
        }

        public void ReadClassA(string filename)
        {
            String line;
            FormatterCSV<ClassA> formatterCSV = new FormatterCSV<ClassA>();
            // Read the file and display it line by line.  
            StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                ClassA obj = (ClassA)formatterCSV.Deserialize(GenerateStreamFromString(line));
                dataContext.classAList.Add(obj);
            }

            file.Close();

        }

        public void ReadClassB(string filename)
        {
            String line;
            FormatterCSV<ClassB> formatterCSV = new FormatterCSV<ClassB>();
            // Read the file and display it line by line.  
            StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                ClassB obj = (ClassB)formatterCSV.Deserialize(GenerateStreamFromString(line));
                dataContext.classBList.Add(obj);
            }

            file.Close();
        }
        public void ReadClassC(string filename)
        {
            String line;
            FormatterCSV<ClassC> formatterCSV = new FormatterCSV<ClassC>();
            // Read the file and display it line by line.  
            StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                ClassC obj = (ClassC)formatterCSV.Deserialize(GenerateStreamFromString(line));
                dataContext.classCList.Add(obj);
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
        */
    }
}