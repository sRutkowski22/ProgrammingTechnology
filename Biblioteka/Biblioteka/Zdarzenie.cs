using System;
using System.Runtime.Serialization;

namespace Biblioteka
{
    [Serializable]
    public abstract class Zdarzenie : ISerializable
    {
        public int zdarzeniaId { get; set; }
        public OpisStanu opisStanu { get; set; } // id stanu ksiazki (konkretna ksiazka)
        public int ilosc { get; set; }
        public uint cena { get; set; }
      
        public Zdarzenie() { }
        public Zdarzenie(int zdarzeniaId, OpisStanu opisStanu, int ilosc,uint cena)
        {
            this.zdarzeniaId = zdarzeniaId;
            this.cena = cena;
            this.opisStanu = opisStanu;
            this.ilosc = ilosc;
    
        }

       public Zdarzenie(SerializationInfo info, StreamingContext ctxt)
        {
            this.zdarzeniaId = Int32.Parse(info.GetString("zdarzeniaId"));
            this.ilosc = Int32.Parse(info.GetString("ilosc"));
            this.cena = UInt32.Parse(info.GetString("cenaZdarzenia"));
            this.opisStanu = new OpisStanu(info, ctxt);
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("zdarzeniaId", this.zdarzeniaId);
            info.AddValue("ilosc", this.ilosc);
            info.AddValue("cenaZdarzenia", this.cena);

            info.AddValue("opisuStanuId", this.opisStanu.opisuStanuId);
            info.AddValue("iloscEgzemplarzy", this.opisStanu.iloscEgzemplarzy);
            info.AddValue("cena", this.opisStanu.cena);
            
            info.AddValue("imie", this.opisStanu.katalog.autorKsiazki.imie);
            info.AddValue("nazwisko", this.opisStanu.katalog.autorKsiazki.nazwisko);
            info.AddValue("tytulKsiazki", this.opisStanu.katalog.tytulKsiazki);
        }


        public abstract Client GetClient();
        public abstract DateTime GetDateZdarzenia(); 
        public abstract int GetIlosc();

        //public abstract bool Equals(object obj);
       

        public override int GetHashCode()
        {
            var hashCode = -937264338;
            hashCode = hashCode * -1521134295 + zdarzeniaId.GetHashCode();
            hashCode = hashCode * -1521134295 + opisStanu.GetHashCode();
            hashCode = hashCode * -1521134295 + ilosc.GetHashCode();
            hashCode = hashCode * -1521134295 + cena.GetHashCode();
            return hashCode;
        }
    }
}