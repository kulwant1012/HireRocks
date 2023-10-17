using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace PS.HireRocks.Web.Helpers
{
    public class ConvertObjectToXML
    {
        public string ConvertObjectToXml<T>(T model) where T:class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces namespaces=new XmlSerializerNamespaces();
            namespaces.Add(string.Empty,string.Empty);
            StringBuilder builder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            using (XmlWriter stringWriter = XmlWriter.Create(builder, settings))
            {
                serializer.Serialize(stringWriter, model,namespaces);
                return builder.ToString();
            }
        }
    }
}