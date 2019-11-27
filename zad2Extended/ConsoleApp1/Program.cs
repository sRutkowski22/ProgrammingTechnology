using System;
using zad2Extended;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataContext data = new DataContext();
            DataContext data2 = new DataContext();

            ClassA ca1 = new ClassA("klasaAnazwa", 5, true, null);
            ClassB cb1 = new ClassB("klasaBnazwa", 6, true, null);
            ClassC cc1 = new ClassC("klasaCnazwa", 7, false, ca1);
            ca1.classB = cb1;
            cb1.classC = cc1;

           
         
          

            //serializacja
            String filename = "serialize.csv";
            File.WriteAllText(filename, string.Empty);
           
            FormatterCSV fromatterCSV = new FormatterCSV();
            fromatterCSV.Binder = new KnownTypesBinder();
            fromatterCSV.objectIDGenerator = new ObjectIDGenerator();
   
            fromatterCSV.Serialize(ca1);


            //deserializacja
            fromatterCSV.Binder = new KnownTypesBinder();
            fromatterCSV.objectIDGenerator = new ObjectIDGenerator();

            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            Dictionary<long, object> list = (Dictionary<long, object>) fromatterCSV.Deserialize(stream);

            foreach(object ob in list.Values)
            {
                Console.WriteLine(ob.ToString());
            }
            Console.Read();



            /*   fromatterCSV.Serialize(stream, cb1);
               stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
               fromatterCSV.Serialize(stream, cc1);
               stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
               fromatterCSV.Serialize(stream, ca1);*/



            /*   data.classAList.Add(ca1);
               data.classBList.Add(cb1);
               data.classCList.Add(cc1);
               ZapisCSV zapisCSV = new ZapisCSV(data);
               WczytanieCSV wczytanieCSV = new WczytanieCSV(data2);
               int m;
               String str;

           Start:
               Console.WriteLine("Wybierz co chcesz zrobic?\n" +
                   "1. Zapis CSV\n" +
                   "2. Odczyt CSV\n");

               str = Console.ReadLine();
               m = int.Parse(str);
               switch (m)
               {
                   case 1:
                       zapisCSV.Save();
                       Console.WriteLine("jestes w zapisie");
                       break;

                   case 2:
                       wczytanieCSV.Read();
                       Console.WriteLine("Odczytano z csv");

                       Console.Read();
                       break;


                   case 3:
                      // wypiszWszystko(repo2);
                       break;
                   case 0:
                       Environment.Exit(0);
                       break;
                   default:
                       Console.WriteLine("Nic nie wybrales");
                       goto Start;

               }
               goto Start;
           }*/



        }

    }
}

