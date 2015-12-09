using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXinAPI.MP.Message
{
    public class GeneralMessage : MessageBase
    {
        public long MsgId { get; set; }
    }

    public class GeneralMessageText : GeneralMessage
    {
        public string Content { get; set; }
    }
    public class GeneralMessageImage : GeneralMessage
    {
        public string PicUrl { get; set; }
        public string MediaId { get; set; }
    }
    public class GeneralMessageVoice : GeneralMessage
    {
        public string MediaId { get; set; }
        public string Format { get; set; }
    }
    public class GeneralMessageVideo : GeneralMessage
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }
    }
    public class GeneralMessageShortVideo : GeneralMessage
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }
    }
    public class GeneralMessageLocation : GeneralMessage
    {
        public double Location_X { get; set; }
        public double Location_Y { get; set; }
        public int Scale { get; set; }
        public string Label { get; set; }
    }
    public class GeneralMessageShortLink : GeneralMessage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
