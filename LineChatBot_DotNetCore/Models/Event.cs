using LineChatBot_DotNetCore.Enums;
using Newtonsoft.Json;

namespace LineChatBot_DotNetCore.Models
{
    public class Event
    {
        [JsonProperty("replyToken")]
        public string ReplyToken { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } //todo enum WebhookEventType

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("source")]
        public WebhookEventSource Source { get; set; }

        [JsonProperty("message")]
        public LineMessage Message { get; set; }

        public override string ToString()
        {
            return $"{nameof(ReplyToken)}: {ReplyToken}, {nameof(Type)}: {Type}, {nameof(Mode)}: {Mode}, {nameof(Timestamp)}: {Timestamp}, {nameof(Source)}: {Source}, {nameof(Message)}: {Message}";
        }
    }
}