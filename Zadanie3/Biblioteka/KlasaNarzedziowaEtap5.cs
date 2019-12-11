using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class KlasaNarzedziowaEtap5
    {
        public static List<MyProduct> GetProductsByVendorName(string vendorName)
        {
            MyProductContext data = new MyProductContext();

            return data.Products.Where(p => p.ProductVendors.Any(pv => pv.Vendor.Name == vendorName)).ToList();
            
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
