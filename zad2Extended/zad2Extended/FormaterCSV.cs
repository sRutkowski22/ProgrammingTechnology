using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Collections;
using System.Reflection;

namespace zad2Extended
{
    public class FormatterCSV : IFormatter 
    {
        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public ObjectIDGenerator objectIDGenerator { get; set; }


        public object Deserialize(Stream serializationStream)
        {
            
            object returnObject = null;
            using (StreamReader stream = new StreamReader(serializationStream))
            {
                String line = stream.ReadLine();
                String[] fieldData = line.Split(';');
                T obj = (T)FormatterServices.GetUninitializedObject(typeof(T));
                // var members = FormatterServices.GetSerializableMembers(obj.GetType(), Context);
                // object[] data = new object[members.Length];
                // ISerializable type = (ISerializable)obj;
                SerializationInfo _info = new SerializationInfo(obj.GetType(), new FormatterConverter());
                string[] words = line.Split(';');
                for (int i = 0; i < words.Length - 1; ++i)
                {
                    string[] word = words[i].Split(':');
                    _info.AddValue(word[0], word[1]);
                }

                var constructor = obj.GetType().GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(SerializationInfo), typeof(StreamingContext) }, null);
                constructor.Invoke(obj, new object[] { _info, Context });
                returnObject = obj;

                //  returnObject = FormatterServices.PopulateObjectMembers(obj, members, data))

            }
            return returnObject;
        }
        public void Serialize(Stream serializationStream, object graph)
        {

           
            using (StreamWriter stream = new StreamWriter(serializationStream))
            {
             
            
                stream.Write(SerializeToString(stream, graph));
              
                stream.Flush();

            }


        }
        public StreamWriter SerializeToString(StreamWriter stream, object graph)
        {
            ISerializable _data = (ISerializable)graph;
            SerializationInfo _info = new SerializationInfo(graph.GetType(), new FormatterConverter());
            StreamingContext _context = new StreamingContext(StreamingContextStates.File);
            _data.GetObjectData(_info, _context);
            string assembly;
            string typeName;
            long objectID;
            bool firstTime = false;
            stream.AutoFlush = true;
            objectID = objectIDGenerator.GetId(graph, out firstTime);
            if (!firstTime)
            {
                stream.Write("IDREF");
                stream.Write(':');
                stream.Write(objectID);
                stream.Write(';');
            }
            else
            {
                stream.Write("ID");
                stream.Write(':');
                stream.Write(objectID);
                stream.Write(';');

                Binder.BindToName(graph.GetType(), out assembly, out typeName);
                stream.Write("TypeName");
                stream.Write(':');
                stream.Write(typeName);
                stream.Write(';');



                //   Type type = Binder.BindToType(assembly, typeName);

                foreach (SerializationEntry _item in _info)
                {
                   /* string typeName2;
                    Type type = _item.Value.GetType();
                    Binder.BindToName(type, out assembly, out typeName2);
                    Binder.checkObjectType(_item.Value.GetType())*/
                    if (checkObjectType(_item.Value.GetType()))
                    {
                        stream.Write('\n');
                        stream.Write('{');
                        stream.Write('\n');
                        this.SerializeToString(stream, _item.Value);
                        stream.Write('}');

                    }
                    else
                    {
                        stream.Write(_item.Name);
                        stream.Write(':');
                        stream.Write(_item.Value);
                        stream.Write(';');

                    }
                }
            }
            stream.Write('\n');
            return stream;
        }

        public void Serialize(object graph)
        {
            String filename = "serialize.csv";
            Stream stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            this.Serialize(stream, graph);
            stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            stream.Close();
            FormatterCSV.DeleteLastLine(filename);
        }

        private bool checkObjectType(Type typeT)
        {
            string type;
            string asseblmy;
            Binder.BindToName(typeT, out asseblmy, out type);
            return type.Equals("ClassA") || type.Equals("ClassB") || type.Equals("ClassC");
        }

        public static void DeleteLastLine(string filepath)
        {
            List<string> lines = File.ReadAllLines(filepath).ToList();

            File.WriteAllLines(filepath, lines.GetRange(0, lines.Count - 1).ToArray());

        }
    }
}