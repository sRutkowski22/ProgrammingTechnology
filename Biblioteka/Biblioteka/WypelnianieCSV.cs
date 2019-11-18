using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class WypelnianieCSV : Fill
    {
        public WypelnianieCSV() { }
        public void fillIn(DataContext data)
        {
            string[] lines = System.IO.File.ReadAllLines(@"../../Client.csv");
            foreach (string line in lines) ;
        }
    }
}
