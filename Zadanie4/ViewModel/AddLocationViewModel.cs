using ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AddLocationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string locationId { get; set; }
        private readonly IDataRepository dataRepository;
        public string name { get; set; }
        public Binding Add { get; private set; }
        public string costRate { get; set; }
        public string availability { get; set; }

        public AddLocationViewModel(): this(new DataRepository())
        {
            this.Add = new Binding(AddProduct);
        }

        public AddLocationViewModel(IDataRepository dataRepoistory)
        {

        }

        public void AddProduct()
        {
            this.dataRepository.AddLocation(LocationParser.createNewLocationWrapper(locationId, name, costRate, availability));
        }
    }
}
