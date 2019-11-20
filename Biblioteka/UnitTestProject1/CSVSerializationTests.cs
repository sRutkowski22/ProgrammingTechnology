using System;
using System.Collections.Generic;
using System;
using Biblioteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1;
using System.Linq;

namespace UnitTestCSVSerializationTests
{
    
    [TestClass]
    public class CSVSerializationTests
    {
       
       
      
        Graf graf = new Graf();

        [TestMethod]
        public void UnitTestClientCSV()
        {
            DataContext data = new DataContext();
            graf.fillIn(data);
            DataRepository repo = new DataRepository(data);
            ZapisCSV zapisCSV = new ZapisCSV(repo);

            DataContext data2 = new DataContext();
            DataRepository repo2 = new DataRepository(data2);
            WczytanieCSV wczytanieCSV = new WczytanieCSV(repo2);

            zapisCSV.SaveClient(repo.GetAllClient(), "ClientTest.csv");

            wczytanieCSV.ReadClient("ClientTest.csv");

            Assert.AreEqual(repo.GetAllClient().Count, repo2.GetAllClient().Count);
            Assert.AreEqual(data.clientList[0], data2.clientList[0]);
            Assert.AreEqual(data.clientList[1], data2.clientList[1]);

        }

        [TestMethod]
        public void UnitTestKatalogCSV()
        {
            DataContext data = new DataContext();
            graf.fillIn(data);
            DataRepository repo = new DataRepository(data);
            ZapisCSV zapisCSV = new ZapisCSV(repo);

            DataContext data2 = new DataContext();
            DataRepository repo2 = new DataRepository(data2);
            WczytanieCSV wczytanieCSV = new WczytanieCSV(repo2);

            zapisCSV.SaveKatalog(repo.GetAllKatalog().Values, "KatalogTest.csv");

            wczytanieCSV.ReadKatalog("KatalogTest.csv");

            Assert.AreEqual(repo.GetAllKatalog().Count, repo2.GetAllKatalog().Count);
            Assert.AreEqual(repo.GetAllKatalog()[0], repo2.GetAllKatalog()[0]);
            Assert.AreEqual(repo.GetAllKatalog()[1], repo2.GetAllKatalog()[1]);

        }

        [TestMethod]
        public void UnitTestOpisStanuCSV()
        {
            DataContext data = new DataContext();
            graf.fillIn(data);
            DataRepository repo = new DataRepository(data);
            ZapisCSV zapisCSV = new ZapisCSV(repo);

            DataContext data2 = new DataContext();
            DataRepository repo2 = new DataRepository(data2);
            WczytanieCSV wczytanieCSV = new WczytanieCSV(repo2);

            zapisCSV.SaveOpisStanu(repo.GetAllOpisStanu(), "OpisStanuTest.csv");

            wczytanieCSV.ReadOpisStanu("OpisStanuTest.csv");

            Assert.AreEqual(repo.GetAllOpisStanu().Count, repo2.GetAllOpisStanu().Count);
            Assert.AreEqual(repo.GetAllOpisStanu()[0], repo2.GetAllOpisStanu()[0]);
            Assert.AreEqual(repo.GetAllOpisStanu()[1], repo2.GetAllOpisStanu()[1]);
        }

        [TestMethod]
        public void UnitTestZdarzeniaCSV()
        {
            DataContext data = new DataContext();
            graf.fillIn(data);
            DataRepository repo = new DataRepository(data);
            ZapisCSV zapisCSV = new ZapisCSV(repo);

            DataContext data2 = new DataContext();
            DataRepository repo2 = new DataRepository(data2);
            WczytanieCSV wczytanieCSV = new WczytanieCSV(repo2);

            zapisCSV.SaveSprzedazZdarzenia(repo.GetAllZdarzenia().Where(a => a.GetType() == typeof(Sprzedaz)), "ZdarzeniaSprzedazTest.csv");
            zapisCSV.SaveZakupZdarzenia(repo.GetAllZdarzenia().Where(a => a.GetType() == typeof(Zakup)), "ZdarzeniaZakupTest.csv");

            wczytanieCSV.ReadZdarzeniaSprzedaz("ZdarzeniaSprzedazTest.csv");
            wczytanieCSV.ReadZdarzeniaZakup("ZdarzeniaZakupTest.csv");

            Assert.AreEqual(repo.GetAllZdarzenia().Count, repo2.GetAllZdarzenia().Count);
            Assert.AreEqual(repo.GetAllZdarzenia()[0], repo2.GetAllZdarzenia()[0]);
            Assert.AreEqual(repo.GetAllZdarzenia()[1], repo2.GetAllZdarzenia()[1]);

        }
    }
}
