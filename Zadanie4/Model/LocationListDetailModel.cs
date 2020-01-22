using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class LocationListDetailModel
    {
        
        private int id;
        private string name;
        private decimal costRate;
        private decimal availability;
        private DateTime modifiedDate;

        public LocationListDetailModel(int locationId, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            this.id = locationId;
            this.name = name;
            this.costRate = costRate;
            this.availability = availability;
            this.modifiedDate = modifiedDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
