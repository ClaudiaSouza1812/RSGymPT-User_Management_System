using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.IServices
{
    public interface IUserService
    {
        #region Methods and Functions

        
        string AskUserName();
        string AskUserPassword();
        User ValidateUser(string userName, string password);
        User LogInUser();
        List<User> CreateDefaultUsers();

        #endregion


    }
}
