using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Repositories
{
    internal class AdminRepository : IAdminRepository
    {
        public readonly List<User> _users;

        public AdminRepository()
        {
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsersByName(string name)
        {
            return _users.Where(u => u.UserName == name);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
