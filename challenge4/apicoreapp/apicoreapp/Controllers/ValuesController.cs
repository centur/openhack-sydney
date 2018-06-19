using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using apicoreapp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apicoreapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<Monitor>> Get()
        {
            var HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://mcapi.us");

            var result = await HttpClient.GetAsync($"server/status?ip=13.70.127.199&port=25565");
            string resultContent = await result.Content.ReadAsStringAsync();
            var resultJson = JsonConvert.DeserializeObject<Monitor>(resultContent);
            return resultJson;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
