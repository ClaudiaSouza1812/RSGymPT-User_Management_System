using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services
{
    public class AppService : IAppService
    {
        #region Fields
        // For Dependency injection
        private static User _currentUser;
        private User user;
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        private readonly IAdminRepository _adminRepository;
        private readonly IPowerUserService _powerUserService;
        private readonly ISimpleUserService _simpleUserService;
        
        // Set and keep track of the current user
        static string currentUser = UpdateScreenuserProfile();
        #endregion

        #region Constructors
        public AppService() { }

        public AppService(ILoginService loginService, IUserService userService, IAdminService adminService, IAdminRepository adminRepository, IPowerUserService powerUserService, ISimpleUserService simpleUserService)
        {
            _loginService = loginService;
            _userService = userService;
            _adminService = adminService;
            _adminRepository = adminRepository;
            _powerUserService = powerUserService;
            _simpleUserService = simpleUserService;

        }
        #endregion

        public void RunRSGymProgram()
        {
            RunLoginMenu();
        }


        public void RunLoginMenu()
        {
            // Show the login menu
            Dictionary<string, string> loginMenu = ShowLoginMenu();

            string loginAction;
            int loginKey;

            do
            {
                loginKey = GetUserChoice("login");
                loginAction = ValidateLoginMenu(loginMenu, loginKey);

                if (loginAction == "Sair")
                {
                    return;
                }

                if (loginAction == "Login")
                {
                    _currentUser = _loginService.GetLoginCredentials();
                }

            } while (loginAction != "Sair" && _currentUser == null);

            if (_currentUser != null)
            {
                // Show the RSGymPT logo
                ShowLogo("begin");

                // Run the main menu
                RunMainMenu();
            }

        }

        // Function to show and return the login menu
        public Dictionary<string, string> ShowLoginMenu()
        {
            Console.Clear();

            RSGymUtility.WriteLoginTitle("RSGymPT Login Menu", "", "\n\n");
            RSGymUtility.WriteMessage($"Digite o número da opção e aperte 'Enter'", "", "\n\n");

            Dictionary<string, string> loginMenu = new Dictionary<string, string>()
            {
                {"1", "Login" },
                {"2", "Sair" }
            };

            string pad = " ";

            foreach (KeyValuePair<string, string> item in loginMenu)
            {
                RSGymUtility.WriteMessage($"{pad.PadLeft(16, ' ')}({item.Key}) - {item.Value}", "", "\n");
            }
            return loginMenu;
        }

        // Get user menu number choice
        public int GetUserChoice(string chosenMenu)
        {
            int menuNumber;
            bool status;
            do
            {
                Console.Clear();

                ShowMenu(chosenMenu);

                RSGymUtility.WriteMessage("Número: ", "\n", "");
                string answer = Console.ReadLine();

                status = int.TryParse(answer, out menuNumber);

                if (!status)
                {
                    RSGymUtility.WriteMessage("Digite um número válido.", "\n");
                }

            } while (!status);

            return menuNumber;
        }

        public static string UpdateScreenuserProfile()
        {
            if (_currentUser == null)
            {
                return currentUser = "Convidado";
            }
            else
            {
                return currentUser = _currentUser.UserProfile.ToString();
            }

        }

        // Show the chosen menu
        public void ShowMenu(string menu)
        {
            switch (menu)
            {
                case "login":
                    ShowLoginMenu();
                    break;
                case "main":
                    ShowMenuByuserProfile();
                    break;
                case "change":
                    ShowAdminChangeMenu(user);
                    break;
                case "search":
                    ShowSearchMenu();
                    break;
                default:
                    break;
            }
        }

        public void ShowMenuByuserProfile()
        {
            switch (_currentUser.UserProfile)
            {
                case EnumUserProfile.Admin:
                    ShowAdminMainMenu();
                    break;
                case EnumUserProfile.PowerUser:
                    ShowPowerUserMainMenu();
                    break;
                case EnumUserProfile.SimpleUser:
                    ShowSimpleUserMainMenu();
                    break;
                case EnumUserProfile.Convidado:
                    RunLoginMenu();
                    break;
                default:
                    break;
            }
        }

        // Validate the login menu
        public string ValidateLoginMenu(Dictionary<string, string> loginMenu, int key)
        {
            string action;
            bool status;

            status = loginMenu.TryGetValue(key.ToString(), out action);

            if (status)
            {
                return action;
            }

            RSGymUtility.WriteMessage($"Escolha um número válido.", "\n", "\n");

            RSGymUtility.PauseConsole();

            return string.Empty;
        }

        // Show RSGymPT logo
        public void ShowLogo(string status)
        {
            Console.Clear();

            RSGymUtility.WriteTitle("RSGymPT APP", "", "\n\n");

            Console.ForegroundColor = ConsoleColor.Yellow;

            string[] logo =
            {
                "-------------------------------",
                "|  _____    _____   ___       |",
                "| | |   |  |  ___| | _/|      |",
                "| | |___|  | |___  |___|      |",
                "| | |\\\\    |___  |  | |       |",
                "| | | \\\\    ___| |  | |´ ' `\\ |",
                "| |_|  \\\\  |_____|  |_______/ |",
                "|                             |",
                "-------------------------------"
            };

            foreach (string item in logo)
            {
                RSGymUtility.WriteMessage($"{item.PadLeft(23 - 15 + 30, ' ')}\n");
            }
            RSGymUtility.WriteTitle("RSGymPT APP", "\n", "\n\n");
            UpdateScreenuserProfile();
            ShowLogoMessage(status);

            Console.ForegroundColor = ConsoleColor.White;
        }

        // Show RSGymPT logo message
        public void ShowLogoMessage(string status)
        {
            string message01, message02;
            UpdateScreenuserProfile();

            if (_currentUser != null)
            {
                message01 = $"Bem vindo(a)! {_currentUser.Name}!";
                message02 = $"{_currentUser.Name}, até a próxima!";
            }
            else
            {
                message01 = $"Bem vindo(a)! {currentUser}!";
                message02 = $"{currentUser}, até a próxima!";
            }
            

            if (status == "begin")
            {
                RSGymUtility.WriteMessage($"{message01.PadLeft(22 - (message01.Length / 2) + message01.Length, ' ')}", "", "\n\n");

                RSGymUtility.PauseConsole();
            }
            else
            {
                RSGymUtility.WriteMessage($"{message02.PadLeft(22 - (message02.Length / 2) + message02.Length, ' ')}", "", "\n");

                RSGymUtility.PauseConsole();
            }
        }

        public void RunMainMenu()
        {
            switch (_currentUser.UserProfile)
            {
                case EnumUserProfile.Admin:
                    RunAdminMainMenu();
                    break;
                case EnumUserProfile.PowerUser:
                    RunPowerUserMainMenu();
                    break;
                case EnumUserProfile.SimpleUser:
                    RunSimpleUserMainMenu();
                    break;
            }

            RunLoginMenu();
        }

        public void RunAdminMainMenu()
        {
            (int, string) menuAction;
            do
            {
                // Show the main menu
                Dictionary<int, string> adminMainMenu = ShowAdminMainMenu();

                int menuKey;

                // Run the main menu

                menuKey = GetUserChoice("main");
                menuAction = ValidateMenu(adminMainMenu, menuKey);

                if (menuAction.Item2 == "Terminar")
                {
                    ShowLogo("end");
                    break;
                }

                if (!string.IsNullOrEmpty(menuAction.Item2))
                {
                    RunAdminSubmenu(menuAction.Item2);
                    menuAction.Item2 = "Terminar";
                }
                else
                {
                    RSGymUtility.WriteMessage("Digite um numero válido.", "\n", "\n");
                    RSGymUtility.PauseConsole();
                }
            } while (menuAction.Item2 != "Terminar");

        }

        public void RunPowerUserMainMenu()
        {
            (int, string) menuAction;
            do
            {
                // Show the main menu
                Dictionary<int, string> powerUserMainMenu = ShowPowerUserMainMenu();

                int menuKey;


                // Run the main menu

                menuKey = GetUserChoice("main");
                menuAction = ValidateMenu(powerUserMainMenu, menuKey);

                if (menuAction.Item2 == "Terminar")
                {
                    ShowLogo("end");
                    break;
                }

                if (!string.IsNullOrEmpty(menuAction.Item2))
                {
                    if (menuAction.Item2 == "Pesquisar")
                    {
                        SearchByName();
                    }
                    else if (menuAction.Item2 == "Listar")
                    {
                        _powerUserService.ListAllUsers();
                        RSGymUtility.PauseConsole();
                    }
                }
                else
                {
                    RSGymUtility.WriteMessage("Digite um numero válido.", "\n", "\n");
                    RSGymUtility.PauseConsole();
                }
            } while (menuAction.Item2 != "Terminar");
        }

        public void RunSimpleUserMainMenu()
        {
            (int, string) menuAction;
            do
            {
                // Show the main menu
                Dictionary<int, string> simplUserMainMenu = ShowSimpleUserMainMenu();

                int menuKey;

                // Run the main menu

                menuKey = GetUserChoice("main");
                menuAction = ValidateMenu(simplUserMainMenu, menuKey);

                if (menuAction.Item2 == "Terminar")
                {
                    ShowLogo("end");
                    break;
                }

                if (!string.IsNullOrEmpty(menuAction.Item2))
                {
                    _simpleUserService.ListAllUsers();
                    RSGymUtility.PauseConsole();
                }

            } while (menuAction.Item2 != "Terminar");
        }

        // Validate the main menu
        public (int, string) ValidateMenu(Dictionary<int, string> chosenMenu, int menuKey)
        {
            foreach (KeyValuePair<int, string> menu in chosenMenu)
            {
                if (menu.Key == menuKey)
                {
                    return (menu.Key, menu.Value);
                }
            }

            return (-1, string.Empty);
        }

        public Dictionary<int, string> ShowAdminMainMenu()
        {
            Dictionary<int, string> mainMenu;

            Console.Clear();

            RSGymUtility.WriteTitle($"RSGymPT Menu de navegação", "", "\n\n");
            
            mainMenu = new Dictionary<int, string>()
                    {
                        {1, "Registar" },
                        {2, "Alterar" },
                        {3, "Pesquisar" },
                        {4, "Listar" },
                        {5, "Terminar" }
                    };

            string pad = " ";
            foreach (KeyValuePair<int, string> menu in mainMenu)
            {
                RSGymUtility.WriteMessage($"{pad.PadLeft(16, ' ')}({menu.Key}) - {menu.Value}", "", "\n");
            };

            RSGymUtility.WriteTitle($"RSGymPT Menu de navegação", "\n", "\n\n");
            RSGymUtility.WriteMessage($"Digite o número da opção e aperte 'Enter'", "", "\n\n");

            return mainMenu;
        }

        
        // Method to run the admin submenu
        public void RunAdminSubmenu(string menuAction)
        {
            switch (menuAction)
            {
                case "Registar":
                    RunCreateSubmenu();
                    break;
                case "Alterar":
                    RunChangeSubmenu();
                    break;
                case "Pesquisar":
                    RunSearchMenu();
                    RunAdminMainMenu();
                    break;
                case "Listar":
                    RunListSubmenu();
                    RunAdminMainMenu();
                    break;
                case "Terminar":
                    ShowLogo("end");
                    break;
            }
        }

        public void RunCreateSubmenu()
        {
            user = _adminService.CreateUser();
            if (user != null)
            {
                _adminRepository.AddUser(user);
                _adminService.ListUserById(user);
                RSGymUtility.WriteMessage("Utilizador criado com sucesso.", "\n", "\n");
                RSGymUtility.PauseConsole();
                RunAdminMainMenu();
            }
            else
            {
                RSGymUtility.WriteMessage("Nenhum utilizador criado.", "\n", "\n");
                RSGymUtility.PauseConsole();
                RunAdminMainMenu();
            }
        }

        public void RunChangeSubmenu()
        {
            user = _adminService.GetUserToChange();
            if (user != null)
            {
                RunAdminChangeMenu(user);
            }
            else
            {
                RunAdminMainMenu();
            }
        }

        public void RunListSubmenu()
        {
            _adminService.ListAllUsers();
            RSGymUtility.PauseConsole();
        }

        public void RunAdminChangeMenu(User user)
        {
            (int, string) menuAction;
            do
            {
                // Show the admin change menu
                Dictionary<int, string> adminChangeMenu = ShowAdminChangeMenu(user);
                
                int menuKey;
                

                // Run the main menu

                menuKey = GetUserChoice("change");
                menuAction = ValidateMenu(adminChangeMenu, menuKey);

                if (menuAction.Item2 == "Sair")
                {
                    break;
                }

                RunAdminChangeSubmenu(menuAction.Item2, user);

            } while (menuAction.Item2 != "Sair");

            RunAdminMainMenu();
        }

        // Method to run the order submenu
        public void RunAdminChangeSubmenu(string menuAction, User user)
        {
            _adminService.ChangeUser(user, menuAction);
        }

        //HERE***


        public void RunSearchMenu()
        {
            (int, string) menuAction;
            do
            {
                // Show the admin search menu
                Dictionary<int, string> adminSearchMenu = ShowSearchMenu();

                int menuKey;
                
                // Run the main menu

                menuKey = GetUserChoice("search");
                menuAction = ValidateMenu(adminSearchMenu, menuKey);

                if (menuAction.Item2 == "Sair")
                {
                    break;
                }
                else
                {
                    RunSearchSubmenu(menuAction.Item2);
                }
                
            } while (menuAction.Item2 != "Sair");
        }

        // Method to run the order submenu
        public void RunSearchSubmenu(string menuAction)
        {
            if (menuAction == "Id")
            {
                SearchById();
            }
            else if (menuAction == "Nome")
            {
                SearchByName();
            }
        }

        public void SearchById()
        {
            string menu = "Pesquisa";
            User user;
            do
            {
                int id = _adminService.AskUserId(menu);

                if (id > 0)
                {
                    user = _adminRepository.GetUserById(id);

                    if (user != null)
                    {
                        _adminService.ListUserById(user);
                    }
                    else
                    {
                        RSGymUtility.WriteMessage("Id inexistente ou inválido.", "\n", "\n");
                    }
                }
                else
                {
                    RSGymUtility.WriteMessage("Id inexistente ou inválido.", "\n", "\n");
                }
            } while (_adminService.KeepGoing());
        }

        public void SearchByName()
        {
            string menu = "Pesquisa";
            List<User> users;
            do
            {
                string name = _adminService.AskUserName(menu);

                if (!string.IsNullOrEmpty(name))
                {
                    users = _adminRepository.GetUsersByName(name);

                    if (users.Any())
                    {
                        _adminService.ListUsers(users);
                    }
                    else
                    {
                        RSGymUtility.WriteMessage("Utilizador inexistente", "\n", "\n");
                    }
                }
                else
                {
                    RSGymUtility.WriteMessage("Utilizador inexistente", "\n", "\n");
                }
            } while (_adminService.KeepGoing());
        }

        public Dictionary<int, string> ShowSimpleUserMainMenu()
        {
            Dictionary<int, string> mainMenu;

            Console.Clear();

            RSGymUtility.WriteTitle($"RSGymPT Menu de navegação", "", "\n\n");

            mainMenu = new Dictionary<int, string>()
                    {
                        {1, "Listar" },
                        {2, "Terminar" }
                    };

            string pad = " ";
            foreach (KeyValuePair<int, string> menu in mainMenu)
            {
                RSGymUtility.WriteMessage($"{pad.PadLeft(16, ' ')}({menu.Key}) - {menu.Value}", "", "\n");
            };

            RSGymUtility.WriteTitle($"RSGymPT Menu de navegação", "\n", "\n\n");
            RSGymUtility.WriteMessage($"Digite o número da opção e aperte 'Enter'", "", "\n\n");

            return mainMenu;
        }

        public Dictionary<int, string> ShowPowerUserMainMenu()
        {
            Dictionary<int, string> mainMenu;

            Console.Clear();

            RSGymUtility.WriteTitle($"RSGymPT Menu de navegação", "", "\n\n");

            mainMenu = new Dictionary<int, string>()
                    {
                        {1, "Pesquisar" },
                        {2, "Listar" },
                        {3, "Terminar" }
                    };

            string pad = " ";
            foreach (KeyValuePair<int, string> menu in mainMenu)
            {
                RSGymUtility.WriteMessage($"{pad.PadLeft(16, ' ')}({menu.Key}) - {menu.Value}", "", "\n");
            };

            RSGymUtility.WriteTitle($"RSGymPT Menu de navegação", "\n", "\n\n");
            RSGymUtility.WriteMessage($"Digite o número da opção e aperte 'Enter'", "", "\n\n");

            return mainMenu;
        }

        public Dictionary<int, string> ShowAdminChangeMenu(User user)
        {
            Console.Clear();

            RSGymUtility.WriteTitle($"RSGymPT Menu de alteração", "", "\n\n");

            RSGymUtility.WriteMessage("Utilizador:", "", "\n\n");
            _adminService.ListUserToChange(user);

            RSGymUtility.WriteMessage("Digite o número da opção desejada\n alterar e aperte 'Enter'", "\n", "\n\n");

            Dictionary<int, string> changeMenu = new Dictionary<int, string>()
            {
                {1, "Email" },
                {2, "Username" },
                {3, "Password" },
                {4, "Perfil" },
                {5, "Sair" }
            };

            foreach (KeyValuePair<int, string> menu in changeMenu)
            {
                RSGymUtility.WriteMessage($"({menu.Key}) - {menu.Value}", "", "\n");
            }

            return changeMenu;
        }

        public Dictionary<int, string> ShowSearchMenu()
        {
            Console.Clear();

            RSGymUtility.WriteTitle($"RSGymPT Menu - Pesquisar", "", "\n\n");
            RSGymUtility.WriteMessage("Digite o número da opção \ndesejada e aperte 'Enter'", "", "\n\n");

            Dictionary<int, string> searchMenu = new Dictionary<int, string>()
            {
                {1, "Id" },
                {2, "Nome" },
                {3, "Sair" }
            };

            foreach (KeyValuePair<int, string> menu in searchMenu)
            {
                RSGymUtility.WriteMessage($"({menu.Key}) - {menu.Value}", "", "\n");
            }

            return searchMenu;
        }

    }
}
