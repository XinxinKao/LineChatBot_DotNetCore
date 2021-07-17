namespace LineChatBot_DotNetCore.Proxy
{
    public interface ILineProxy
    {
        void Reply(string message, string replyToken);
    }
}