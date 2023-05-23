using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Parser.Tools.Handlers
{
    public sealed class XmlHandler
    {
        /// <summary>
        /// Deserialize XML file
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="xmlPath">Path to XML file</param>
        /// <param name="rootElementName">XML root element name</param>
        /// <returns>T</returns>
        public static T Deserialize<T>(string xmlPath, string rootElementName) where T : class
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            using (TextReader sr = new StringReader(xmlDoc.InnerXml))
            {
                var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("cards"));
                var resp = serializer.Deserialize(sr) as T;
                return resp;
            }
        }
    }
}
