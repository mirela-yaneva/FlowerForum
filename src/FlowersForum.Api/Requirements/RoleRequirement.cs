using FlowersForum.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace FlowersForum.Api.Requirements
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public Role Role { get; set; }

        public RoleRequirement(Role role)
        {
            Role = role;
        }
    }
}
