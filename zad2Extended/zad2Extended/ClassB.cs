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
        public float a { get; set; }
        public bool iftrue { get; set; }
        public ClassC classC { get; set; }
        public DateTime data { get; set; }
        public ClassB(String name, float a, bool iftrue,DateTime data, ClassC classC)
        {
            this.a = a;
            this.name = name;
            this.iftrue = iftrue;
            this.data = data;
            this.classC = classC;
        }
        public ClassB()
        {

        }
        public ClassB(SerializationInfo info, StreamingContext ctxt)
        {

            this.name = info.GetString("nazwa");
            this.iftrue = Boolean.Parse(info.GetString("iftrue"));
            this.a = Single.Parse(info.GetString("wartosc"));
            this.classC = null;
            

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("iftrue", this.iftrue);
            info.AddValue("nazwa", this.name);
            info.AddValue("wartosc", this.a);
            info.AddValue("data", this.data);
            info.AddValue("KlasaC", this.classC);
            

        }
        public override string ToString()
        {
            return "Klasa B";
        }
    }
}
