using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly IAdminRepository _adminRepository;

        public UserRepository(IAdminRepository adminRepository)
        { 
            _adminRepository = adminRepository;
        }

        RSGymUtility rSGymUtility = new RSGymUtility();

        public bool CheckUserName(string userName)
        {
            return _adminRepository.GetAllUsers().Any(u => u.Username == userName);
        }

        
        public void ListUser(string name)
        {
            Console.Clear();

            rSGymUtility.WriteTitle("Lista de Utilizadores", "\n", "\n\n");

            

            if (_adminRepository.GetAllUsers().Any())
            {
                foreach (var user in _adminRepository.GetAllUsers())
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

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }



    }
}
