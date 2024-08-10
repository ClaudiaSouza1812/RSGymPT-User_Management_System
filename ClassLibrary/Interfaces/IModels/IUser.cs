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
        int NextId { get; }
        string Name { get; }
        string LastName { get; }
        string UserName { get; }
        string Password { get; }
        EnumUserType UserType { get; }
    }

    #endregion

}
