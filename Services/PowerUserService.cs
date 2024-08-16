using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services
{
    internal class PowerUserService : IPowerUserService
    {
        private readonly IAdminRepository _adminRepository;

        public PowerUserService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public void ListAllUsers()
        {
            Console.Clear();

            RSGymUtility.WriteTitle("Lista de Utilizadores", "", "\n");

            List<User> users = _adminRepository.GetAllUsers();

            foreach (var user in users)
            {
                RSGymUtility.WriteMessage($"{user.FullUser}", "\n", "\n");
            }
        }
    }
}
