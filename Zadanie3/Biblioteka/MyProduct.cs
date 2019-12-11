using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class MyProduct : Product
    {
        public string SubCategoryName { get; set; }
        public MyProduct(Product product, string name)
        {
            foreach (PropertyInfo property in product.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(this, property.GetValue(product));
                }
            }
            this.SubCategoryName = name;
        }
    }
}
