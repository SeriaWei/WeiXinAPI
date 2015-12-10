namespace WeiXinAPI.MP
{
    public class CodeTable
    {
        public class MessageType
        {
            public const string Text = "text";
            public const string Image = "image";
            public const string Voice = "voice";
            public const string Video = "video";
            public const string ShortVideo = "shortvideo";
            public const string Location = "location";
            public const string Link = "link";
            public const string Event = "event";
        }
        public class EventType
        {
            public const string Subscribe = "subscribe";
            public const string UnSubscribe = "unsubscribe";
            public const string Scan = "SCAN";
            public const string Location = "LOCATION";
            public const string Click = "CLICK";
            public const string View = "VIEW";
        }
    }
}