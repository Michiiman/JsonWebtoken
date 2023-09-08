using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ApiPrueba1._0.Helpers;

    public class GlobalVerbRoleHandler : AuthorizationHandler<GlobalVerbRoleRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GlobalVerbRoleHandler(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GlobalVerbRoleRequirement requirement)
    {
        var roles = context.User.FindAll(c=>string.Equals(c.Type, ClaimTypes.Role)).Select(c=>c.Value);
        var verb = _httpContextAccessor.HttpContext?.Request.Method;
        if (string.IsNullOrEmpty(verb)){throw new Exception($"reques cann't be null"); }
        foreach (var role in roles)
        {
            if(requirement.IsAllowed(role,verb))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
        }
        context.Fail();
        return Task.CompletedTask;
    }
}
