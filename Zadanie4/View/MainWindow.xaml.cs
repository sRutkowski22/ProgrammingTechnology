using System.Windows;
using System.Windows.Controls;

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

        
       private void OpenDetailsWindow(object sender, RoutedEventArgs e)
        {
            if (this.lstdemo.SelectedItem != null)
            {
                DetailsWindow details = new DetailsWindow(this.lstdemo.SelectedItem);
                details.ShowDialog();
            }
        }

        private void Lstdemo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
