using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Biblioteka
{
    public class DataContext
    {

        public List<Client> wykazList;
        public Dictionary<int, Katalog> dictionaryKatalog;
        public ObservableCollection<Zdarzenie> zdarzenieObservableCollection;
        public List<OpisStanu> opisStanuList;
       
        public DataContext()
        {
            this.wykazList = new List<Client>();
            this.dictionaryKatalog = new Dictionary<int, Katalog>();
            this.zdarzenieObservableCollection = new ObservableCollection<Zdarzenie>();
            this.opisStanuList = new List<OpisStanu>();
    }

        //  internal List<Client> WykazList { get => wykazList; set => wykazList = value; }

        DataContext(List<Client> wykazList, Dictionary<int, Katalog> dictionaryKatalog, ObservableCollection<Zdarzenie> zdarzenieObservableCollection, List<OpisStanu> opisStanuList)
        {
            this.wykazList = wykazList;
            this.dictionaryKatalog = dictionaryKatalog;
            this.zdarzenieObservableCollection = zdarzenieObservableCollection;
            this.opisStanuList = opisStanuList;
        }

    }
}