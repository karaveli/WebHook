using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using WebHookApp.Model;
using System.Net.Http;


namespace WebHookApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HookController : ControllerBase
    {
        private IHostingEnvironment _env;

        public HookController(IHostingEnvironment env)
        {
            _env = env;
        }
        [HttpGet("{id}")]
        public ActionResult<string> Get()
        {
            var webRoot = _env.ContentRootPath;
            var file = System.IO.Path.Combine(webRoot, "test.txt");
            System.IO.File.AppendAllText(file, "get : " + System.DateTime.Now.ToString("dd_MM_yyyy_HH:mm:ss") + "\n");
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] object model)
        {




            var webRoot = _env.ContentRootPath;
            var file = System.IO.Path.Combine(webRoot, "test.txt");
            System.IO.File.AppendAllText(file, "post : " + System.DateTime.Now.ToString("dd_MM_yyyy_HH:mm:ss") + System.Environment.NewLine);
        }
    }
}
