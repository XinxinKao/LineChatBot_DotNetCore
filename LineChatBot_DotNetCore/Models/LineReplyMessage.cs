using LineChatBot_DotNetCore.Models.Interface;
using Newtonsoft.Json;

namespace LineChatBot_DotNetCore.Models
{
    public class LineReplyMessage : ILinePushResponse
    {
        [JsonProperty("replyToken")]
        public string ReplyToken { get; set; }

        [JsonProperty("messages")]
        public object[] Messages { get; set; }

        public override string ToString()
        {
            return $"{nameof(ReplyToken)}: {ReplyToken}, {nameof(Messages)}: {Messages}";
        }
    }
}