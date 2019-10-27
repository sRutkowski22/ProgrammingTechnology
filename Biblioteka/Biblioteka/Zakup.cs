﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class Zakup : Zdarzenie
    {
        internal DateTime dataZakupu;
        public Zakup(int zdarzeniaId, OpisStanu opisStanu, int ilosc,uint cena, DateTime dataZakupu) : base(zdarzeniaId, opisStanu, ilosc,cena)
        {
            this.dataZakupu = dataZakupu;
        }
        public override Client GetClient()
        {
            return null;
        }

        public override DateTime GetDateZdarzenia()
        {
            return dataZakupu;
        }

        public override int GetIlosc()
        {
            return ilosc;
        }
    }
}
