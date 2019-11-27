using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2Extended
{
    public class DuplicateExecutor
    {
        public static void duplicateDelete(DataContext dataContext)
        {
            deleteKatalogDuplicateFromClassA (dataContext);
            deleteOpisStanuDuplicateFromClassB(dataContext);
            deleteClientDuplicateFromClassC(dataContext);
        }

        private static void deleteKatalogDuplicateFromClassA(DataContext dataContext)
        {
            foreach (ClassA klasaA in dataContext.classAList)
            {
                foreach (ClassB klasaB in dataContext.classBList)
                {
                    if (klasaA.classB.Equals(klasaB))
                    {
                        klasaA.classB = klasaB;
                    }
                }
            }
        }

        private static void deleteOpisStanuDuplicateFromClassB(DataContext dataContext)
        {
            foreach (ClassB klasab in dataContext.classBList)
            {
                foreach (ClassC klasaC in dataContext.classCList)
                {
                    if (klasab.classC.Equals(klasaC))
                    {
                        klasab.classC=klasaC;
                    }
                }
            }
        }

        private static void deleteClientDuplicateFromClassC(DataContext dataContext)
        {
            foreach (ClassC klasaC in dataContext.classCList)
            {
                foreach (ClassA klasaA in dataContext.classAList)
                {
                    if (klasaC.classA.Equals(klasaA))
                    {
                        klasaC.classA=klasaA;
                    }
                }
            }
        }
    }
}