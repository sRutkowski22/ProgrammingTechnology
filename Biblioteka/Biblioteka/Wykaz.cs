using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Wykaz
    {
        //Imie i nazwisko czytelnika
        private int ID { get; }
        private String imie { get; }
        private String nazwisko { get; }
        public Wykaz(int ID, String imie, String nazwisko)
        {
            this.ID = ID;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}   
