using FlowersForum.Domain.Enums;
using System;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IJwtService
    {
        public string GenerateJsonWebToken(Role role, Guid userId);
    }
}
