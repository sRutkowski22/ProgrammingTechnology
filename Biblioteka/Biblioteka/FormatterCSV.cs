using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Collections;

namespace Biblioteka
{
    class FromatterCSV<T> : IFormatter where T : class
    {
        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get ; set; }
        public StreamingContext Context { get; set ; }

       

        public object Deserialize(Stream serializationStream)
        {
            throw new NotImplementedException();
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            ISerializable _data = (ISerializable)graph;
            SerializationInfo _info = new SerializationInfo(graph.GetType(), new FormatterConverter());
            StreamingContext _context = new StreamingContext(StreamingContextStates.File);
            _data.GetObjectData(_info, _context);
         
            using (StreamWriter stream = new StreamWriter(serializationStream))
            {
                foreach (SerializationEntry _item in _info)
                { 
            
                    stream.Write(_item.Value);
                    stream.Write(';');
                }
                stream.Write('\n');
                stream.Flush();
            }



             /*       this.WriteMember(_item.Name, _item.Value);
            XmlWriter _writer = XmlWriter.Create(serializationStream);
            XDocument m_xmlDocument = new XDocument(new XElement("SerializationTest", _values));
            m_xmlDocument.Save(_writer);
            _writer.Flush();

            using (StreamWriter stream = new StreamWriter(serializationStream))
            {
              
                var members = FormatterServices.GetSerializableMembers(typeof(T), Context);
             //   foreach (var item in (IEnumerable)graph)
              //  {
                    var objs = FormatterServices.GetObjectData(graph, members);
                    var valueList = objs.Select(e => e.ToString());
                    var values = String.Join(new String(';', 1), valueList);
                    stream.WriteLine(values);
           //     }
                stream.Flush();
            }*/

        }
        private void SerializeKatalog()
        {

        }
    }
}
