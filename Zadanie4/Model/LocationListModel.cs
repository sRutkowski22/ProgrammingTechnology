using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LocationListModel : INotifyPropertyChanged
    {
        private short id;
        private string name;

        public LocationListModel(short id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public short Id
        {
            get { return id; }
            set
            {
                id = value;
            
                NotifyPropertyChanged("Id");
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
                NotifyPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

       
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
