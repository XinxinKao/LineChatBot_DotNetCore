using LineChatBot_DotNetCore.Models;

namespace LineChatBot_DotNetCore.Proxy
{
    public interface ILineProxy
    {
        void Reply(string replyToken, LineMessage message);
        void PushMessage(string userId, LineMessage message);
    }
}