using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra1___WebMovil.Src.Interface
{
    public interface IUserRepository
    {
        Task<bool> ExistsByCode(string code);
    }
}