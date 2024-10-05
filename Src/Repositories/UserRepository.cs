using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1___WebMovil.Src.Data;
using Microsoft.EntityFrameworkCore;
using Catedra1___WebMovil.Src.Interface;
using Catedra1___WebMovil.Src.Models;

namespace Catedra1___WebMovil.Src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> ExistsByCode(string rut)
        {
            //this._dataContext.Products.Any(p => p.Code == code);
            return await _dataContext.Users.AnyAsync(x => x.Rut == rut);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _dataContext.Users.FindAsync(id);
        }
        public async Task<List<User>> GetAllUsersAsync(string? sort, string? gender){
            var query = _dataContext.Users.AsQueryable();

            // Filtrar por género si se especifica
            if (!string.IsNullOrEmpty(gender))
            {
                query = query.Where(u => u.Gender == gender);
            }

            // Ordenar por nombre si se especifica "asc" o "desc"
            if (!string.IsNullOrEmpty(sort))
            {
                if (sort == "asc")
                {
                    query = query.OrderBy(u => u.Name);
                }
                else if (sort == "desc")
                {
                    query = query.OrderByDescending(u => u.Name);
                }
            }

            return await query.ToListAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();
        }


        
    }
}