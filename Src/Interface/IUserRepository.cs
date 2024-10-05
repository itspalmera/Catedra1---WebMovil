using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1___WebMovil.Src.Models;

namespace Catedra1___WebMovil.Src.Interface
{
    public interface IUserRepository
    {
        Task<bool> ExistsByCode(string code);
        Task<User> AddUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync(string? sort, string? gender);
        Task DeleteUserAsync(User user);
    }
}