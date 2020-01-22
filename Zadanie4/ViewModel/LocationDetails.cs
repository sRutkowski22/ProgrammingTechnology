using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;
using ServiceLayer;
namespace ViewModel
{
    public class LocationDetails : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        private IDataRepository dataRepository;
        public LocationListDetailModel currentLocation { get; set; }

        public LocationDetails() : this(null,new DataRepository())
        {

        }
       

        public LocationDetails(Object selectedItem) : this(selectedItem, new DataRepository()) { }
        public LocationDetails(Object selectedItem, IDataRepository productService)
        {
            dataRepository = productService;
            if (selectedItem != null)
            {
                LocationListModel item = (LocationListModel)selectedItem;
                int locationID = item.Id;
                LocationWrapper location = dataRepository.GetLocation(locationID);
                currentLocation = new LocationListDetailModel(location.LocationID, location.Name, location.CostRate, location.Availability, location.ModifiedDate);
            }
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

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
