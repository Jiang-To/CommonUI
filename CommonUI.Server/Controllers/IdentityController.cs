using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommonUI.Server.Controllers {

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase {
        // GET api/values
        [HttpGet("Me")]
        public ActionResult<string> Me() {
            return HttpContext.User.Identity.Name;
        }
    }
}