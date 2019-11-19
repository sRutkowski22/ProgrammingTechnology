using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Biblioteka
{
    [Serializable]
    public class OpisStanu : ISerializable
    {
        public int opisuStanuId { get; set; }
        public Katalog katalog { get; set; }
        public int iloscEgzemplarzy { get; set; }
        public uint cena { get; set; }
        public OpisStanu() { }
       // public int OpisStanuID { get => this.opisuStanuId; set => this.opisuStanuId; }
        public OpisStanu(int opisuStanuId, Katalog katalog, int iloscEgzemplarzy, uint cena)
        {
            this.opisuStanuId = opisuStanuId;
            this.katalog = katalog;
            this.iloscEgzemplarzy = iloscEgzemplarzy;
            this.cena = cena;
        }

        public OpisStanu(SerializationInfo info, StreamingContext ctxt)
        {
            this.opisuStanuId = Int32.Parse(info.GetString("opisuStanuId"));
            this.iloscEgzemplarzy = Int32.Parse(info.GetString("iloscEgzemplarzy"));
            this.cena = UInt32.Parse(info.GetString("cena"));
            this.katalog = new Katalog(info.GetString("tytulKsiazki"), new AutorKsiazki(info.GetString("imie"), info.GetString("nazwisko")), info.GetString("tytulKsiazki"));
          

        }


        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("opisuStanuId", this.opisuStanuId);
            info.AddValue("iloscEgzemplarzy", this.iloscEgzemplarzy);
            info.AddValue("cena", this.cena);
            info.AddValue("opisKsiazki", this.katalog.opisKsiazki);
            info.AddValue("imie", this.katalog.autorKsiazki.imie);
            info.AddValue("nazwisko", this.katalog.autorKsiazki.nazwisko);
            info.AddValue("tytulKsiazki", this.katalog.tytulKsiazki);
        }

        public override bool Equals(object obj)
        {
            var stanu = obj as OpisStanu;
            return stanu != null &&
                   opisuStanuId == stanu.opisuStanuId &&
                   katalog.Equals(stanu.katalog) &&
                   iloscEgzemplarzy == stanu.iloscEgzemplarzy &&
                   cena == stanu.cena;
        }

        public override int GetHashCode()
        {
            var hashCode = 1663023772;
            hashCode = hashCode * -1521134295 + opisuStanuId.GetHashCode();
            hashCode = hashCode * -1521134295 + katalog.GetHashCode();
            hashCode = hashCode * -1521134295 + iloscEgzemplarzy.GetHashCode();
            hashCode = hashCode * -1521134295 + cena.GetHashCode();
            return hashCode;
        }
    }
}
