using ClassLibrary.Enums;
using ClassLibrary.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public abstract class User : IUser
    {
        #region Scalar Properties

        public int Id { get; }
        public int NextId { get; set; } = 1;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EnumUserType UserType { get; set; }

        #endregion

        #region Bodied-expression properties 3.0
        public string FullName => $"{Name} {LastName}";
        #endregion

        #region Constructors

        public User()
        {
            Id = NextId++;
            Name = string.Empty;
            LastName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            UserType = EnumUserType.SimpleUser;
        }

        public User(string name, string lastName, string userName, string password, EnumUserType userType)
        {
            Name = name;
            LastName = lastName;
            UserName = userName;
            Password = password;
            UserType = userType;
        }

        #endregion

    }
}
