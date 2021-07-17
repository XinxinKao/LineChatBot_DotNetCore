using System;
using LineChatBot_DotNetCore.Models;
using LineChatBot_DotNetCore.Proxy;
using LineChatBot_DotNetCore.Services.Interface;

namespace LineChatBot_DotNetCore.Services
{
    public class LineService : ILineService
    {
        private readonly ILineProxy _lineProxy;

        public LineService(ILineProxy lineProxy)
        {
            _lineProxy = lineProxy;
        }

        public void Chat(WebhookEvent request)
        {
            _lineProxy.Reply(request.Events[0].ReplyToken, new LineMessage()
            {
                Type = "text", 
                Text = $"You key in : {request.Events[0].Message.Text}"
            });

            _lineProxy.PushMessage(request.Events[0].Source.UserId, new LineMessage()
            {
                Type = "text",
                Text = "Push message " + DateTime.Now
            });
        }
    }
}