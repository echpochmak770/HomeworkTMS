using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HomeworkTMS
{
    public static class XmlParser
    {
        public static void SaveToXml<T>(T obj, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, obj);
            }
        }
    }
}
