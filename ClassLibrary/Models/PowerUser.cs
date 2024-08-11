using ClassLibrary.Enums;
using ClassLibrary.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary.Models
{
    internal class PowerUser : User, IPowerUser
    {
        public EnumUserType UserType { get; set; }

        internal override string FullUser => $"{base.FullUser}\n(Usuário): {UserType}";

        public PowerUser() : base() { }

        public PowerUser(string name, string userName, string password, EnumUserType userType) : base(name, userName, password)
        {
            UserType = userType;
        }
    }
}
