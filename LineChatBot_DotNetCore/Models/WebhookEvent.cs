using System.Collections.Generic;
using Newtonsoft.Json;

namespace LineChatBot_DotNetCore.Models
{
    public class WebhookEvent
    {
        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("events")]
        public List<Event> Events { get; set; }
    }
}