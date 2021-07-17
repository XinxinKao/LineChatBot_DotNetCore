using Newtonsoft.Json;

namespace LineChatBot_DotNetCore.Models
{
    public class WebhookEventSource
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{nameof(UserId)}: {UserId}, {nameof(Type)}: {Type}";
        }
    }
}