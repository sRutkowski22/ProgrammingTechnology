using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    interface IDataRepository
    {
        //C.R.U.D ADD GET ALL GET UPDATE DELETE

        // ADD
        void AddLocation();
        // GET ALL
        IQueryable<Location> GetAllLocations();
        // GET 
        Location GetLocation(int id);
        // UPDATE
        void UpdateLocation(int id);
        // DELETE
        void DeleteLocation(int id);
     
    }
}
