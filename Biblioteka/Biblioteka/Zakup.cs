using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Zakup : Zdarzenie
    {
       

        public DateTime dataZakupu { get; }
        public Zakup(int zdarzeniaId, OpisStanu opisStanu, int ilosc,uint cena, DateTime dataZakupu) : base(zdarzeniaId, opisStanu, ilosc,cena)
        {
            this.dataZakupu = dataZakupu;
        }

      

        public override bool Equals(object obj)
        {
            var zakup = obj as Zakup;
            return zakup != null &&
                   dataZakupu == zakup.dataZakupu;
        }

        public override Client GetClient()
        {
            return new Client(-1, "-", "-");
        }

        public override DateTime GetDateZdarzenia()
        {
            return dataZakupu;
        }

        public override int GetIlosc()
        {
            return ilosc;
        }

       

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
