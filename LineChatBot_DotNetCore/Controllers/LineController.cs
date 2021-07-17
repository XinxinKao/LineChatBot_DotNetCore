using System.Threading.Tasks;
using isRock.LineBot;
using LineChatBot_DotNetCore.Attributes;
using LineChatBot_DotNetCore.Models;
using LineChatBot_DotNetCore.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LineChatBot_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : ControllerBase//LineWebHookControllerBase
    {
        private readonly ILineService _lineService;

        public LineController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [TypeFilter(typeof(LineVerifySignatureFilter))]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WebhookEvent data)
        {
            _lineService.Chat(data);

            return Ok();
        }
    }
}