using System;
using System.Globalization;
using LineChatBot_DotNetCore.Models;
using LineChatBot_DotNetCore.Proxy;
using LineChatBot_DotNetCore.Services.Interface;
using Microsoft.VisualBasic;

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

            _LineProxy.PushMessage(request.Events[0].Source.UserId, new LineMessage()
            {
                Type = "text",
                Text = "Push message " + DateTime.Now
            });
        }
    }
}