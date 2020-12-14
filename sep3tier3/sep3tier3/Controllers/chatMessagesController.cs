using Microsoft.AspNetCore.Mvc;
using sep3tier3.Data;
using sep3tier3.Models;

namespace sep3tier3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class chatMessagesController:ControllerBase
    {
        private readonly IUserService userService;
        
        [HttpPost("chatMessages")]
        public IActionResult storeMessage([FromBody] ChatMessage chatMessage)
        {
            userService.storeMessage(chatMessage);
            return Ok();
        }
    }
}