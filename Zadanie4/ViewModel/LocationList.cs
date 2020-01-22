using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ServiceLayer;
using Model;
using LogicLayer.Interfaces;

namespace ViewModel
{
    public class LocationList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LocationListModel currentLocation { get; set; }
        public Binding Error { get; private set; }
        public Binding Delete { get; private set; }
        public Binding DisplayDetails { get; private set; }
        public Binding DisplayAddWindow { get; private set; }
        public Binding Refresh { get; private set; }
        private IDataRepository dataRepository;
        private ObservableCollection<LocationListModel> locations;

        public IWindowResolver WindowDetailResolver { get; set; }
        public IWindowResolver WindowAddResolver { get; set; }


        public LocationList() : this(new DataRepository())
        {
            
        }

        public LocationList(IDataRepository dataRepository)
        {
            this.dataRepository = new DataRepository();
            Locations = new ObservableCollection<LocationListModel>();
            FillLocations();
            this.Delete = new Binding(DeleteLocation);
            this.DisplayAddWindow = new Binding(ShowAdd);
            this.DisplayDetails = new Binding(ShowDetails);
        }

        public LocationList(IDataRepository dataRepository, Action error)
        {
            this.dataRepository = new DataRepository();
            Locations = new ObservableCollection<LocationListModel>();
            FillLocations();
            this.Delete = new Binding(DeleteLocation);
         
        }

        public ObservableCollection<LocationListModel> Locations
        {
            get => locations;
            set
            {
                locations = value;
                NotifyPropertyChanged("LocationInList");
            }
        }

       

        private void FillLocations()
        {
            IEnumerable<LocationWrapper> listFromService = dataRepository.GetAllLocations();
            foreach(LocationWrapper location in listFromService)
            {
                locations.Add(new LocationListModel(location.LocationID, location.Name));
                
            }
        }
        private void DeleteLocation()
        {
            Locations.Remove(currentLocation);
            dataRepository.DeleteLocation(currentLocation.Id);
        }
        

        private void ShowDetails()
        {
            LocationDetails locationDetails = new LocationDetails(currentLocation, this.dataRepository);
            IOperationWindow window = WindowDetailResolver.GetWindow();
            window.BindViewModel(locationDetails);
            window.Show();
        }
        private void ShowAdd()
        {
            AddLocationViewModel addLocationViewModel = new AddLocationViewModel(this.dataRepository);
            IOperationWindow window = WindowAddResolver.GetWindow();
            window.BindViewModel(addLocationViewModel);
            window.Show();
        }

       

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
        
    }
}
