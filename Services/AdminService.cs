using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Repositories;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services
{
    internal class AdminService : IAdminService
    {
        public readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        { 
            _adminRepository = adminRepository;
        }


        public User CreateUser()
        {
            User user = new User();

            (user.Name, user.LastName) = DefineFullName();

            if (string.IsNullOrEmpty(user.Name))
            {
                return null;
            }
            

            user.NIF = DefineNif();

            if (string.IsNullOrEmpty(user.NIF))
            {
                return null;
            }

            user.Email = DefineEmail();

            if (string.IsNullOrEmpty(user.Email))
            {
                return null;
            }

            user.Username = DefineUsername();

            if (string.IsNullOrEmpty(user.Username))
            {
                return null;
            }

            user.Password = DefinePassword();

            if (string.IsNullOrEmpty(user.Password))
            {
                return null;
            }

            return user;
        }

        

        

        internal (bool, int) CheckInt(string answer)
        {
            int userId = 0;
            bool isNumber;

            isNumber = int.TryParse(answer, out userId);

            return (isNumber, userId);
        }


        public void ListAllUsers()
        {
            foreach (var user in _adminRepository.GetAllUsers())
            {
                RSGymUtility.WriteMessage($"{user.FullUser}", "\n", "\n");
            }
        }

        public void ListUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void ListUsersByName(string name)
        {
            throw new NotImplementedException();
        }

        public (string, string) DefineFullName()
        {
            string name, lastName;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                RSGymUtility.WriteMessage("Insira o nome do utilizador: ", "", "\n");

                name = Console.ReadLine().ToLower();

                RSGymUtility.WriteMessage("Insira o sobrenome do utilizador: ", "", "\n");

                lastName = Console.ReadLine().ToLower();

                if (!CheckFullName(name, lastName))
                {
                    RSGymUtility.WriteMessage("Nome vazio, com espaço ou com caracteres inválidos", "", "\n");
                }
                else
                {
                    return (char.ToUpper(name[0]) + name.Substring(1), char.ToUpper(lastName[0]) + lastName.Substring(1));
                }

            } while (KeepGoing());
            
            return (string.Empty, string.Empty);
        }

        public bool CheckFullName(string name, string lastName)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            if (name.Any(c => char.IsDigit(c) || !char.IsLetter(c)) || lastName.Any(c => char.IsDigit(c) || !char.IsLetter(c)))
            {
                return false;
            }
            return true;
        }

        
        public string DefineNif()
        {
            string nif;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                RSGymUtility.WriteMessage("Insira o NIF do utilizador com 9 números: ", "", "\n");

                string answer = Console.ReadLine().ToLower();

                bool isNumber = int.TryParse(answer, out int _);

                if (!isNumber || answer.Length != 9)
                {
                    RSGymUtility.WriteMessage("Digite um NIF válido.", "\n");
                }
                else
                {
                    nif = answer;
                    return nif;
                }

            } while (KeepGoing());

            return string.Empty;
        }

        public string DefineEmail()
        {
            string email;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                RSGymUtility.WriteMessage("Exemplo de email válido: teste@teste.com", "", "\n");

                RSGymUtility.WriteMessage("Insira o email do utilizador: ", "\n", "\n");

                email = Console.ReadLine().ToLower();

                if (!CheckEmail(email))
                {
                    RSGymUtility.WriteMessage("Insira um email válido", "", "\n");
                }
                else
                {
                    return email;
                }

            } while (KeepGoing());

            return string.Empty;
        }

        public bool CheckEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            return true;
        }

        public string DefineUsername()
        {
            string userName;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                RSGymUtility.WriteMessage("Defina o username com 6 caracteres e sem espaços.", "\n", "\n");

                RSGymUtility.WriteMessage("Username: ", "", "\n");

                userName = Console.ReadLine().ToLower();

                if (!CheckUsername(userName))
                {
                    RSGymUtility.WriteMessage("Digite um username válido.", "\n");
                }
                else
                {
                    return userName;
                }

            } while (KeepGoing());

            return string.Empty;
        }

        public string DefinePassword()
        {
            string password;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                RSGymUtility.WriteMessage("Defina a password com 6 caracteres e sem espaços.", "\n", "\n");

                RSGymUtility.WriteMessage("Password: ", "", "\n");

                password = Console.ReadLine().ToLower();


                if (!CheckPassword(password))
                {
                    RSGymUtility.WriteMessage("Digite uma password válida.", "\n");
                }
                else
                {
                    return password;
                }

            } while (KeepGoing());

            return string.Empty;
        }

        public EnumUserType DefineUserType()
        {
            EnumUserType userType = new EnumUserType();
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                foreach (EnumUserType type in Enum.GetValues(typeof(EnumUserType)))
                {
                    RSGymUtility.WriteMessage($"({(int)type}) - ({type})", "", "\n");
                }

                RSGymUtility.WriteMessage("Digite um dos numeros de tipo de usuário acima.", "\n", "\n");

                RSGymUtility.WriteMessage("Numero do usuário: ", "", "\n");

                string answer = Console.ReadLine().ToLower();

                bool isNumber = int.TryParse(answer, out int number);

                if (isNumber && Enum.IsDefined(typeof(EnumUserType), number))
                {
                    userType = (EnumUserType)number;
                    break;
                }
                else
                {
                    RSGymUtility.WriteMessage("Entrada inválida.", "\n");
                }

            } while (KeepGoing());

            return userType;
        }

        public bool CheckUsername(string userName)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName) || userName.Length != 6)
            {
                return false;
            }
            return true;
        }

        public bool CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password) || password.Length != 6)
            {
                return false;
            }
            return true;
        }

        // Function to ask and return the user choice
        public bool KeepGoing()
        {
            RSGymUtility.WriteMessage("Continuar? (s/n): ", "\n");

            string answer = Console.ReadLine().ToLower();

            if (answer == "s")
            {
                return true;
            }
            if (answer == "n")
            {
                return false;
            }
            return true;
        }

        // Admin service helper function to ask and return the user Id
        internal int AskUserId()
        {
            bool isNumber;
            int userId = 0;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"Alterar", "", "\n\n");

                ListAllUsers();

                RSGymUtility.WriteMessage("Digite o Id do utilizador que deseja alterar: ", "\n\n", "");
                string answer = Console.ReadLine();

                if (string.IsNullOrEmpty(answer))
                {
                    break;
                }

                (isNumber, userId) = CheckInt(answer);

            } while (!isNumber || userId == 0);

            return userId;
        }

        public User GetUserToChange()
        {
            User user = new User();

            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"Alterar", "", "\n\n");

                int userId = AskUserId();

                user = _adminRepository.GetUserById(userId);

                if (user != null)
                {
                    return user;
                }

                RSGymUtility.WriteMessage("Usuário Inexistente", "", "\n");

            } while (KeepGoing());

            return null;
        }

        public void ChangeUser(User user, string property)
        {
            switch (property)
            {
                case "Email":
                    user.Email = DefineEmail();

                    if (user.Email != string.Empty)
                    {
                        _adminRepository.UpdateUser(user, property, user.Email);
                        RSGymUtility.WriteMessage("Email alterado com sucesso.", "\n", "\n");
                    }
                    else
                    {
                        RSGymUtility.WriteMessage("Nenhum alteração aplicada.", "\n", "\n");
                    }
                    break;
                case "Username":
                    user.Username = DefineUsername();

                    if (user.Username != string.Empty)
                    {
                        _adminRepository.UpdateUser(user, property, user.Username);
                    }
                    break;
                case "Password":
                    user.Password = DefinePassword();

                    if (user.Password != string.Empty)
                    {
                        _adminRepository.UpdateUser(user, property, user.Password);
                    }
                    break;
                case "Perfil":
                    user.UserType = DefineUserType();
                    _adminRepository.UpdateUser(user, property, user.UserType.ToString());
                    
                    break;
                default:
                    break;
            }
            
        }
    }
}
