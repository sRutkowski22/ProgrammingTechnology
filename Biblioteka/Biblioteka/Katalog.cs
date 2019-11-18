using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Biblioteka
{
    [Serializable]
    public class Katalog : ISerializable
    {

        public String opisKsiazki { get; set; }
        public AutorKsiazki autorKsiazki { get; set; }
        public String tytulKsiazki { get; set; }
        public Katalog() { }
        public Katalog(  String tytulKsiazki, AutorKsiazki nautorKsiazki, String nopisKsiazki)
        {        
            opisKsiazki = nopisKsiazki;
            autorKsiazki = nautorKsiazki;
            this.tytulKsiazki = tytulKsiazki;
        }

        public override bool Equals(object obj)
        {
            var katalog = obj as Katalog;
            return katalog != null &&
                   opisKsiazki == katalog.opisKsiazki &&
                   autorKsiazki.Equals(katalog.autorKsiazki) &&
                   tytulKsiazki == katalog.tytulKsiazki;
        }

        public override int GetHashCode()
        {
            var hashCode = 461424465;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(opisKsiazki);
            hashCode = hashCode * -1521134295 + autorKsiazki.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(tytulKsiazki);
            return hashCode;
        }

        public override string ToString()
        {
            return opisKsiazki;
        }

        private Katalog(SerializationInfo info, StreamingContext ctxt)
        {
            this.opisKsiazki = info.GetString("opisKsiazki");
            this.autorKsiazki = new AutorKsiazki(info.GetString("imie"), info.GetString("nazwisko"));
            this.tytulKsiazki = info.GetString("tytulKsiazki");
          
        }

      
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("opisKsiazki", this.opisKsiazki);
          
            info.AddValue("imie", this.autorKsiazki.imie);
            info.AddValue("nazwisko", this.autorKsiazki.nazwisko);
            info.AddValue("tytulKsiazki", this.tytulKsiazki);


        }
    } 
}