using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace AUA.ProjectName.Common.Tools.Config.XmlSetting.BaseXmlPattern
{
    public class XmlReader
    {
        private readonly string _path;
        private readonly string _root;
        private const char Separator = ',';
        public XmlReader(string path)
        {
            _path = path;
            _root = "root";
        }

        public XmlReader(string path, string root)
        {
            _path = path;
            _root = root;
        }

        private string GetValue(string key)
        {
            var doc = XDocument.Load(_path);

            var elementValue = doc.Descendants(XName.Get(key)).FirstOrDefault();

            return elementValue?.Value ?? string.Empty;

        }

        public T Get<T>(string key)
        {
            var v = GetValue(key);

            return (T)Convert.ChangeType(v, typeof(T));

        }

        public List<T> GetList<T>(string key)
        {
            var v = GetValue(key);

            return v.Split(Separator)
                  .Select(s => (T)Convert.ChangeType(s, typeof(T)))
                  .ToList();

        }

        public T GetWithXmlPath<T>(params string[] pathList)
        {
            var node = GetNode(pathList);

            if (node != null) return (T)Convert.ChangeType(node.InnerXml, typeof(T));

            return default;
        }

        private XmlNode GetNode(params string[] pathList)
        {
            var xmlAddress = $"/{_root}";
            const string slash = "/";

            xmlAddress = pathList.Aggregate(xmlAddress, (current, str) => current + slash + str);

            var doc = new XmlDocument();
            doc.Load(_path);

            return doc
                .DocumentElement?
                .SelectSingleNode(xmlAddress);

        }

        public List<T> GetListWithXmlPath<T>(params string[] pathList)
        {
            var node = GetNode(pathList);

            var itemList = new List<T>();
            if (node != null)
                itemList.AddRange(node
                    .InnerXml
                    .Split(Separator)
                    .Select(item => (T)Convert.ChangeType(item, typeof(T))));

            return itemList;
        }
    }
}
