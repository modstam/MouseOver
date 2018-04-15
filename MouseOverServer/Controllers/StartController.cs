using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MouseOverServer.Controllers
{
    [Route("api/start")]
    public class StartController : Controller
    {


        public string CurrentVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            string welcomeMessage = $"MouseOver Server: {{ Version:{this.CurrentVersion} }}";
            return welcomeMessage;
        }

        
        [Route("getname")]
        [HttpGet]
        public string Name()
        {
            return Environment.MachineName; ;
        }

    }
}
