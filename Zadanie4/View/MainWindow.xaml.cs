using System;
using System.Windows;
using System.Windows.Controls;
using View.DI;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            LocationList mc = (LocationList)DataContext;
            mc.WindowDetailResolver = new LocationDetailsResolver();
            mc.WindowAddResolver = new LocationAddResolver();
        }



        /*   private void OpenDetailsWindow(object sender, RoutedEventArgs e)
            {
                if (this.LocationInList.SelectedItem != null)
                {
                    DetailsWindow details = new DetailsWindow(this.LocationInList.SelectedItem);
                    details.ShowDialog();
                }
            }

            private void OpenAddWindow(object sender, RoutedEventArgs e)
            {
                AddLocationWindow addingWindow = new AddLocationWindow();
                addingWindow.ShowDialog();
            }

            private void Lstdemo_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }*/
    }
}
