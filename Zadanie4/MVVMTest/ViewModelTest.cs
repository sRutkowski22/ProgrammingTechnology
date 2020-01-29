using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ViewModel;

namespace MVVMTest
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void TestChangeOfView()
        {
           
            string actual = null;

          
            ObservableCollection<LocationListModel> locations = new ObservableCollection<LocationListModel>();
            locations.Add(new LocationListModel(1, "testowa lokacja"));
            
           
            LocationList locationList = new LocationList(locations);
         
        

          
            locationList.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                actual = e.PropertyName;
            };

            Assert.IsNull(actual);

           
            locationList.Locations = null;

            Assert.IsNotNull(actual);
            Assert.AreEqual("Locations", actual);



        }
    }
}
