using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    class DataRepository : IDataRepository
    {

        private DataDataContext context;

        public DataRepository()
        {
            this.context = new DataDataContext();
        }

        public void AddLocation(LocationWrapper locationWrapper)
        {
            Location locationToAdd = locationWrapper.getLocation();
           
                context.Locations.InsertOnSubmit(locationToAdd);
                context.SubmitChanges();

        }

        public void DeleteLocation(int id)
        {    
                context.Locations.DeleteOnSubmit(GetLocation(id));
                context.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }

        public IQueryable<Location> GetAllLocations()
        {
            return context.Locations;
        }

        public Location GetLocation(int id)
        {
            return context.Locations.Where(l => l.LocationID == id).FirstOrDefault();
           
        }

        public void UpdateLocation(int id, LocationWrapper location)
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
        }
    }
}
