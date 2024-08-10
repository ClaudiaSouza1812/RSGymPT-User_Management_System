using ClassLibrary.Interfaces.IRepositories;
using ClassLibrary.Models;
using ClassLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public bool CheckUserName(string userName)
        {
            return _users.Any(u => u.UserName == userName);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public void ListUser(string userName)
        {
            Console.Clear();

            RSGymUtility.WriteTitle("Lista de Utilizadores", "\n", "\n\n");
            RSGymUtility.WriteMessage($"{userName}, Utilizadores cadastrados: ", "", "\n\n");

            foreach (User user in _users)
            {
                RSGymUtility.WriteMessage($"{user.FullUser}", "\n", "\n");
            }
            RSGymUtility.PauseConsole();
        }
    }
}
