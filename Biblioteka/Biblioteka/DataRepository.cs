using System;


namespace Biblioteka
{
    public class DataRepository
    {
        WypelnianieStalymi wypelnienie;
        private DataContext dataContext { get; }
        private Fill fill;
        DataRepository(DataContext ndataContext, Fill fill)
        {
            this.fill = fill;
            wypelnienie.fillIn(dataContext);
        }
      
    }
}