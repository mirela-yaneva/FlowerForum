using FlowersForum.Api.Requirements;
using FlowersForum.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlowersForum.Api.Middleware
{
    public class RoleHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       RoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                return Task.CompletedTask;
            }

            var roleString = context.User.FindFirst(c => c.Type == ClaimTypes.Role).Value;

            Enum.TryParse(roleString, out Role roleEnum);

            if (requirement.Role.HasFlag(roleEnum))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
