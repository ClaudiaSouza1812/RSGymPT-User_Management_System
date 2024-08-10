using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.IMethods
{
    internal interface IEncryptPassword
    {
        string EncryptPassword(string password);
    }
}
