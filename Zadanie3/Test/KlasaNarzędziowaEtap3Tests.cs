using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteka;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class KlasaNarzędziowaEtap3Tests
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        [TestMethod()]
        public void GetProductsByNameTest()
        {
           
            List<Product> products = KlasaNarzędziowaEtap3.GetProductsByName("Blade");

            List<Product> stala = new List<Product>();
            Product C = (from p in db.Products where p.ProductID == 316 select p).First();
            stala.Add(C);
        

            for (int i = 0; i < products.Count(); i++)
            {
                if (products[i].ProductID != stala[i].ProductID) Assert.Fail();
                if (products[i].Name != stala[i].Name) Assert.Fail();
            }
            if (products.Count() != stala.Count()) Assert.Fail();
        }
        [TestMethod()]
        public void GetProductsByVendorNameTest()
        {
        

            List<Product> products = KlasaNarzędziowaEtap3.GetProductsByVendorName("Allenson Cycles");

            List<Product> stala = new List<Product>();
            Product C = (from p in db.Products where p.ProductID == 530 select p).First();
            stala.Add(C);

            if (products[0].ProductID != stala[0].ProductID) Assert.Fail();
            if (products[0].Name != stala[0].Name) Assert.Fail();

        }

        [TestMethod()]
        public void GetProductNamesByVendorNameTest()
        {
         

            List<string> products = KlasaNarzędziowaEtap3.GetProductNamesByVendorName("Allenson Cycles");

            List<Product> stala = new List<Product>();
            Product C = (from p in db.Products where p.ProductID == 530 select p).First();
            stala.Add(C);
           if (products[0] != stala[0].Name) Assert.Fail();
           

        }

        [TestMethod()]
        public void GetProductVendorByProductNameTest()
        {
         

            string zapytanie = KlasaNarzędziowaEtap3.GetProductVendorByProductName("Decal 1");

            string str = "SUPERSALES INC.";
            if (str != zapytanie) Assert.Fail();
        }

        [TestMethod()]
        public void GetProductsWithNRecentReviewsTest()
        {
          

            List<Product> zapytanie = KlasaNarzędziowaEtap3.GetProductsWithNRecentReviews(10);

            List<Product> stala = new List<Product>();
            Product C = (from p in db.Products where p.ProductID == 709 select p).First();
            stala.Add(C);
            C = (from p in db.Products where p.ProductID == 937 select p).First();
            stala.Add(C);
            stala.Add(C);
            C = (from p in db.Products where p.ProductID == 798 select p).First();
            stala.Add(C);

            for (int i = 0; i < zapytanie.Count(); i++)
            {
                if (zapytanie[i].ProductID != stala[i].ProductID) Assert.Fail();
                if (zapytanie[i].Name != stala[i].Name) Assert.Fail();
            }
            if (zapytanie.Count() != stala.Count()) Assert.Fail();
        }
        [TestMethod()]
        public void GetNRecentlyReviewedProductsTest()
        {
         

            List<Product> zapytanie = KlasaNarzędziowaEtap3.GetNRecentlyReviewedProducts(10);

            List<Product> stala = new List<Product>();
            Product C = (from p in db.Products where p.ProductID == 709 select p).First();
            stala.Add(C);
            C = (from p in db.Products where p.ProductID == 937 select p).First();
            stala.Add(C);
            stala.Add(C);
            C = (from p in db.Products where p.ProductID == 798 select p).First();
            stala.Add(C);

            for (int i = 0; i < zapytanie.Count(); i++)
            {
                if (zapytanie[i].ProductID != stala[i].ProductID) Assert.Fail();
                if (zapytanie[i].Name != stala[i].Name) Assert.Fail();
            }
            if (zapytanie.Count() != stala.Count()) Assert.Fail();
        }

        [TestMethod()]
        public void GetNProductsFromCategoryTest()
        {
           

            List<Product> zapytanie = KlasaNarzędziowaEtap3.GetNProductsFromCategory("Bikes", 2);

            List<Product> stala = new List<Product>();
            Product C = (from p in db.Products where p.ProductID == 771 select p).First();
            stala.Add(C);
            C = (from p in db.Products where p.ProductID == 772 select p).First();
            stala.Add(C);

            for (int i = 0; i < zapytanie.Count(); i++)
            {
                if (zapytanie[i].ProductID != stala[i].ProductID) Assert.Fail();
                if (zapytanie[i].Name != stala[i].Name) Assert.Fail();
            }
            if (zapytanie.Count() != stala.Count()) Assert.Fail();
        }

        [TestMethod()]
        public void GetTotalStandardCostByCategoryTest()
        {
           
            ProductCategory C = (from p in db.ProductCategories where p.ProductCategoryID == 1 select p).First();

            decimal zapytanie = (decimal) KlasaNarzędziowaEtap3.GetTotalStandardCostByCategory(C);
            decimal final = (decimal)153913.49;
            //Console.WriteLine(zapytanie);
            //Console.WriteLine(153913.49);

            if (final != zapytanie) Assert.Fail();
            //if(Tools.GetTotalStandardCostByCategory(C) != 153913.49) Assert.Fail();
        }


    }
}
