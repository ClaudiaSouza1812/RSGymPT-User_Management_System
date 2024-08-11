using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Enums;

namespace ClassLibrary.Interfaces.IModels
{
    #region Scalar Properties

    public interface IUser
    {
        int Id { get; }
        string Name { get; }
        string NIF { get; }
        string Email { get; }
        string UserName { get; }
        string Password { get; }
        
    }

    #endregion

}
