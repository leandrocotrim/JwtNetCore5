using CrossCutting.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Interfaces.Repositories
{
    public interface IUserRep
    {
        Task<UserResponse> Get(UserRequest user);
    }
}
