using System;
using System.Runtime.Serialization;
using System.Globalization;

namespace Biblioteka
{
    public class Zakup : Zdarzenie
    {
       

        public DateTime dataZakupu { get; }
        public Zakup(int zdarzeniaId, OpisStanu opisStanu, int ilosc,uint cena, DateTime dataZakupu) : base(zdarzeniaId, opisStanu, ilosc,cena)
        {
            this.dataZakupu = dataZakupu;
        }
        public Zakup(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
        {
            this.dataZakupu =  DateTime.ParseExact(info.GetString("dataZakupu"), "yyyy.MM.dd", CultureInfo.CurrentCulture);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            base.GetObjectData(info, ctxt);
            info.AddValue("dataZakupu", this.dataZakupu.ToString("yyyy.MM.dd"));

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
