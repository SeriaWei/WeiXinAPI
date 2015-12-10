using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WeiXinAPI.MP.Message
{
    [XmlRoot("xml")]
    public class GeneralMessage : MessageBase
    {
        public long MsgId { get; set; }
    }
    [XmlRoot("xml")]
    public class GeneralMessageText : GeneralMessage
    {
        public string Content { get; set; }
    }
    [XmlRoot("xml")]
    public class GeneralMessageImage : GeneralMessage
    {
        public string PicUrl { get; set; }
        public string MediaId { get; set; }
    }
    [XmlRoot("xml")]
    public class GeneralMessageVoice : GeneralMessage
    {
        public string MediaId { get; set; }
        public string Format { get; set; }
        public string Recognition { get; set; }
    }
    [XmlRoot("xml")]
    public class GeneralMessageVideo : GeneralMessage
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }
    }
    [XmlRoot("xml")]
    public class GeneralMessageShortVideo : GeneralMessage
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }
    }
    [XmlRoot("xml")]
    public class GeneralMessageLocation : GeneralMessage
    {
        public double Location_X { get; set; }
        public double Location_Y { get; set; }
        public int Scale { get; set; }
        public string Label { get; set; }
    }
    [XmlRoot("xml")]
    public class GeneralMessageLink : GeneralMessage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
