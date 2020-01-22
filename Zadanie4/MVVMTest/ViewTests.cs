using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ServiceLayer;
using ViewModel;

namespace MVVMTest
{
    [TestClass]
    public class ViewTests
    {
        [TestMethod]
        public void LocationListTest()
        {
            LocationList location = new LocationList(new DataRepository());
            Assert.IsNotNull(location.Locations[0].Name);
            Assert.IsNotNull(location.Locations[0].Id);
        }
        [TestMethod]
        public void LocationDetailsTest()
        {
            LocationListModel currentLocation = new LocationListModel(1, "Tool Crib");
            LocationDetails location = new LocationDetails(currentLocation, new DataRepository());
            Assert.IsNotNull(location.CurrentLocation.Availability);
            Assert.IsNotNull(location.CurrentLocation.Id);
            Assert.IsNotNull(location.CurrentLocation.Name);
            Assert.IsNotNull(location.CurrentLocation.CostRate);
        }
        [TestMethod]
        public void AddLocationTest()
        {
            AddLocationViewModel location = new AddLocationViewModel(new DataRepository());
            Assert.IsNotNull(location.CurrentLocation.Availability);
            Assert.IsNotNull(location.CurrentLocation.CostRate);
            Assert.IsNotNull(location.CurrentLocation.Id);
            Assert.IsNull(location.CurrentLocation.Name);
        }
        [TestMethod]
        public void CommandTestDelete()
        {
            LocationList location = new LocationList(new DataRepository());
            Assert.IsTrue(location.Delete.CanExecute(null));
        }
        [TestMethod]
        public void CommandTestDisplayAddWindow()
        {
            LocationList location = new LocationList(new DataRepository());
            Assert.IsTrue(location.DisplayAddWindow.CanExecute(null));
        }
        [TestMethod]
        public void CommandTestDisplayDetails()
        {
            LocationList location = new LocationList(new DataRepository());
            Assert.IsTrue(location.DisplayDetails.CanExecute(null));
        }
        [TestMethod]
        public void CommandTestEdit()
        {
            LocationListModel currentLocation = new LocationListModel(1, "Tool Crib");
            LocationDetails location = new LocationDetails(currentLocation,new DataRepository());
            Assert.IsTrue(location.Edit.CanExecute(null));
        }
        [TestMethod]
        public void CommandTestAdd()
        {
            AddLocationViewModel location = new AddLocationViewModel( new DataRepository());
            Assert.IsTrue(location.Add.CanExecute(null));
        }
    }
}
