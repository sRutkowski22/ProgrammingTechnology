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
        private int id;
        private string name;

        public LocationListModel(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
