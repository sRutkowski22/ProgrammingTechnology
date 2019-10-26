using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteka;
namespace UnitTestProject1
{
    [TestClass]
    public class DataRepositoryTests
    {
       
        
        [TestMethod]
        public void TestClient()
        {
            DataContext data = new DataContext();
            DataRepository repo = new DataRepository(data);
            Client c1 = new Client(1, "Adam", "Nowak");
            Client c2 = new Client(1, "Grzegorz", "Małysz");
            //Katalog kat1 = new Katalog("Potop", new AutorKsiazki("Henryk", "Sienkiewicz"), "PolskavsSzwecja");
            //OpisStanu opis1 = new OpisStanu(1, kat1, 2, 100);
            repo.AddClient(c1);
            Assert.AreEqual(repo.GetClientById(1), c1);
            repo.UpdateClient(1, c2);
            Assert.AreEqual(repo.GetClientById(1), c2);
            repo.DeleteClient(1);
            Assert.AreEqual(repo.GetClientById(1), null);
            


        }
    }
}
