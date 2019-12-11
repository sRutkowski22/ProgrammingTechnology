using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteka;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class Etap4Test
    {
        

        [TestMethod()]
        public void ProductAndVendorNameTest()
        {
            List<Product> query = KlasaNarzędziowaEtap3.GetProductsByName("Adjustable Race");

            if (query.ProductWithItsVendor().Replace("\n", "") != "Adjustable Race-Litware, Inc.") Assert.Fail();
        }

        [TestMethod()]
        public void NoCategoryTest()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<Product> temp = (from p in db.Products select p).ToList(); //all
            temp = temp.NoCategoryProducts();
            if (temp.Count() != 209) Assert.Fail();
        }

        [TestMethod()]
        public void DivideTest()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<Product> request = (from p in db.Products select p).ToList(); //all
            request = request.DividedListProductVendor(5, 3);

            List<Product> constance = new List<Product>();
            Product temp = (from p in db.Products where p.ProductID == 327 select p).First();
            constance.Add(temp);
            temp = (from p in db.Products where p.ProductID == 328 select p).First();
            constance.Add(temp);
            temp = (from p in db.Products where p.ProductID == 329 select p).First();
            constance.Add(temp);
           

            for (int i = 0; i < request.Count(); i++)
            {
                if (request[i].ProductID != constance[i].ProductID) Assert.Fail();
                if (request[i].Name != constance[i].Name) Assert.Fail();
            }
          



        }
    }

}

