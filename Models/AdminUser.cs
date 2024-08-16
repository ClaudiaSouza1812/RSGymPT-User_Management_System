using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models
{
    public class AdminUser : User, IAdminUser
    {
        public override EnumUserProfile userProfile { get; set; }

        public AdminUser() : base() { }

        public AdminUser(string name, string lastName, string nif, string email, string userName, string password, EnumUserProfile userProfile) : base(name, lastName, nif, email, userName, password, userProfile){ }

    }
}
