using isRock.LineBot;
using LineChatBot_DotNetCore.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace LineChatBot_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : LineWebHookControllerBase
    {
        [HttpPost]
        [TypeFilter(typeof(LineVerifySignatureFilter))]
        [Route("LineAccount")]
        public ActionResult Post()
        {
            ChannelAccessToken = "";

            return Ok();
        }
    }
}