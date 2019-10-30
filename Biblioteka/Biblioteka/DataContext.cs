using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Biblioteka
{
    public class DataContext
    {

        public List<String> eventChangeList;
        public List<Client> clientList;
        public Dictionary<int, Katalog> dictionaryKatalog;
        public ObservableCollection<Zdarzenie> zdarzenieObservableCollection;
        public List<OpisStanu> opisStanuList;

        public DataContext()
        {
            this.clientList = new List<Client>();
            this.dictionaryKatalog = new Dictionary<int, Katalog>();
            this.zdarzenieObservableCollection = new ObservableCollection<Zdarzenie>();
            this.opisStanuList = new List<OpisStanu>();
            this.eventChangeList = new List<string>();

          
        }

        //  internal List<Client> WykazList { get => wykazList; set => wykazList = value; }

        DataContext(List<Client> wykazList, Dictionary<int, Katalog> dictionaryKatalog, ObservableCollection<Zdarzenie> zdarzenieObservableCollection, List<OpisStanu> opisStanuList)
        {
            this.clientList = wykazList;
            this.dictionaryKatalog = dictionaryKatalog;
            this.zdarzenieObservableCollection = zdarzenieObservableCollection;
            this.opisStanuList = opisStanuList;
            this.eventChangeList = new List<string>();
        }

       

    }
}