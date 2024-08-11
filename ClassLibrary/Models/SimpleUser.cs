using System;
using ClassLibrary.Interfaces.IModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Enums;

namespace ClassLibrary.Models
{
    internal class SimpleUser : User
    {

        public SimpleUser() : base() { }

        public SimpleUser(string name, string lastName, string nif, string email, string userName, string password, EnumUserType userType) : base(name, lastName, nif, email, userName, password, userType) 
        { 
        }
    }
}
