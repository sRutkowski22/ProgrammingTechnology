using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IDataRepository
    {
        //C.R.U.D ADD GET ALL GET UPDATE DELETE

        // ADD
        void AddLocation(LocationWrapper locationWrapper);
        // GET ALL
        IEnumerable<LocationWrapper> GetAllLocations();
        // GET 
        LocationWrapper GetLocation(int id);
        // UPDATE
        void UpdateLocation(int id, LocationWrapper location);
        // DELETE
        void DeleteLocation(int id);
     
    }
}
