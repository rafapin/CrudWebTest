using System;
using System.Collections.Generic;
using System.Text;

namespace CrudTestWeb.Users.Domain.Contracts
{
    public interface IEncryptService
    {
        string Encrypt(string password);
    }
}
