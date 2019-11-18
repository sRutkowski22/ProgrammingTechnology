using System;
using System.Globalization;
using Biblioteka;
namespace UnitTestProject1
{
    public class WypelnianieZPliku : Fill
    {
        public WypelnianieZPliku() { }
        public void fillIn(DataContext data)
        {
            string[] lines = System.IO.File.ReadAllLines(@"../../Client.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                data.clientList.Add(new Client(Int32.Parse(words[0]), words[1], words[2]));

            }
            lines = System.IO.File.ReadAllLines(@"../../Katalog.txt");
           
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                int id = data.dictionaryKatalog.Count+1;
                data.dictionaryKatalog.Add(id, new Katalog( words[1], new AutorKsiazki(words[2], words[3]), words[4]));
              
            }

            lines = System.IO.File.ReadAllLines(@"../../OpisStanu.txt");
            int i = 0;
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                
                foreach (Katalog k in data.dictionaryKatalog.Values)
                {
                    if (data.dictionaryKatalog.ContainsKey(Int32.Parse(words[0])))
                    {
                        data.opisStanuList.Add(new OpisStanu(i, k, Int32.Parse(words[1]), UInt32.Parse(words[2])));
                        i++;
                    }
                }
            }


            lines = System.IO.File.ReadAllLines(@"../../Zdarzenie.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');

                Client W = new Client(-1, "", "");
                OpisStanu O = new OpisStanu(1, null, 0, 1);
                foreach (Client ww in data.clientList)
                {
                    if (ww.ClientId == Int32.Parse(words[0]))
                    {
                        W = ww;
                        break;
                    }
                }
                foreach (OpisStanu oo in data.opisStanuList)
                {
                    if (oo.opisuStanuId == Int32.Parse(words[1]))
                    {
                        O = oo;
                        break;
                    }
                }
                if (W.ClientId == -1)
                    data.zdarzenieObservableCollection.Add(new Zakup(Int32.Parse(words[2]), O, Int32.Parse(words[3]), uint.Parse(words[4]), DateTime.ParseExact(words[5],"yyyy.MM.dd", CultureInfo.CurrentCulture)));
                else
                    data.zdarzenieObservableCollection.Add(new Sprzedaz(Int32.Parse(words[2]), O,Int32.Parse(words[3]), uint.Parse(words[4]), W, DateTime.ParseExact(words[5], "yyyy.MM.dd", CultureInfo.CurrentCulture)));
            }
        }
    }
}
