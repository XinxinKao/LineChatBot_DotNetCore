using LineChatBot_DotNetCore.Models;

namespace LineChatBot_DotNetCore.Services.Interface
{
    public interface ILineService
    {
        void Chat(WebhookEvent request);
    }
}