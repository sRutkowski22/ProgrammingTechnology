using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace zad2Extended
{
    public class ClassA : ISerializable
    {
        public String name { get; set; }
        public int a { get; set; }
        public bool iftrue { get; set; }
        public ClassB classB { get; set; }
        public ClassA(String name, int a, bool iftrue,ClassB classB)
        {
            this.a = a;
            this.name = name;
            this.iftrue = iftrue;
            this.classB = classB;
        }

        public ClassA()
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("iftrue", this.iftrue);
            info.AddValue("nazwa", this.name);
            info.AddValue("wartosc", this.a);
            info.AddValue("KlasaB", this.classB);
           
        }
    }
}
