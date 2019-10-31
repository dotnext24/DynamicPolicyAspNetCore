using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.MassTransit;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMassTransitRequest<Request> _massTransitRequest;
        public ValuesController(IMassTransitRequest<Request> massTransitRequest)
        {
            _massTransitRequest = massTransitRequest;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            _massTransitRequest.Send(new Request()
            {
                TestMessage = "Date time" + DateTime.Now

            }).GetAwaiter().GetResult();

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
