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
    public class CaseController : ControllerBase
    {
        // GET: api/Case
        [HttpGet(Name = "cases")]
        [Authorize("Case.Read")]
        public IEnumerable<string> Get()
        {
            var c = User.Claims;
            return new string[] { "value1", "value2" };
        }

        
    }
}
