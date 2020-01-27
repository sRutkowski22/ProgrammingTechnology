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
            // nazwa propert ktora ulega zmianie
            string actual = null;

            // lista LocationListModel, ktora nie jest z bazy
            ObservableCollection<LocationListModel> locations = new ObservableCollection<LocationListModel>();
            locations.Add(new LocationListModel(1, "testowa lokacja"));
            
            // utworzenie klasy viewModel
            LocationList locationList = new LocationList(locations);
         
          //  object DataContext = locationList;

            // dodanie delegata
            locationList.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                actual = e.PropertyName;
            };

            // zmiana property
            locationList.Locations = null;

            Assert.IsNotNull(actual);
            Assert.AreEqual("Locations", actual);



        }
    }
}
