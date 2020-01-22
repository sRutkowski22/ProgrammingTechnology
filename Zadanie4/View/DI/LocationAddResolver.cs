using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.DI
{
    class LocationAddResolver : IWindowResolver
    {
        public IOperationWindow GetWindow()
        {
            return new LocationAddWindow();
        }
    }
}
