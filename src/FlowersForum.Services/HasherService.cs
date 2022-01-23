using FlowersForum.Domain.Abstractions.Services;
using FlowersForum.Domain.Constants;
using FlowersForum.Domain.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace FlowersForum.Services
{
    public class HasherService : IHasherService
    {
        public PasswordAndSalt HashPassword(string password)
        {
            var salt = GenerateSalt();
            var hash = GeneratePdkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: NumberConstants.IterationCount,
                numBytesRequested: NumberConstants.KeySize);

            var outputBytes = new byte[NumberConstants.KeySize];
            Buffer.BlockCopy(hash, 0, outputBytes, 0, NumberConstants.KeySize);

            return new PasswordAndSalt
            {
                Password = Convert.ToBase64String(outputBytes),
                Salt = Convert.ToBase64String(salt)
            };
        }

        public bool VerifyHashedPassword(string providedPassword, string hashedPassword, string saltString)
        {
            if (hashedPassword == null)
            {
                throw new ArgumentNullException(nameof(hashedPassword));
            }
            if (providedPassword == null)
            {
                throw new ArgumentNullException(nameof(providedPassword));
            }

            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);
            if (decodedHashedPassword.Length == 0)
            {
                return false;
            }

            return VerifyHashedPassword(decodedHashedPassword, providedPassword, saltString);
        }

        private byte[] GenerateSalt()
        {
            var salt = new byte[NumberConstants.SaltSize];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            return salt;
        }

        private byte[] GeneratePdkdf2(string password, byte[] salt, KeyDerivationPrf prf, int iterationCount, int numBytesRequested)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: NumberConstants.IterationCount,
                numBytesRequested: NumberConstants.KeySize);
        }

        private bool VerifyHashedPassword(byte[] decodedHashedPassword, string providedPassword, string salt)
        {
            byte[] saltByteArray = Convert.FromBase64String(salt);

            var actualHash = GeneratePdkdf2(
                password: providedPassword,
                salt: saltByteArray,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: NumberConstants.IterationCount,
                numBytesRequested: NumberConstants.KeySize);

            return CryptographicOperations.FixedTimeEquals(actualHash, decodedHashedPassword);
        }
    }
}
