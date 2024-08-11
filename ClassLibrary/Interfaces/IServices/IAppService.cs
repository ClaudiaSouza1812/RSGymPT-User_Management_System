using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.IServices
{
    internal interface IAppService
    {
        void RunRSGymProgram();
        void RunLoginMenu();
        Dictionary<string, string> ShowLoginMenu();
        int GetUserChoice(string chosenMenu, string userName);
        string ValidateLoginMenu(Dictionary<string, string> loginMenu, int key);
        void ShowLogo(string status, string userName);
        void ShowMenu(string menu, string userName);
        Dictionary<string, Dictionary<string, string>> ShowMainMenu(string userName);
        void ShowLogoMessage(string status, string userName);

        // main menus
        void RunMainMenu();
        /*
        void RunAdminMainMenu();
        void RunPowerUserMainMenu();
        void RunSimpleUserMainMenu();
        */
    }
}
