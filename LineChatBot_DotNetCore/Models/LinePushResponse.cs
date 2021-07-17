using LineChatBot_DotNetCore.Models.Interface;
using Newtonsoft.Json;

namespace LineChatBot_DotNetCore.Models
{
    public class LinePushResponse : ILinePushResponse
    {
        [JsonProperty("to")]
        public string To { get; set; }
        
        [JsonProperty("messages")]
        public object[] Messages { get; set; }
    }
}