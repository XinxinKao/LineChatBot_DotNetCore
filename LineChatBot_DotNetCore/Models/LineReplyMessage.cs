using Newtonsoft.Json;

namespace LineChatBot_DotNetCore.Models
{
    public class LineReplyMessage
    {
        [JsonProperty("replyToken")]
        public string ReplyToken { get; set; }

        [JsonProperty("messages")]
        public object[] Messages { get; set; }
    }
}