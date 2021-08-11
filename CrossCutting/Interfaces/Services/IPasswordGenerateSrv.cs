using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Interfaces.Services
{
    public interface IPasswordGenerateSrv
    {
        Task<string> Generate();
    }
}
