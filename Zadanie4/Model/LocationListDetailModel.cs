using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LocationListDetailModel
    {
        
        private short id;
        private string name;
        private decimal costRate;
        private decimal availability;
        private DateTime modifiedDate;

        public LocationListDetailModel() { }

        public LocationListDetailModel(short locationId, string name, decimal costRate, decimal availability, DateTime modifiedDate)
        {
            this.id = locationId;
            this.name = name;
            this.costRate = costRate;
            this.availability = availability;
            this.modifiedDate = modifiedDate;
        }
        public short Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public decimal CostRate
        {
            get
            {
                return costRate;
            }
            set
            {
                costRate = value;
                OnPropertyChanged("CostRate");
            }
        }
        public decimal Availability
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
                OnPropertyChanged("Availability");
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return modifiedDate;
            }
            set
            {
                modifiedDate = value;
                OnPropertyChanged("ModifiedDate");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
