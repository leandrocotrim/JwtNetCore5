using CrossCutting.DTOs;
using CrossCutting.Interfaces.Repositories;
using Model;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRep : IUserRep
    {
        private static readonly List<User> users = new List<User>
        {
            new User { Id = 1, Password = "jS&3b5-D#p#h1y@!6@9uST38#K4h5M@F@!666T-", Username = "Leandro", Roles = { "A", "B" } },
            new User { Id = 2, Password = "k86Js3m-hpF2_79euU024!avUF&G!tDk", Username = "Macedo",  Roles = { "B", "C" } },
            new User { Id = 3, Password = "R9D#@G##vs!5Kh3-f0@xID4PFg#9RlHh#2rE_3z", Username = "Cotrim",  Roles = { "A", "C" } },
        };

        public Task<UserResponse> Get(UserRequest user)
        {
            return Task.FromResult(users
                .Where(u => u.Username.ToLower() == user.Username?.ToLower() && u.Password.ToLower() == user.Password?.ToLower())
                .Select(u => new UserResponse { Username = u.Username, Roles = u.Roles })
                .FirstOrDefault());
        }
    }
}
