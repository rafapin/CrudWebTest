using CrudTestWeb.Users.Domain.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace CrudTestWeb.Users.Infrastructure.Implementations.Encrypt
{
    public class Sha512EncryptService : IEncryptService
    {
        public string Encrypt(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", string.Empty);
            }
        }
    }
}
