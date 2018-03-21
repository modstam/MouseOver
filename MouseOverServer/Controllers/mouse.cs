using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MouseOverServer.Controllers
{
    [Route("api/[controller]")]
    public class Mouse : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Send mouse coordinates x,y to ~/api/mouse/x/y/" };
        }

        [HttpGet("{x}/{y}/{width:int=0}/{height:int=0}")]
        public IActionResult Get(int x, int y, int width = 0, int height = 0)
        {
            if(x != 0 && y != 0)
            {
                return Ok($"Updated mouse position to {x},{y}");
            }
            return BadRequest("Invalid input");
        }
    }
}
