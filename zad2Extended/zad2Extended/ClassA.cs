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
        public float a { get; set; }
        public bool iftrue { get; set; }
        public DateTime data { get; set; }
        public ClassB classB { get; set; }
        public ClassA(String name, float a, bool iftrue, DateTime data, ClassB classB)
        {
            this.a = a;
            this.name = name;
            this.iftrue = iftrue;
            this.data = data;
            this.classB = classB;
        }

        public ClassA()
        {

        }

        public ClassA(SerializationInfo info, StreamingContext ctxt)
        { 
            
            this.name = info.GetString("nazwa");
            this.iftrue = Boolean.Parse(info.GetString("iftrue"));
            this.a = Single.Parse(info.GetString("wartosc"));
            this.classB = null;
            

        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("iftrue", this.iftrue);
            info.AddValue("nazwa", this.name);
            info.AddValue("wartosc", this.a);
            info.AddValue("data", this.data);
            info.AddValue("KlasaB", this.classB);
            
        }

        public override string ToString()
        {
            return "Klasa A";
        }
    }
}
