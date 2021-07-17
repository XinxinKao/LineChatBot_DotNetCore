using Newtonsoft.Json;

namespace LineChatBot_DotNetCore.Models
{
    public class LineMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } //todo enum LineMessageType

        [JsonProperty("text")]
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Type)}: {Type}, {nameof(Text)}: {Text}";
        }
    }

    public enum LineMessageType
    {
        Text,
        Sticker,
        Image,
        Video,
        Audio,
        Template,
        Flex,
        Location
    }
}