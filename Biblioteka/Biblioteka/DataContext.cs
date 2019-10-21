using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Biblioteka
{
    public class DataContext
    {
        private List<Wykaz> wykazList = new List<Wykaz>();
        public Dictionary<int, Katalog> dictionaryKatalog;
        public ObservableCollection<Zdarzenie> zdarzenieObservableCollection;
        public List<OpisStanu> opisStanuList;
    
        internal List<Wykaz> WykazList { get => wykazList; set => wykazList = value; }

        DataContext(List<Wykaz> wykazList, Dictionary<int, Katalog> dictionaryKatalog, ObservableCollection<Zdarzenie> zdarzenieObservableCollection, List<OpisStanu> opisStanuList)
        {
            this.wykazList = wykazList;
            this.dictionaryKatalog = dictionaryKatalog;
            this.zdarzenieObservableCollection = zdarzenieObservableCollection;
            this.opisStanuList = opisStanuList;
        }

    }
}