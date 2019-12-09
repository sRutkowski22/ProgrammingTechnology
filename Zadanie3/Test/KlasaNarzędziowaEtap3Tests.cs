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
        [TestMethod()]
        public void GetProductsByNameTest()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            List<Product> zapytanie = KlasaNarzędziowaEtap3.GetProductsByName("Decal");

            List<Product> stala = new List<Product>();
            Product C = (from p in db.Products where p.ProductID == 325 select p).First();
            stala.Add(C);
            C = (from p in db.Products where p.ProductID == 326 select p).First();
            stala.Add(C);

            for (int i = 0; i < zapytanie.Count(); i++)
            {
                if (zapytanie[i].ProductID != stala[i].ProductID) Assert.Fail();
                if (zapytanie[i].Name != stala[i].Name) Assert.Fail();
            }
            if (zapytanie.Count() != stala.Count()) Assert.Fail();
        }

      
    }
}
