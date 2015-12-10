using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WeiXinAPI.MP.Message
{
    [XmlRoot("xml")]
    public class EventMessage : MessageBase
    {
        public string Event { get; set; }
    }
    [XmlRoot("xml")]
    public class EventMessageSubscribe : EventMessage
    {
        public string EventKey { get; set; }
        public string Ticket { get; set; }
    }
    [XmlRoot("xml")]
    public class EventMessageUnSubscribe : EventMessage
    {
        public string EventKey { get; set; }
        public string Ticket { get; set; }
    }
    [XmlRoot("xml")]
    public class EventMessageScan : EventMessage
    {
        public string EventKey { get; set; }
        public string Ticket { get; set; }
    }
    [XmlRoot("xml")]
    public class EventMessageLocation : EventMessage
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Precision { get; set; }
    }
    [XmlRoot("xml")]
    public class EventMessageClick : EventMessage
    {
        public string EventKey { get; set; }
    }
    [XmlRoot("xml")]
    public class EventMessageView : EventMessage
    {
        public string EventKey { get; set; }
    }
}
