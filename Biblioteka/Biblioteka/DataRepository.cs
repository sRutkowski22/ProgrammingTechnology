﻿using System;


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
        void UpdateKatalog(DataContext data, Katalog k)
        {
            
        }
        void DeleteKatalog(DataContext data, int key)
        {
            data.dictionaryKatalog.Remove(key);
        }
        void AddWykaz(DataContext data, Wykaz w)
        {
            data.WykazList.Add(w);
        }
        void GetAll(DataContext data)
        {
            foreach(Wykaz w in data.WykazList)
            {
                w.ToString();
            }
        }
        Wykaz GetWykaz(DataContext data, Wykaz w)
        {
            for(int i=0; i < data.WykazList.Count;i++)
            {
                if (data.WykazList.Contains(w))
                {
                    return data.WykazList[i];
                }
            }
        }
    }
}