using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PS.HireRocks.Data.Helpers
{
    public class XMLToObjectConverter
    {
        public static T ConvertXMLToObject<T>(string xml) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
