using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MouseOverServer.Infrastructure.Managers;
using MouseOverServer.Infrastructure.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MouseOverServer.Controllers
{
    [Route("api/mouse")]
    public class MouseController : Controller
    {
        private readonly IMouseManager _mouseManager;

        public MouseController(IMouseManager mouseManager)
        {
            _mouseManager = mouseManager;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Send mouse coordinates x,y to ~/api/mouse/x/y/" };
        }

        [HttpGet("{x}/{y}/{width:int=0}/{height:int=0}")]
        public IActionResult Get(int x, int y, int width = 0, int height = 0)
        {
            if (_mouseManager.SetMouseAbsolute(x, y))
            {
                return Ok($"Updated mouse position to {x},{y}");
            }

            return BadRequest("Invalid input");
        }
    }
}
