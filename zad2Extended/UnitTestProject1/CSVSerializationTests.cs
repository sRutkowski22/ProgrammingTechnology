using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zad2Extended;

namespace UnitTestProject1
{
    [TestClass]
    public class CSVSerializationTests
    {
      /*  [TestMethod]
        public void TestClassA()
        {
            DataContext data = new DataContext();
            ClassA ca1 = new ClassA("klasaanazwa", 5, true, null);
            ClassB cb1 = new ClassB("klasabnazwa", 6, true, null);
            ClassC cc1 = new ClassC("klasacnazwa", 7, false, ca1);
            ca1.classB = cb1;
            cb1.classC = cc1;
            data.classAList.Add(ca1);
            data.classBList.Add(cb1);
            data.classCList.Add(cc1);
            
            ZapisCSV zapisCSV = new ZapisCSV(data);

            DataContext data2 = new DataContext();
           
            WczytanieCSV wczytanieCSV = new WczytanieCSV(data2);

            zapisCSV.SaveClassA(data.classAList,"ClassA.csv");

         //   wczytanieCSV.ReadClassA("ClassA.csv");


            Assert.AreEqual(data.classAList, data2.classAList);
            Assert.AreEqual(data.classAList[0], data2.classAList[0]);
            Assert.AreEqual(data.classAList[1], data2.classAList[1]);
        }
        */
    }
}
