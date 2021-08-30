using Lab.Jwt.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Jwt.API.Repositories
{
    public static class UserRepository
    {
        public static User Get(string userName, string password)
        {
            var users = new List<User>
            {
                new User("ebenedicto", "ebenedicto123", "developer"),
                new User("admin", "admin123", "administrator")
            };

            return users.FirstOrDefault(x => x.UserName.ToLower() == userName && x.Password == password);
        }
    }
}