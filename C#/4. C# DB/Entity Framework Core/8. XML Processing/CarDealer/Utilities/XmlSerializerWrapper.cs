using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Utilities;

public static class XmlSerializerWrapper
{
    public static T? Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new(rootName);

        XmlSerializer xmlSerializer = new(typeof(T), xmlRoot);

        using StringReader stringReader = new(inputXml);

        T? result = (T?)xmlSerializer.Deserialize(stringReader);

        return result;
    }

    public static string Serialize<T>(T obj, string rootName, IDictionary<string, string>? xmlNamespaces = null)
    {
        StringBuilder result = new();

        XmlSerializerNamespaces xmlns = new();
        if (xmlNamespaces != null)
        {
            foreach (KeyValuePair<string, string> xmlNamespaceKvp in xmlNamespaces)
            {
                xmlns.Add(xmlNamespaceKvp.Key, xmlNamespaceKvp.Value);
            }
        }
        else
        {
            xmlns.Add(string.Empty, string.Empty);
        }

        XmlRootAttribute xmlRoot = new(rootName);

        XmlSerializer xmlSerializer = new(typeof(T), xmlRoot);

        using StringWriter stringWriter = new(result);

        xmlSerializer.Serialize(stringWriter, obj, xmlns);

        return result.ToString();
    }
}
