using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeiXinAPI.MP.Message
{
    public class MessageBase
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public int CreateTime { get; set; }
        public string MsgType { get; set; }
    }
}
