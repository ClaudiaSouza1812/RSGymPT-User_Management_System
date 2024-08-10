using ClassLibrary.Enums;
using ClassLibrary.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class User : IUser
    {
        #region Scalar Properties

        public int Id { get; private set; }
        public int NextId { get; private set; } = 1;
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        #endregion

        internal virtual string FullUser => $"(Id): {Id}\n(Nome): {Name}\n(Nome de utilizador): {UserName}";

        public User() 
        {
            Id = NextId++;
            Name = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
        }

        public User(string name, string userName, string password) : base()
        {
            Name = name;
            UserName = userName;
            Password = password;
        }

    }
}
