using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LogicLayer.Interfaces;
using Model;
using ServiceLayer;
namespace ViewModel
{
    public class LocationDetails : INotifyPropertyChanged,  IViewModel
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        private IDataRepository dataRepository;
        public LocationListDetailModel currentLocation { get; set; }
        public Binding Edit { get; private set; }
        public Action CloseWindow { get; set; }



          public LocationDetails() : this(null,new DataRepository())
          {

          }


        public LocationDetails(Object selectedItem) : this(selectedItem, new DataRepository()) { }
        public LocationDetails(Object selectedItem, IDataRepository productService)
        {
            dataRepository = productService;
            if (selectedItem != null)
            {
                this.Edit = new Binding(EditLocation);
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

       

        public void EditLocation()
        {
           
            this.dataRepository.UpdateLocation(currentLocation.Id, LocationParser.createNewLocationWrapper(currentLocation.Id, currentLocation.Name, currentLocation.CostRate, currentLocation.Availability));
              
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
