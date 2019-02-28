using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DijleZonenApi.utilities
{
    public class PasswordUtility
    {
        public static HashedPassword encryptPassword(string pwd)
        {
            HashedPassword hashedPassword = new HashedPassword();
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pwd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            hashedPassword.HashedPwd = hashed;
            hashedPassword.Salt = Convert.ToBase64String(salt);

            return hashedPassword;
        }

        public static bool isPasswordCorrect(string pwd, string hashed, string salt)
        {
            string hashed2 = Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: pwd,
               salt: Convert.FromBase64String(salt),
               prf: KeyDerivationPrf.HMACSHA1,
               iterationCount: 10000,
               numBytesRequested: 256 / 8));

            return (hashed2 == hashed);
        }
    }

    public class HashedPassword
    {
        public string HashedPwd { get; set; }
        public string Salt { get; set; }
    }
}
