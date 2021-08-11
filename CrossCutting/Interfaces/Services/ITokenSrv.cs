using CrossCutting.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Interfaces.Services
{
    public interface ITokenSrv
    {
        Task<string> Generate(UserResponse user);
    }
}
