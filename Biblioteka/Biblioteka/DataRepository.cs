using System;


namespace Biblioteka
{
    public class DataRepository//TODO: tutaj doda ten interfejs ': IDataRepository'
    {
        WypelnianieStalymi wypelnienie;
        private DataContext dataContext { get; }
        private Fill fill;
        DataRepository(DataContext dataContext, Fill fill)
        {
            this.fill = fill;
            this.dataContext = dataContext;
            //fill.fillIn(dataContext);
            //wypelnienie.fillIn(dataContext);
        }
        public void FillStatic() => fill.fillIn(dataContext);
      //C.R.U.D ADD GET ALL GET UPDATE DELETE
      void AddKatalog(Katalog k, DataContext data)
        {
            data.dictionaryKatalog.Add((data.dictionaryKatalog.Count + 1),k);
        }
      void GetKatalog(Katalog k, DataContext data)
        {
            for(int i=0; i<data.dictionaryKatalog.Count; i++)
            {
                if (data.dictionaryKatalog.ContainsValue(k))
                {
                    //TODO: do zrobienia wypisywanie
                    Console.WriteLine(data.dictionaryKatalog);
                }
            }
        }
        void GetAllKatalog(DataContext data)
        {
            for (int i = 0; i < data.dictionaryKatalog.Count; i++)
            {
                Console.WriteLine(data.dictionaryKatalog.ToString());
            }
        }
        void UpdateKatalog(int ID, Katalog k)
        {
            if (dataContext.dictionaryKatalog.ContainsKey(ID))
            {
                dataContext.dictionaryKatalog[ID] = k;
            }
                      
        }
        void DeleteKatalog(DataContext data, int key)
        {
            data.dictionaryKatalog.Remove(key);
        }
        void AddWykaz(DataContext data, Client w)
        {
            data.WykazList.Add(w);
        }
        void GetAll(DataContext data)
        {
            foreach(Client w in data.WykazList)
            {
                w.ToString();
            }
        }

        private Client GetWykaz(DataContext data, Client w)
        {
            for(int i=0; i < data.WykazList.Count;i++)
            {
                if (data.WykazList.Contains(w))
                {
                    return data.WykazList[i];
                }
                
            }
            return null;
        }
    }
}