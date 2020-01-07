using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteka;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class KlasaNarzędziowaEtap5Testscs
    {
        [TestClass]
        public class MyProductTest
        {

            [TestMethod]
            public void GetMyProductsByName()
            {
                int ilosc = KlasaNarzedziowaEtap5.GetMyProductsByName("Blade").Count;
                Assert.AreEqual(1, ilosc);
            }


            [TestMethod]
            public void GetProductsByVendorName()
            {
                List<MyProduct> products = KlasaNarzedziowaEtap5.GetProductsByVendorName("Allenson Cycles");

                if (products[0].ProductID != 530) Assert.Fail();
           
            }


            [TestMethod]
            public void GetMyProductsWithNRecentReviews()
            {
                List<MyProduct> products = KlasaNarzedziowaEtap5.GetMyProductsWithNRecentReviews(1);
                Assert.AreEqual(products.Count, 2);
                Assert.IsNotNull(products.Find(product => product.ProductID == 709));
                Assert.IsNotNull(products.Find(product => product.ProductID == 798));
            }
        }
    }
}

