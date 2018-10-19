using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventCatalogAPI.Controllers
{
    //    [Route("api/[controller]")]
    //Added below two lines and commeneted the one above
    [Produces("application/json")]
    [Route("api/Pic")]
    [ApiController]
    public class PicController : ControllerBase
    {
        //local variable to capture hosting environment value from constructor
        private readonly IHostingEnvironment _env;
        public PicController(IHostingEnvironment env)//constructor
        {
            _env = env;
        }
    
        [Route("{id}")]
        public IActionResult GetImage(int id)
        {
        var webRoot = _env.WebRootPath;
        var path = Path.Combine(webRoot + "/Pics/" + "Event-" + id + ".png");
        var buffer = System.IO.File.ReadAllBytes(path);
        return File(buffer, "Image/png");
        }
    }
}