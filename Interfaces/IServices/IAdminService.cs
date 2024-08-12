using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices
{
    internal interface IAdminService
    {
        User CreateUser();
        void DefineUserType(User user);
        void ListUsersByName(string name);
        void ListUserById(int id);
        void ListAllUsers();
    }
}
