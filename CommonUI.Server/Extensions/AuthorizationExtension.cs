using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CommonUI.Server.Models;
using CommonUI.Server.Repositories.IOCM;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CommonUI.Server.Extensions {
    public static class AuthorizationExtension {
        public static void UseAuthorization(this IApplicationBuilder app) {
            app.UseMiddleware<AuthorizationMiddleware>();
        }
    }

    public class AuthorizationMiddleware {
        private readonly RequestDelegate _next;
        private readonly AppConfig _config;

        public AuthorizationMiddleware(RequestDelegate next, AppConfig config) {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext context) {
            if (context.User != null && context.User.Identity.IsAuthenticated) {
                User user = null;
                
                using(var uow = new IocmUnitOfWork(_config)) {
                    user = uow.UserRepository.GetUserProfileByName(context.User.Identity.Name);
                }

                var claims = user.Roles.AsEnumerable()
                    .Select(role => new Claim(ClaimTypes.Role, role))
                    .ToList();

                var roleIdentity = new ClaimsIdentity(claims);
                context.User.AddIdentity(roleIdentity);
            }

            await _next(context);
        }
    }
}