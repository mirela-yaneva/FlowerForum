using FlowersForum.Domain.Enums;
using System;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IJwtService
    {
        string GenerateJsonWebToken(Role role, Guid userId);
    }
}
