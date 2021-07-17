namespace LineChatBot_DotNetCore.Models
{
    public class LineSetting
    {
        public string ChannelSecret { get; set; }
        public string AccessToken { get; set; }

        public override string ToString()
        {
            return $"{nameof(ChannelSecret)}: {ChannelSecret}, {nameof(AccessToken)}: {AccessToken}";
        }
    }
}