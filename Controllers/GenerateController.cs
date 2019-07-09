using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_kafka.MessageBroker;
using aspnet_kafka.Model;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_kafka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateController : ControllerBase
    {
        private readonly IPublisher _publisher;

        public GenerateController(IPublisher publisher)
        {
            _publisher = publisher;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] MessageDTO messageDTO)
        {
            await _publisher.Publish(messageDTO.TransactionId, messageDTO);            

            return Ok();
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
