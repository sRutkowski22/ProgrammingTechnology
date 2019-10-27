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
            repo.AddClient(c1);
            Assert.AreEqual(repo.GetClientById(1), c1);
            repo.UpdateClient(1, c2);
            Assert.AreEqual(repo.GetClientById(1), c2);
            repo.DeleteClientByID(1);
            Assert.AreEqual(repo.GetClientById(1), null);          
        }
        [TestMethod]
        public void TestKatalog()
        {
            DataContext data = new DataContext();
            DataRepository repo = new DataRepository(data);
            Katalog kat1 = new Katalog("Potop", new AutorKsiazki("Henryk", "Sienkiewicz"), "PolskavsSzwecja");
            repo.AddKatalog(kat1);
            Assert.AreSame(repo.GetKatalogById(1), kat1);
            repo.DeleteKatalogByID(1);
            Assert.IsFalse(repo.GetAllKatalog().ContainsKey(1));
           
        }
        [TestMethod]
        public void TestOpisStanu()
        {
            DataContext data = new DataContext();
            DataRepository repo = new DataRepository(data);           
            Katalog kat1 = new Katalog("Potop", new AutorKsiazki("Henryk", "Sienkiewicz"), "PolskavsSzwecja");
            OpisStanu opis1 = new OpisStanu(1, kat1, 2, 100);
            Assert.AreSame(repo.GetOpisStanuById(1), null);
            repo.AddOpisStanu(opis1);
            Assert.AreSame(repo.GetOpisStanuById(1), opis1);
            repo.DeleteOpisStanuByID(1);
            Assert.AreSame(repo.GetOpisStanuById(1), null);
        }
        [TestMethod]
        public void TestZdarzenie()
        {
            DataContext data = new DataContext();
            DataRepository repo = new DataRepository(data);
            Client c1 = new Client(1, "Adam", "Nowak");
            Katalog kat1 = new Katalog("Potop", new AutorKsiazki("Henryk", "Sienkiewicz"), "PolskavsSzwecja");
            OpisStanu opis1 = new OpisStanu(1, kat1, 2, 100);
            Zdarzenie zd1 = new Sprzedaz(1, opis1, 2, 40,c1, DateTime.Now);
            repo.AddZdarzenie(zd1);
            Assert.AreEqual(repo.GetZdarzenieById(1), zd1);
            repo.DeleteZdarzenieByID(1);
            Assert.AreEqual(repo.GetZdarzenieById(1), null);
        }
    }
}
