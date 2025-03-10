﻿using System;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models
{
    internal class SimpleUser : User, ISimpleUser
    {
        public override EnumUserProfile UserProfile { get; set; }

        public SimpleUser() : base() { }

        public SimpleUser(string name, string lastName, string nif, string email, string userName, string password, EnumUserProfile userProfile) : base(name, lastName, nif, email, userName, password, userProfile) { }
    }
}
