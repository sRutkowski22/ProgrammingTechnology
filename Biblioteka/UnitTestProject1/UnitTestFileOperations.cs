using System;
using Biblioteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1;

namespace UnitTestFileOperations
{
    [TestClass]
    public class UnitTestFileOperations
    {
        FileOperations fileOp = new FileOperations();
        DataContext data = new DataContext();
        DataContext data2 = new DataContext();
        Graf graf = new Graf();
       
        [TestMethod]
        public void UnitTestClientJson()
        {
            graf.fillIn(data);
            DataRepository repo = new DataRepository(data);
            DataRepository repo2 = new DataRepository(data2);
            fileOp.AllToJson(repo, "Clients.json", "Katalogi.json", "OpisStanu.json", "Zdarzenia.json");
            repo2.setClientsList(fileOp.loadClientFromJson("Clients.json"));
            
            
            Assert.AreEqual(repo.GetAllClient().Count, repo2.GetAllClient().Count);
            Assert.AreEqual(data.clientList[0], data2.clientList[0]);
            Assert.AreEqual(data.clientList[1], data2.clientList[1]);
        }

        [TestMethod]
        public void UnitTestKatalogJson()
        {
            graf.fillIn(data);
            DataRepository repo = new DataRepository(data);
            DataRepository repo2 = new DataRepository(data2);
            fileOp.AllToJson(repo, "Clients.json", "Katalogi.json", "OpisStanu.json", "Zdarzenia.json");
            repo2.setKatalogDict(fileOp.loadKatalogFromJson("Katalogi.json"));
            Assert.AreEqual(repo.GetAllKatalog().Count, repo2.GetAllKatalog().Count);
            Assert.AreEqual(repo.GetAllKatalog()[0], repo2.GetAllKatalog()[0]);
            Assert.AreEqual(repo.GetAllKatalog()[1], repo2.GetAllKatalog()[1]);

        }

        [TestMethod]
        public void UnitTestOpisStanuJson()
        {
            graf.fillIn(data);
            DataRepository repo = new DataRepository(data);
            DataRepository repo2 = new DataRepository(data2);
            fileOp.AllToJson(repo, "Clients.json", "Katalogi.json", "OpisStanu.json", "Zdarzenia.json");
            repo2.setOpisStanuList(fileOp.loadOpisStanuFromJson("OpisStanu.json"));
            Assert.AreEqual(repo.GetAllOpisStanu().Count, repo2.GetAllOpisStanu().Count);
            Assert.AreEqual(repo.GetAllOpisStanu()[0], repo2.GetAllOpisStanu()[0]);
            Assert.AreEqual(repo.GetAllOpisStanu()[1], repo2.GetAllOpisStanu()[1]);
        }

        [TestMethod]
        public void UnitTestZdarzeniaJson()
        {
            graf.fillIn(data);
            DataRepository repo = new DataRepository(data);
            DataRepository repo2 = new DataRepository(data2);
            fileOp.AllToJson(repo, "Clients.json", "Katalogi.json", "OpisStanu.json", "Zdarzenia.json");
            repo2.setZdarzeniaList(fileOp.loadZdarzeniaFromJson("Zdarzenia.json"));
            Assert.AreEqual(repo.GetAllZdarzenia().Count, repo2.GetAllZdarzenia().Count);
            Assert.AreEqual(repo.GetAllZdarzenia()[0], repo2.GetAllZdarzenia()[0]);
           

        }
    }
}
