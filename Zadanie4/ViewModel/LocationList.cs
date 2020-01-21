using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ServiceLayer;
using Model;

namespace ViewModel
{
    public class LocationList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IDataRepository dataRepository;
        private ObservableCollection<LocationListModel> locations;

        public LocationList() : this(new DataRepository())
        {

        }

        public LocationList(IDataRepository dataRepository)
        {
            this.dataRepository = new DataRepository();
            Locations = new ObservableCollection<LocationListModel>();
            FillLocations();
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

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
