using System;
using Biblioteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void TestReadDataFromFile()
        {
            DataContext context = new DataContext();
            WypelnianieZPliku plik = new WypelnianieZPliku();
            DataRepository dataRepository = new DataRepository(context, plik);
            
            
          

          

        }
    }
}
