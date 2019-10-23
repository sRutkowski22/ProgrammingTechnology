using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Biblioteka
{
    public class DataContext
    {
        private List<Client> wykazList = new List<Client>();
        public Dictionary<int, Katalog> dictionaryKatalog;
        public ObservableCollection<Zdarzenie> zdarzenieObservableCollection;
        public List<OpisStanu> opisStanuList;
    
        internal List<Client> WykazList { get => wykazList; set => wykazList = value; }

        DataContext(List<Client> wykazList, Dictionary<int, Katalog> dictionaryKatalog, ObservableCollection<Zdarzenie> zdarzenieObservableCollection, List<OpisStanu> opisStanuList)
        {
            this.wykazList = wykazList;
            this.dictionaryKatalog = dictionaryKatalog;
            this.zdarzenieObservableCollection = zdarzenieObservableCollection;
            this.opisStanuList = opisStanuList;
        }

    }
}