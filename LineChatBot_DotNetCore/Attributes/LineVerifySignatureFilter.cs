using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using LineChatBot_DotNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace LineChatBot_DotNetCore.Attributes
{
    public class LineVerifySignatureFilter : IAuthorizationFilter
    {
        private readonly IOptions<LineSetting> _lineSetting;

        public LineVerifySignatureFilter(IOptions<LineSetting> lineSetting)
        {
            _lineSetting = lineSetting;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.EnableBuffering();

            var requestBody = new StreamReader(context.HttpContext.Request.Body).ReadToEndAsync().Result;
            context.HttpContext.Request.Body.Position = 0;

            var xLineSignature = context.HttpContext.Request.Headers["X-Line-Signature"].ToString();
            var channelSecret = Encoding.UTF8.GetBytes(_lineSetting.Value.ChannelSecret);
            var body = Encoding.UTF8.GetBytes(requestBody);

            using (HMACSHA256 hmac = new HMACSHA256(channelSecret))
            {
                var hash = hmac.ComputeHash(body, 0, body.Length);
                var xLineBytes = Convert.FromBase64String(xLineSignature);
                if (SlowEquals(xLineBytes, hash) == false)
                {
                    context.Result = new ForbidResult();
                }
            }
        }

        private static bool SlowEquals(byte[] bytes, byte[] hash)
        {
            uint diff = (uint)bytes.Length ^ (uint)hash.Length;
            for (int i = 0; i < bytes.Length && i < hash.Length; i++)
                diff |= (uint)(bytes[i] ^ hash[i]);
            return diff == 0;
        }
    }
}