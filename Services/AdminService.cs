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
using System.Xml.Linq;

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
            string menu = "Definição";
            string name, lastName;

            (name, lastName) = DefineFullName(menu);

            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            
            string nif = DefineNif();

            if (string.IsNullOrEmpty(nif))
            {
                return null;
            }

            string email = DefineEmail();

            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            string username = DefineUsername();

            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            string password = DefinePassword();

            if (string.IsNullOrEmpty(password))
            {
                return null;
            }

            EnumUserType userType = DefineUserType();

            User user = new User()
            {
                Name = name,
                LastName = lastName,
                NIF = nif,
                Email = email,
                Username = username,
                Password = password,
                UserType = userType
            };

            return user;
        }

        public (string, string) DefineFullName(string menu)
        {
            string name, lastName;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                name = AskUserName(menu);

                if (!CheckName(name))
                {
                    RSGymUtility.WriteMessage("Nome vazio, com espaço ou com caracteres inválidos.", "", "\n");
                }
                else
                {
                    lastName = AskUserLastName(menu);

                    if (!CheckName(lastName))
                    {
                        RSGymUtility.WriteMessage("Nome vazio, com espaço ou com caracteres inválidos.", "", "\n");
                    }
                    else
                    {
                        return (char.ToUpper(name[0]) + name.Substring(1), char.ToUpper(lastName[0]) + lastName.Substring(1));
                    }
                }
            } while (KeepGoing());

            return (string.Empty, string.Empty);
        }

        public string AskUserName(string menu)
        {
            Console.Clear();

            RSGymUtility.WriteTitle($"RSGymPT Menu - {menu}", "", "\n\n");

            RSGymUtility.WriteMessage("Insira o primeiro nome do utilizador: ", "\n", "");

            string name = Console.ReadLine().ToLower();
            return name;
        }

        public string AskUserLastName(string menu)
        {
            Console.Clear();

            RSGymUtility.WriteTitle($"RSGymPT Menu - {menu}", "", "\n\n");

            RSGymUtility.WriteMessage("Insira o sobrenome do utilizador: ", "\n", "");

            string lastName = Console.ReadLine().ToLower();
            return lastName;
        }

        public bool CheckName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            if (name.Any(c => char.IsDigit(c) || !char.IsLetter(c)))
            {
                return false;
            }
            return true;
        }

        public string DefineNif()
        {
            string nif;
            User user;
            bool isValid;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                RSGymUtility.WriteMessage("Insira o NIF do utilizador com 9 números: ", "\n", "");

                string answer = Console.ReadLine();

                bool isNumber = int.TryParse(answer, out int _);

                if (!isNumber || answer.Length != 9)
                {
                    RSGymUtility.WriteMessage("Digite um NIF válido.", "\n");
                }
                else
                {
                    (isValid, user) = CheckNif(answer);

                    if (isValid)
                    {
                        nif = answer;
                        return nif;
                    }
                    else
                    {
                        RSGymUtility.WriteMessage($"NIF já cadastrado para utilizador {user.FullName}, (Id): {user.Id}.", "\n", "\n");
                    }
                }

            } while (KeepGoing());

            return string.Empty;
        }

        public (bool, User) CheckNif(string nif)
        {
            List<User> users = _adminRepository.GetAllUsers();

            foreach (var user in users)
            {
                if (user.NIF == nif)
                {
                    return (false, user);
                }
            }
            return (true, null);
        }

        public string DefineEmail()
        {
            string email;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                RSGymUtility.WriteMessage("Exemplo de email válido: teste@teste.com", "", "\n");

                RSGymUtility.WriteMessage("Insira o email do utilizador: ", "\n", "");

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

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]{2,3}$";

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

                RSGymUtility.WriteMessage("Defina o username com 6 caracteres e sem espaços.", "", "\n");

                RSGymUtility.WriteMessage("Username: ", "\n", "");

                userName = Console.ReadLine().ToLower();

                if (!CheckUsername(userName))
                {
                    RSGymUtility.WriteMessage("Digite um username válido.", "", "\n");
                }
                else
                {
                    return userName;
                }

            } while (KeepGoing());

            return string.Empty;
        }

        public bool CheckUsername(string userName)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName) || userName.Length != 6)
            {
                return false;
            }
            return true;
        }

        public string DefinePassword()
        {
            string password;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                RSGymUtility.WriteMessage("Defina a password com 6 caracteres e sem espaços.", "", "\n");

                RSGymUtility.WriteMessage("Password: ", "\n", "");

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

        public User GetUserToChange()
        {
            User user = null;
            bool isNumber;
            int userId = 0;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"Alterar", "", "\n\n");

                ListAllUsers();

                RSGymUtility.WriteMessage("Digite o Id do utilizador que deseja alterar: ", "\n", "");
                string answer = Console.ReadLine();

                if (!string.IsNullOrEmpty(answer))
                {
                    (isNumber, userId) = CheckInt(answer);
                }

                if (userId > 0)
                {
                    user = _adminRepository.GetUserById(userId);
                }

                if (user != null)
                {
                    return user;
                }

                RSGymUtility.WriteMessage("Usuário Inexistente.", "", "\n");

            } while (KeepGoing());

            return null;
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

        // Admin service helper function to ask and return the user Id

        public int AskUserId(string menu)
        {
            int userId = 0;
            bool isNumber;

            Console.Clear();

            RSGymUtility.WriteTitle($"RSGymPT Menu - {menu}", "", "\n\n");

            RSGymUtility.WriteMessage("Digite o Id do utilizador: ", "\n", "");
            string answer = Console.ReadLine();

            if (!string.IsNullOrEmpty(answer))
            {
                (isNumber, userId) = CheckInt(answer);
            }

            return userId;
        }

        public (bool, int) CheckInt(string answer)
        {
            int userId = 0;
            bool isNumber;

            isNumber = int.TryParse(answer, out userId);

            return (isNumber, userId);
        }

        public void ChangeUser(User user, string property)
        {
            switch (property)
            {
                case "Email":
                    string email = DefineEmail();

                    if (email != string.Empty && email != user.Email)
                    {
                        _adminRepository.UpdateUser(user, property, email);
                        RSGymUtility.WriteMessage("Email alterado com sucesso.", "\n", "\n");
                        RSGymUtility.PauseConsole();
                    }
                    else
                    {
                        RSGymUtility.WriteMessage("Nenhum alteração aplicada, campo vazio ou email existente.", "\n", "\n");
                        RSGymUtility.PauseConsole();
                    }
                    break;
                case "Username":
                    string username = DefineUsername();

                    if (username != string.Empty && username != user.Username)
                    {
                        _adminRepository.UpdateUser(user, property, username);
                        RSGymUtility.WriteMessage("Username alterado com sucesso.", "\n", "\n");
                        RSGymUtility.PauseConsole();
                    }
                    else
                    {
                        RSGymUtility.WriteMessage("Nenhum alteração aplicada, campo vazio ou username existente.", "\n", "\n");
                        RSGymUtility.PauseConsole();
                    }
                    break;
                case "Password":
                    string password = DefinePassword();

                    if (password != string.Empty && password != user.Password)
                    {
                        _adminRepository.UpdateUser(user, property, password);
                        RSGymUtility.WriteMessage("Password alterado com sucesso.", "\n", "\n");
                        RSGymUtility.PauseConsole();
                    }
                    else
                    {
                        RSGymUtility.WriteMessage("Nenhum alteração aplicada, campo vazio ou password existente.", "\n", "\n");
                        RSGymUtility.PauseConsole();
                    }
                    break;
                case "Perfil":
                    EnumUserType userType = DefineUserType();
                    if (userType != EnumUserType.Convidado && userType != user.UserType)
                    {
                        _adminRepository.UpdateUser(user, property, userType.ToString());
                        RSGymUtility.WriteMessage("Tipo de usuário alterado com sucesso.", "\n", "\n");
                        RSGymUtility.PauseConsole();
                    }
                    else
                    {
                        RSGymUtility.WriteMessage("Nenhum alteração aplicada, campo vazio ou perfil existente.", "\n", "\n");
                        RSGymUtility.PauseConsole();
                    }
                    break;
            }
        }


        public EnumUserType DefineUserType()
        {
            EnumUserType userType = EnumUserType.Convidado;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu - Definição", "", "\n\n");

                foreach (EnumUserType type in Enum.GetValues(typeof(EnumUserType)))
                {
                    if ((int)type > 2)
                    {
                        break;
                    }
                    RSGymUtility.WriteMessage($"({(int)type}) - ({type})", "", "\n");
                }

                RSGymUtility.WriteMessage("Digite um dos numeros de tipo de usuário acima.", "\n", "\n");

                RSGymUtility.WriteMessage("Numero do usuário: ", "\n", "");

                string answer = Console.ReadLine();

                bool isNumber = int.TryParse(answer, out int number);

                if (isNumber && Enum.IsDefined(typeof(EnumUserType), number))
                {
                    return userType = (EnumUserType)number;
                }
                else
                {
                    RSGymUtility.WriteMessage("Entrada inválida.", "\n");
                }

            } while (KeepGoing());

            return userType;
        }


        //HERE***


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
            RSGymUtility.WriteMessage("Continuar? (s/n): ", "\n", "");

            string answer = Console.ReadLine().ToLower();

            if (answer == "s")
            {
                return true;
            }
            if (answer == "n")
            {
                return false;
            }
            return false;
        }

        

        
        

        

       

        public void ListUserById(User user)
        {
            Console.Clear();

            RSGymUtility.WriteTitle("Lista de Utilizadores por id", "", "\n\n");

            RSGymUtility.WriteMessage($"{user.FullUser}", "", "\n");
        }

        public void ListUsers(List<User> users)
        {
            Console.Clear();

            RSGymUtility.WriteTitle("Lista de Utilizadores", "", "\n\n");

            foreach (var user in users)
            {
                RSGymUtility.WriteMessage($"{user.FullUser}", "", "\n");
            }   
        }

        public void ListUserToChange(User user)
        {
            RSGymUtility.WriteMessage($"{user.FullUser}", "", "\n");
        }
    }
}
