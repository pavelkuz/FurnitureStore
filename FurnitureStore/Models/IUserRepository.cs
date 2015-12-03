using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStore.Models
{
    interface IUserRepository
    {
        List<User> GetAllUsers();

        void Save(User User);

        User GetUserById(Guid id);

        void RemoveUserById(Guid id);

        void UpdateUser(User user);

        User Login(string login, string password);
    }
}
