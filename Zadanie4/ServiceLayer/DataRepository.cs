using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DataRepository : IDataRepository
    {

        private DataDataContext context;

        public DataRepository()
        {
            this.context = new DataDataContext();
        }

        public void AddLocation(LocationWrapper locationWrapper)
        {
            Location locationToAdd = locationWrapper.getLocation();
            Task.Run(() =>
            {
                context.Locations.InsertOnSubmit(locationToAdd);
                context.SubmitChanges();
            });

        }

        public void DeleteLocation(int id)
        {
            Task.Run(() =>
            {
                context.Locations.DeleteOnSubmit(GetLocation(id).getLocation());
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            });
        }

        public IEnumerable<LocationWrapper> GetAllLocations()
        {
            
            List<LocationWrapper> list = new List<LocationWrapper>();
            IQueryable<Location> locations = context.Locations;
            foreach(Location location in locations)
            {
                list.Add(new LocationWrapper(location));
            }
            return list;
        }

        public LocationWrapper GetLocation(int id)
        {
            Location location = context.Locations.Where(l => l.LocationID == id).FirstOrDefault();
            return new LocationWrapper(location);


        }

        public void UpdateLocation(int id, LocationWrapper location)
        {
            Task.Run(() =>
            {
                Location updatedLocation = context.Locations.Where(p => p.LocationID == location.LocationID).FirstOrDefault();
            foreach (System.Reflection.PropertyInfo property in updatedLocation.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(updatedLocation, property.GetValue(location.getLocation()));
                }
            }
            context.SubmitChanges();
            });
        }
    }
}
