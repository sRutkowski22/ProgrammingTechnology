using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class MyProductContext
    {
        public List<MyProduct> Products { get; private set; }

        public MyProductContext()
        {
            DataClasses1DataContext data = new DataClasses1DataContext();
            this.Products = new List<MyProduct>();
            foreach (Product p in data.Products.ToList())
            {
                MyProduct myProduct = new MyProduct(p, "warzywo");
                Products.Add(myProduct);
            }
        }
    }
}
