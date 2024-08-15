using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices
{
    internal interface IAppService
    {

        void RunRSGymProgram();
        void RunLoginMenu();
        Dictionary<string, string> ShowLoginMenu();
        int GetUserChoice(string chosenMenu);

        string ValidateLoginMenu(Dictionary<string, string> loginMenu, int key);
        (int, string) ValidateMenu(Dictionary<int, string> mainMenu, int menuKey);

        void ShowLogo(string status);
        void ShowMenu(string menu);
        void ShowMainMenu();
        Dictionary<int, string> ShowAdminMainMenu();
        Dictionary<int, string> ShowAdminChangeMenu(User user);
        Dictionary<int, string> ShowPowerUserMainMenu();
        Dictionary<int, string> ShowSimpleUserMainMenu();
        void ShowLogoMessage(string status);

        void RunAdminMainMenu();
        void RunAdminSubmenu(string menuAction);
        void RunAdminChangeMenu(User user);
        void RunAdminChangeSubmenu(string menuAction, User user);
        void RunSearchMenu();
        void RunSearchSubmenu(string menuAction);

        void SearchById();
        void SearchByName();

        // main menus
        void RunMainMenu();
        /*
        void RunAdminMainMenu();
        void RunPowerUserMainMenu();
        void RunSimpleUserMainMenu();
        */
    }
}
