using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories
{
    public interface IAdminRepository
    {
        IEnumerable<User> GetUsersByName(string name);
        User GetUserById(int id);
        void UpdateUser(User user, string propertyName, string newValue);
        void AddUser(User user);
        List<User> GetAllUsers();
    }
}
