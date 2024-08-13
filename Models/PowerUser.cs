using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models
{
    internal class PowerUser : User
    {
        public override EnumUserType UserType { get; set; }

        public PowerUser() : base() { }

        public PowerUser(string name, string lastName, string nif, string email, string userName, string password, EnumUserType userType) : base(name, lastName, nif, email, userName, password, userType){ }
    }
}
