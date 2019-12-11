using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class KlasaNarzedziowaEtap5
    {
        public static List<MyProduct> GetProductsByVendorName(string vendorName)
        {
            MyProductContext data = new MyProductContext();
            data.Products.Where(p => p.ProductVendors.Where(pv => pv.Vendor.Name.Contains(vendorName));
           // data.Products.Select(p=> new String()
           // return (from product in data.Products
          //          join pv in )
           
        }
        public static List<MyProduct> GetNMyProductsFromCategory(string categoryName, int n)
        {
            MyProductContext data = new MyProductContext();
            return (from product in data.Products
                    where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                    select product).Take(n).ToList();
        }
        public static List<MyProduct> GetMyProductsByName(string namePart)
        {
            MyProductContext data = new MyProductContext();
            return data.Products.Where(p => p.Name.Contains(namePart)).ToList();
        }


        public static List<MyProduct> GetMyProductsWithNRecentReviews(int howManyReviews)
        {
            MyProductContext data = new MyProductContext();
            List<MyProduct> products = data.Products;

            return products.Where(p => p.ProductReviews.Count == howManyReviews).ToList();
        }

       
    }
}
