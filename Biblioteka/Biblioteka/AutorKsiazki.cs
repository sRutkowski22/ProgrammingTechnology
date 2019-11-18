using System;
using System.Collections.Generic;

namespace Biblioteka
{
    public class AutorKsiazki
    {
        //dane osobowe autora
        public int ID { get; set; }
        public String imie { get; set; }
        public String nazwisko { get; set; }
        public AutorKsiazki() { }
        public AutorKsiazki( String imie, String nazwisko)
        {  
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public override bool Equals(object obj)
        {
            var ksiazki = obj as AutorKsiazki;
            return ksiazki != null &&
                   imie == ksiazki.imie &&
                   nazwisko == ksiazki.nazwisko;
        }

        public override int GetHashCode()
        {
            var hashCode = -1469940998;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(imie);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nazwisko);
            return hashCode;
        }
    }
}