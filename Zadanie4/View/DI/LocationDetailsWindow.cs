using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.DI
{
    class LocationDetailsWindow : IOperationWindow
    {
        private DetailsWindow view;
        public event VoidHandler OnClose;

        public LocationDetailsWindow()
        {
            view = new DetailsWindow();
        }

        public void BindViewModel<T>(T viewModel) where T : IViewModel
        {
            view.DataContext = viewModel;
            viewModel.CloseWindow = () =>
            {
                OnClose?.Invoke();
                view.Close();
            };
        }

        public void Show()
        {
            view.Show();
        }
    }
}
