using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace zad2Extended
{
    public class ClassB : ISerializable
    {
        public String name { get; set; }
        public int a { get; set; }
        public bool iftrue { get; set; }
        public ClassC classC { get; set; }
        public ClassB(String name, int a, bool iftrue,ClassC classC)
        {
            this.a = a;
            this.name = name;
            this.iftrue = iftrue;
            this.classC = classC;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("iftrue", this.iftrue);
            info.AddValue("nazwa", this.name);
            info.AddValue("KlasaC", this.classC);
            info.AddValue("wartosc a", this.a);
        }
    }
}
