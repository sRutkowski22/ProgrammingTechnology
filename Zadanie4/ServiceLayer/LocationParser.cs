using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class LocationParser
    {
        public static LocationWrapper createNewLocationWrapper(string id, string name, string costRate, string availability)
        {
            Location addedLocation = new Location();
            addedLocation.LocationID = short.Parse(id);
            addedLocation.Name = name;
            addedLocation.Availability = decimal.Parse(availability);
            addedLocation.CostRate = decimal.Parse(costRate);
            addedLocation.ModifiedDate = DateTime.Now;

            return new LocationWrapper(addedLocation);
        }

        public static LocationWrapper createNewLocationWrapper(short id, string name, decimal costRate, decimal availability)
        {
            Location addedLocation = new Location();
            addedLocation.LocationID =id;
            addedLocation.Name = name;
            addedLocation.Availability = availability;
            addedLocation.CostRate = costRate;
            addedLocation.ModifiedDate = DateTime.Now;

            return new LocationWrapper(addedLocation);
        }
    }
}
