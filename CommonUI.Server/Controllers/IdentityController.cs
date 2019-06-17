using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CommonUI.Server.Controllers {

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase {

        private readonly ILogger<IdentityController> _logger;

        public IdentityController(ILogger<IdentityController> logger) {
            _logger = logger;
        }

        // GET api/values
        [HttpGet("Me")]
        public ActionResult<string> Me() {
            _logger.LogInformation($"Identity: {HttpContext.User.Identity.Name}");
            return HttpContext.User.Identity.Name;
        }

        [HttpGet("Roles")]
        public ActionResult<string> Roles() {
            foreach (var claims in HttpContext.User.Claims.AsEnumerable()) {
                System.Console.WriteLine(claims.Type);
                System.Console.WriteLine(claims.Value);
            }

            _logger.LogInformation($"Identity: {HttpContext.User.Identity.Name}");
            return HttpContext.User.Identity.Name;
        }
    }
}