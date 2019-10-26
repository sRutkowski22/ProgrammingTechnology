using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class WypelnianieZPliku : Fill
    {
        public WypelnianieZPliku() { }
        public void fillIn(DataContext data)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Client.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                data.wykazList.Add(new Client(Int32.Parse(words[0]), words[1], words[2]));

            }
            lines = System.IO.File.ReadAllLines(@"Katalog.txt");
            int i = 0;
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                data.dictionaryKatalog.Add(i, new Katalog(Int32.Parse(words[0]), words[1], new AutorKsiazki(words[2], words[3]), words[4]));
                i++;
            }

            lines = System.IO.File.ReadAllLines(@"OpisStanu.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');

                foreach (Katalog k in data.dictionaryKatalog.Values)
                {
                    if (k.katalogId == Int32.Parse(words[0])) data.opisStanuList.Add(new OpisStanu(k.katalogId, k, Int32.Parse(words[1]), UInt32.Parse(words[2])));
                }
            }


            lines = System.IO.File.ReadAllLines(@"Zdarzenie.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');

                Client W = new Client(-1, "", "");
                OpisStanu O = new OpisStanu(1, null, 0, 1);
                foreach (Client ww in data.wykazList)
                {
                    if (ww.clientId == Int32.Parse(words[0]))
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
                if (W.clientId == -1)
                    data.zdarzenieObservableCollection.Add(new Zakup(Int32.Parse(words[2]), O, Int32.Parse(words[3]), DateTime.Parse(words[4])));
            }
        }
    }
}
