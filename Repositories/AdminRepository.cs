﻿using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;
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
    public class AdminRepository : IAdminRepository 
    {
        private readonly List<User> _users;
        public AdminRepository()
        {
            _users = new List<User>();
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateUser(User user, string propertyName, string newValue)
        {
            User userToUpdate = _users.FirstOrDefault(u => u.Id == user.Id);

            switch (propertyName)
            {
                case "Email":
                    userToUpdate.Email = newValue;
                    break;
                case "Username":
                    userToUpdate.Username = newValue;
                    break;
                case "Password":
                    userToUpdate.Password = newValue;
                    break;
                case "Perfil":
                    userToUpdate.UserProfile = Enum.TryParse(newValue, true, out EnumUserProfile isEnum) ? isEnum : userToUpdate.UserProfile;
                    break;
            }
        }

        public List<User> GetUsersByName(string name)
        {
            return _users.Where(u => u.Name.ToLower() == name.ToLower()).ToList();
        }
    }
}
