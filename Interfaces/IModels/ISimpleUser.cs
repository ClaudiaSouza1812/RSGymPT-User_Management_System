using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IModels
{
    internal interface ISimpleUser : IUser
    {
        void ListAllUsers();
    }
}
