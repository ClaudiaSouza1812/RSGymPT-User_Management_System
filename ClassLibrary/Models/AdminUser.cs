using ClassLibrary.Enums;
using ClassLibrary.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    internal class AdminUser : User, IAdminUser
    {
        public EnumUserType UserType { get; } = EnumUserType.Admin;

        internal override string FullUser => $"{base.FullUser}\n(Usuário): {UserType}";

        public AdminUser() : base(){ }

        public AdminUser(string name, string userName, string password) : base(name, userName, password){ }
    }
}
