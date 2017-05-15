using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tools
{
    public class XmlHelper
    {
        public static void Serialize<T>(T myObject, string fullPath) where T: class, new()
        {
            if(myObject == null) throw new ArgumentNullException(nameof(myObject));

            if (String.IsNullOrWhiteSpace(fullPath)) throw new ArgumentNullException(nameof(fullPath));

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(sw, myObject);
                }
            }

            catch
            {
                throw;
            }
        }

        public static T Deserialize<T>(string fullPath) where T: class, new()
        {
            if (String.IsNullOrWhiteSpace(fullPath)) throw new ArgumentNullException(nameof(fullPath));

            T result;

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    result = (T)serializer.Deserialize(sr);
                }

                return result;
            }

            catch
            {
                throw;
            }
        }
    }
}
