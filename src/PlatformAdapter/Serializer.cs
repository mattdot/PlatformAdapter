using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PlatformAdapter
{
    public enum SerializerFileTypes
    {
        Xml,
        Json,
        Binary
    }

    public static class Serializer
    {
        public static string Serialize(object obj, SerializerFileTypes fileType)
        {
            switch (fileType)
            {
                case SerializerFileTypes.Xml:
                    return SerializeToXml(obj);
                case SerializerFileTypes.Json:
                    return SerializeToJson(obj);
                default:
                    throw new NotImplementedException("Unrecognized file type " + fileType);
            }
        }

        public static T Deserialize<T>(Stream stream, SerializerFileTypes fileType)
        {
            switch (fileType)
            {
                case SerializerFileTypes.Xml:
                    return DeserializeFromXml<T>(stream);
                case SerializerFileTypes.Json:
                    return DeserializeFromJson<T>(stream);
                default:
                    throw new NotImplementedException("Unrecognized file type " + fileType);
            }
        }

        public static T Deserialize<T>(string data, SerializerFileTypes fileType)
        {
            switch (fileType)
            {
                case SerializerFileTypes.Xml:
                    return DeserializeFromXml<T>(data);
                case SerializerFileTypes.Json:
                    return DeserializeFromJson<T>(data);
                default:
                    throw new NotImplementedException("Unrecognized file type " + fileType);
            }
        }

        #region XML Serialization

        private static T DeserializeFromXml<T>(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return default(T);

            var xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
            return (T)xs.Deserialize(new StringReader(xml));
        }

        private static T DeserializeFromXml<T>(Stream stream)
        {
            if (stream == null)
                return default(T);

            var xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
            return (T)xs.Deserialize(stream);
        }

        private static string SerializeToXml(object obj)
        {
            if (obj == null)
                return string.Empty;

            var xs = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            using (var stream = new StringWriter())
            {
                xs.Serialize(stream, obj);
                return stream.ToString();
            }
        }
        //private string Serialize(object obj)
        //{
        //    if (obj == null)
        //        return null;

        //    XmlSerializer serializer = new XmlSerializer(obj.GetType());

        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    using (System.IO.StringWriter stream = new System.IO.StringWriter(sb))
        //    {
        //        serializer.Serialize(stream, obj);
        //        stream.Dispose();
        //    }

        //    return sb.ToString();
        //}

        #endregion

        #region JSON Serialization

        private static T DeserializeFromJson<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        private static T DeserializeFromJson<T>(Stream stream)
        {
            if (stream == null)
                return default(T);

            using (StreamReader sr = new StreamReader(stream))
            {
                return DeserializeFromJson<T>(sr.ReadToEnd());
            }
        }

        private static string SerializeToJson(object obj)
        {
            if (obj == null)
                return string.Empty;

            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        #endregion

        #region Binary Serialization
        // TODO Add serializers/deserializers for Binary
        #endregion
    }
}
