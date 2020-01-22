using ServiceLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Model;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class AddLocationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LocationListDetailModel currentLocation { get; set; }
        private readonly IDataRepository dataRepository;
       
        public Binding Add { get; private set; }
       

        public AddLocationViewModel(): this(new DataRepository())
        {
          
        }

        public AddLocationViewModel(IDataRepository dataRepoistory)
        {
            this.Add = new Binding(AddLocation);
            currentLocation = new LocationListDetailModel();
            this.dataRepository = dataRepoistory;
        }
        public LocationListDetailModel CurrentLocation
        {
            get => currentLocation;
            set
            {
                currentLocation = value;
                NotifyPropertyChanged("LocationInList");
            }
        }

        public void AddLocation()
        {
            LocationWrapper locationWrapper = LocationParser.createNewLocationWrapper(currentLocation.Id, currentLocation.Name, currentLocation.CostRate, currentLocation.Availability);
            this.dataRepository.AddLocation(locationWrapper);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
