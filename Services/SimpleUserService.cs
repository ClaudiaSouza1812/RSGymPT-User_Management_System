﻿using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Collections.Generic;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services
{
    internal class SimpleUserService : ISimpleUserService
    {
        private readonly IAdminRepository _adminRepository;

        public SimpleUserService(IAdminRepository adminRepository)
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
