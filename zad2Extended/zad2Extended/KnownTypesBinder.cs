using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace zad2Extended
{
    public class KnownTypesBinder : SerializationBinder
    {
        public IList<Type> KnownTypes { get; set; }

        public KnownTypesBinder()
        {
            KnownTypes = new List<Type> { typeof(ClassA), typeof(ClassB), typeof(ClassC) };
        }

        public override Type BindToType(string assemblyName, string typeName) // daje mi typ po nazwie
        {
            return KnownTypes.SingleOrDefault(t => t.Name == typeName);
        }

        public override void BindToName(Type serializedType, out string assemblyName, out string typeName) // to daje "ClassA"
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }
        

      
    }
}
