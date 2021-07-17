using Newtonsoft.Json;

namespace LineChatBot_DotNetCore.Models
{
    public class WebhookEventSource
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}