using System;
using ClassLibrary.Interfaces.IModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Enums;

namespace ClassLibrary.Models
{
    internal class SimpleUser : User, ISimpleUser
    {
        public EnumUserType UserType { get; set; }

        internal override string FullUser => $"{base.FullUser}\n(Usuário): {UserType}";

        public SimpleUser() : base() { }

        public SimpleUser(string name, string userName, string password, EnumUserType userType) : base(name, userName, password) 
        { 
            UserType = userType;
        }
    }
}
