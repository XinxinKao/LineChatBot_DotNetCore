﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using LineChatBot_DotNetCore.Models;
using LineChatBot_DotNetCore.Models.Interface;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LineChatBot_DotNetCore.Proxy
{
    public class LineProxy : ILineProxy
    {
        private const string LineReplyUrl = "https://api.line.me/v2/bot/message/reply";
        private const string LinePushUrl = "https://api.line.me/v2/bot/message/push";
        private readonly IOptions<LineSetting> _lineSetting;
        private readonly HttpClient _httpClient;

        public LineProxy(HttpClient httpClient, IOptions<LineSetting> lineSetting)
        {
            _httpClient = httpClient;
            _lineSetting = lineSetting;
        }

        public void Reply(string message, string replyToken)
        {
            var request = new LineReplyMessage
            {
                ReplyToken = replyToken,
                Messages = new[]
                {
                    new LineMessage { Type = "text", Text = message }
                }
            };

            PostLineApi(request, LineReplyUrl);
        }

        public void PushMessage(string userId, LineMessage message)
        {
            var request = new LinePushResponse
            {
                To = userId,
                Messages = new object[]
                {
                    message
                }
            };

            PostLineApi(request, LinePushUrl);
        }

        private void PostLineApi(ILinePushResponse request, string requestUrl)
        {
            var requestContent = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(requestContent, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _lineSetting.Value.AccessToken);
            _httpClient.PostAsync(requestUrl, stringContent);
        }
    }
}