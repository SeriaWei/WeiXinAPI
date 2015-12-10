using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WeiXinAPI.MP.Message
{
    class MessageProvider
    {
        private readonly string _xml;
        public MessageProvider(Stream stream)
        {
            _xml = new StreamReader(stream).ReadToEnd();
        }

        T Deserialize<T>() where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return serializer.Deserialize(new StringReader(_xml)) as T;
        }
        public MessageBase Parse()
        {
            var msg = Deserialize<MessageBase>();
            switch (msg.MsgType)
            {
                case CodeTable.MessageType.Text:
                    return Deserialize<GeneralMessageText>();
                case CodeTable.MessageType.Image:
                    return Deserialize<GeneralMessageImage>();
                case CodeTable.MessageType.Voice:
                    return Deserialize<GeneralMessageVoice>();
                case CodeTable.MessageType.Video:
                    return Deserialize<GeneralMessageVideo>();
                case CodeTable.MessageType.ShortVideo:
                    return Deserialize<GeneralMessageShortVideo>();
                case CodeTable.MessageType.Location:
                    return Deserialize<GeneralMessageLocation>();
                case CodeTable.MessageType.Link:
                    return Deserialize<GeneralMessageLink>();
                case CodeTable.MessageType.Event:
                    {
                        var eventMsg = Deserialize<EventMessage>();
                        switch (eventMsg.Event)
                        {
                            case CodeTable.EventType.Subscribe:
                                return Deserialize<EventMessageSubscribe>();
                            case CodeTable.EventType.UnSubscribe:
                                return Deserialize<EventMessageUnSubscribe>();
                            case CodeTable.EventType.Scan:
                                return Deserialize<EventMessageScan>();
                            case CodeTable.EventType.Location:
                                return Deserialize<EventMessageLocation>();
                            case CodeTable.EventType.Click:
                                return Deserialize<EventMessageClick>();
                            case CodeTable.EventType.View:
                                return Deserialize<EventMessageView>();
                        }
                        break;
                    }
            }
            return msg;
        }
    }
}
