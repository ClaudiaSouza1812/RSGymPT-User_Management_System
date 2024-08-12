using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices
{
    public interface IUserService
    {
        #region Methods and Functions

        
        string AskUserName();
        string AskUserPassword();
        User ValidateUser(string userName, string password);
        User LogInUser();
        void CreateDefaultUsers();

        #endregion


    }
}
