using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WeiXinAPI.MP.Message
{
    [XmlRoot("xml")]
    public class MessageBase
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public int CreateTime { get; set; }
        public string MsgType { get; set; }
        public override string ToString()
        {
            XmlSerializer serializer = new XmlSerializer(GetType());
            StringBuilder builder = new StringBuilder();
            serializer.Serialize(new StringWriter(builder), this);
            return builder
                .Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "")
                .Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">", ">")
                .ToString()
                .Trim();
        }
    }
}
