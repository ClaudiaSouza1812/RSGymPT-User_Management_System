﻿using ClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.IModels
{
    internal interface IAdminUser : IUser
    {
        EnumUserType UserType { get; }
    }
}
