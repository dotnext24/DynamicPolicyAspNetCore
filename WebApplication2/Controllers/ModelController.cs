using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        // GET: api/Model
        [HttpGet(Name = "models")]
        [Authorize(Roles = "DataScience")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
    }
}
