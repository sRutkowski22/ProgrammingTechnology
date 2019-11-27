using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace zad2Extended
{
    public class DataContext
    {

        public List<ClassA> classAList;
        public List<ClassB> classBList;
        public List<ClassC> classCList;

        public DataContext()
        {
            this.classAList = new List<ClassA>();
            this.classBList = new List<ClassB>();
            this.classCList = new List<ClassC>();


        }

       

        DataContext(List<ClassA> classAList, List<ClassB> classBList, List<ClassC> classCList)
        {
            this.classAList = classAList;
            this.classBList = classBList;
            this.classCList = classCList;
            
        }



    }
}