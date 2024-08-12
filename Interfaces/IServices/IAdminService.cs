using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices
{
    internal interface IAdminService
    {
        User CreateUser();
        void ChangeUser();
        (string, string) DefineFullName();
        bool CheckFullName(string name, string lastName);
        string DefineNif();
        string DefineEmail();
        bool CheckEmail(string email);
        (string, string) DefineFullAccess();
        bool CheckUserName(string userName);
        bool CheckPassword(string password);

        bool KeepGoing();

        void ListUsersByName(string name);
        void ListUserById(int id);
        void ListAllUsers();
    }
}
