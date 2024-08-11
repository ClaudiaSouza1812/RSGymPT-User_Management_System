using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.IServices
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
