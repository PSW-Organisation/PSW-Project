using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ehealthcare.Repository
{
    public class DataIO
    {
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }
            XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
            try
            {
                var temp = AppDomain.CurrentDomain.BaseDirectory;
                temp = Path.Combine(temp.Substring(0, temp.Length - 10), "Storage\\");
                fileName = Path.Combine(temp, fileName);
                StreamWriter w = new StreamWriter(fileName);
                serializer.Serialize(w, serializableObject);
                w.Close();
            }
            catch (Exception e)
            {
                //Log exception here
            }
        }

        public T DeSerializeObject<T>(string fileName)
        {
            var temp = AppDomain.CurrentDomain.BaseDirectory;
            temp = Path.Combine(temp.Substring(0, temp.Length - 10), "Storage\\");
            fileName = Path.Combine(temp, fileName);
            if (string.IsNullOrEmpty(fileName)) { return default(T); }
            T objectOut = default(T);

            try
            {
                Type outType = typeof(T);
                XmlSerializer serializer = new XmlSerializer(outType);

                StreamReader r = new StreamReader(fileName);
                objectOut = (T)serializer.Deserialize(r);
                r.Close();

            }
            catch (Exception e)
            {
                //Log exception here
            }

            return objectOut;
        }
    }
}
