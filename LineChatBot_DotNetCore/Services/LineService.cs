using LineChatBot_DotNetCore.Models;
using LineChatBot_DotNetCore.Proxy;
using LineChatBot_DotNetCore.Services.Interface;

namespace LineChatBot_DotNetCore.Services
{
    public class LineService : ILineService
    {
        private ILineProxy _LineProxy;

        public LineService(ILineProxy lineProxy)
        {
            _LineProxy = lineProxy;
        }

        public void Chat(WebhookEvent request)
        {
            _LineProxy.Reply(request.Events[0].Message.Text, request.Events[0].ReplyToken);
        }
    }
}