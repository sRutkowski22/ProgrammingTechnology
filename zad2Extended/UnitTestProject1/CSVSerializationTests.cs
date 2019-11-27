using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zad2Extended;

namespace UnitTestProject1
{
    [TestClass]
    public class CSVSerializationTests
    {
        [TestMethod]
        public void TestClassA()
        {
            DataContext data = new DataContext();
            DataContext data2 = new DataContext();

            ClassA ca1 = new ClassA("klasaAnazwa", 5.2F, true, DateTime.ParseExact("2019.12.12", "yyyy.MM.dd", CultureInfo.CurrentCulture), null);
            ClassB cb1 = new ClassB("klasaBnazwa", 6.5F, true, DateTime.ParseExact("2019.12.11", "yyyy.MM.dd", CultureInfo.CurrentCulture), null);
            ClassC cc1 = new ClassC("klasaCnazwa", 7.35F, false, DateTime.ParseExact("2019.12.10", "yyyy.MM.dd", CultureInfo.CurrentCulture), ca1);
            ca1.classB = cb1;
            cb1.classC = cc1;

            //serializacja
            String filename = "serialize.csv";
            File.WriteAllText(filename, string.Empty);

            FormatterCSV fromatterCSV = new FormatterCSV();
            fromatterCSV.Binder = new KnownTypesBinder();
            fromatterCSV.objectIDGenerator = new ObjectIDGenerator();

            fromatterCSV.Serialize(ca1);
           
            //deserializacja
            fromatterCSV.Binder = new KnownTypesBinder();
            fromatterCSV.objectIDGenerator = new ObjectIDGenerator();

            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            Dictionary<long, object> list = (Dictionary<long, object>)fromatterCSV.Deserialize(stream);

            Assert.AreEqual(ca1.ToString(), list[1].ToString());
            Assert.AreEqual(cb1.ToString(), list[2].ToString());
            Assert.AreEqual(cc1.ToString(), list[3].ToString());
        }
        
    }
}
