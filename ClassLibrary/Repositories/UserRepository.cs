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

       

        public bool CheckUserName(string userName)
        {
            return _users.Any(u => u.UserName == userName);
        }

        public void ListUser(string name)
        {
            Console.Clear();

            RSGymUtility.WriteTitle("Lista de Utilizadores", "\n", "\n\n");

            

            if (users.Any())
            {
                foreach (var user in users)
                {
                    RSGymUtility.WriteMessage($"{user.FullUser}", "\n", "\n");
                }
            }
            else
            {
                RSGymUtility.WriteMessage($"Nenhum utilizador '{name}' encontrado.");
            }

            
            RSGymUtility.PauseConsole();
        }
    }
}
