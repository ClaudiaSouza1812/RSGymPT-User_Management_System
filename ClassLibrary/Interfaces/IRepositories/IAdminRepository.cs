using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.IRepositories
{
    internal interface IAdminRepository
    {
        IEnumerable<User> GetUsersByName(string name);
        User GetUserById(int id);
        void UpdateUser(User user);
        void AddUser(User user);
        List<User> GetAllUsers();
    }
}
