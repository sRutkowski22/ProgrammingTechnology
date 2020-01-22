using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        

        public DetailsWindow()
        {
            InitializeComponent();
        }

      

        /* public DetailsWindow(object selectedItem)
         {
             InitializeComponent();
             this.DataContext = new LocationDetails(selectedItem);
         }*/
    }
}
