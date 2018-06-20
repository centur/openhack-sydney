using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicoreapp.Logic;
using apicoreapp.Models;
using k8s;
using Microsoft.AspNetCore.Mvc;

namespace apicoreapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        K8Commands _commands = new K8Commands();
        IHelmCommands _helmCommands = new HelmCommands();

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _commands.GetServices());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post()
        {
            _helmCommands.CreateService($"minecraft{DateTime.Now.Ticks}");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            _helmCommands.DeleteService(name);
        }
    }
}
