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
        public int ClientId { get => clientId; set => clientId = value; }
        public int clientId { get; set; }
        public String imie { get; set; }
        public String nazwisko { get; set; }
        public Client() { }
        public Client(int clientId, String imie, String nazwisko)
        {
            this.ClientId = clientId;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public override bool Equals(object obj)
        {
            var client = obj as Client;
            return client != null &&
                   ClientId == client.ClientId &&
                   imie == client.imie &&
                   nazwisko == client.nazwisko;
        }
    }
}   
