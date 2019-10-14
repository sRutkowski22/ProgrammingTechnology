using System;


namespace Biblioteka
{
    public class DataRepository
    {
        private DataContext dataContext { get; }
        DataRepository(DataContext ndataContext)
        {
            dataContext = ndataContext;
        }
    }
}