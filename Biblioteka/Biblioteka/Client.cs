using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class Client
    {
        //Imie i nazwisko czytelnika
        internal int clientId { get; }
        internal String imie { get; }
        internal String nazwisko { get; }
        public Client(int clientId, String imie, String nazwisko)
        {
            this.clientId = clientId;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}   
