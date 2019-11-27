using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace zad2Extended
{
    public class ClassC : ISerializable
    {
        public String name { get; set; }
        public int a { get; set; }
        public bool iftrue { get; set; }
        public ClassA classA { get; set; }
        public ClassC(String name, int a, bool iftrue, ClassA classA)
        {
            this.a = a;
            this.name = name;
            this.iftrue = iftrue;
            this.classA = classA;
        }

        public ClassC()
        {
        }
        public ClassC(SerializationInfo info, StreamingContext ctxt)
        {

            this.name = info.GetString("nazwa");
            this.iftrue = Boolean.Parse(info.GetString("iftrue"));
            this.a = Int32.Parse(info.GetString("wartosc"));
            this.classA = null;

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("iftrue", this.iftrue);
            info.AddValue("nazwa", this.name);
            info.AddValue("wartosc", this.a);
            info.AddValue("KlasaA", this.classA);
           
        }
        public override string ToString()
        {
            return "Klasa C";
        }
    }
}
