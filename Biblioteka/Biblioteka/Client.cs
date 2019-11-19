using System;
using System.Runtime.Serialization;

namespace Biblioteka
{
    [Serializable]
    public class Client : ISerializable
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

        public Client(SerializationInfo info, StreamingContext ctxt)
        {
            this.clientId = Int32.Parse(info.GetString("clientId"));
            this.imie = info.GetString("imieClienta");
            this.nazwisko = info.GetString("nazwiskoClienta");

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("clientId", this.clientId);
            info.AddValue("imieClienta", this.imie);
            info.AddValue("nazwiskoClienta", this.nazwisko);
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
