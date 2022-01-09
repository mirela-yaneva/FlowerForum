using FlowersForum.Domain.Models;

namespace FlowersForum.Domain.Abstractions.Services
{
    public interface IHasherService
    {
        PasswordAndSalt HashPassword(string password);
        bool VerifyHashedPassword(string providedPassword, string hashedPassword, string saltString);
    }
}
