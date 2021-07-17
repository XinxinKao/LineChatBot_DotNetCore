using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LineChatBot_DotNetCore.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LineChatBot_DotNetCore.Proxy
{
    public class LineProxy : ILineProxy
    {
        private const string LineReplyUrl = "https://api.line.me/v2/bot/message/reply";
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
                Messages = new[] { new LineMessage { Type = "text", Text = message } }
            };


            var requestContent = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(requestContent, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _lineSetting.Value.AccessToken);
            _httpClient.PostAsync(LineReplyUrl, stringContent);
        }

    }
}