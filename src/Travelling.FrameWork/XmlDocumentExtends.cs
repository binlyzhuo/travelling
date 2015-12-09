using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Travelling.FrameWork
{
    public static class XmlDocumentExtends
    {
        //public static string GetChildNodeValue(this XmlNode node,string childName)
        //{
        //    return node.SelectSingleNode(childName).InnerText.Trim();
        //}

        public static XmlNode GetChildNode(this XmlNode node,string childName)
        {
            return node.SelectSingleNode(childName);
        }

        public static XmlElement ToXmlElement(this XmlNode xmlNode)
        {
            return xmlNode as XmlElement;
        }

        public static string GetChildNodeInnerText(this XmlNode node,string childName)
        {
            if(node.SelectSingleNode(childName)!=null)
            {
                return node.SelectSingleNode(childName).InnerText.Trim();
            }
            return "";
        }
    }
}
