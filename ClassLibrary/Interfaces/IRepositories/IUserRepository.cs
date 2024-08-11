using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.IRepositories
{
    internal interface IUserRepository
    {
        #region Methods and Functions

        bool CheckUserName(string userName);
        List<User> GetAllUsers();
        

        #endregion
    }
}
