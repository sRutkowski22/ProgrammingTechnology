using System;
using System.Collections.Generic;

namespace Biblioteka
{
    public class Katalog
    {
        
        internal String opisKsiazki { get; }
        internal AutorKsiazki autorKsiazki { get; }
        internal String tytulKsiazki { get; }
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
    } 
}