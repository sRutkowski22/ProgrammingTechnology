using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka
{
    public static class ProductExtension
    {
        public static String ProductWithItsVendor(this List<Product> lista)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            string str = "";
            foreach (var produkt in lista)
            {
                var request = new
                {
                    prodName = (from p in db.Products
                                join pv in db.ProductVendors on p.ProductID equals pv.ProductID
                                join v in db.Vendors on pv.BusinessEntityID equals v.BusinessEntityID
                                where produkt.ProductID == p.ProductID
                                select p.Name).First(),

                    vendor = (from p in db.Products
                              join pv in db.ProductVendors on p.ProductID equals pv.ProductID
                              join v in db.Vendors on pv.BusinessEntityID equals v.BusinessEntityID
                              where produkt.ProductID == p.ProductID
                              select v.Name).First()
                };
                str += request.prodName + "-" + request.vendor + "\n";
               
            };
            var objectKeeper = str;
            return str.ToString();
        }

        public static List<Product> NoCategoryProducts(this List<Product> lista)
        {
            List<Product> NoCategoryLista = new List<Product>();
            foreach(Product produkt in lista)
            {
                if (produkt.ProductSubcategory == null)
                    NoCategoryLista.Add(produkt);
            }
            return NoCategoryLista;
        }

        public static List<Product> DividedListProductVendor(this List<Product> list, int size, int page)
        {
            List<Product> productListForPage = new List<Product>();
            for( int i=0; i<list.Count(); i++)
            {
                if (i > (size * page) && i <= (size * page))
                    productListForPage.Add(list[i]);
            }
            return productListForPage;
        }
    }
}
