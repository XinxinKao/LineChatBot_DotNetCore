using LineChatBot_DotNetCore.Models;

namespace LineChatBot_DotNetCore.Proxy
{
    public interface ILineProxy
    {
        void Reply(string message, string replyToken);
        void PushMessage(string userId, LineMessage message);
    }
}