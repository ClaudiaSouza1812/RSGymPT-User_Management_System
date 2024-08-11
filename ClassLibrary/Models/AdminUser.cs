using ClassLibrary.Enums;
using ClassLibrary.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    internal class AdminUser : User
    {
        public override EnumUserType UserType { get; set; }

        public AdminUser() : base() { }

        public AdminUser(string name, string lastName, string nif, string email, string userName, string password, EnumUserType userType) : base(name, lastName, nif, email, userName, password, userType)
        {
        }
    }
}
