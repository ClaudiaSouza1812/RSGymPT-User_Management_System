using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IMethods;
using System.Security.Cryptography;
using static System.Collections.Specialized.BitVector32;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Methods
{
    public class EncryptPassword : IEncryptPassword
    {
        string IEncryptPassword.EncryptPassword(string password)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            };
        }
    }
}
