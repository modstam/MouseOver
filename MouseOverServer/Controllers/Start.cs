using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MouseOverServer.Controllers
{
    [Route("api/[controller]")]
    public class Start : Controller
    {


        public string CurrentVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            string welcomeMessage = $"MouseOver Server: {{ Version:{this.CurrentVersion} }}";
            return welcomeMessage;
        }

    }
}
