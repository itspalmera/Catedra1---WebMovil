using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1___WebMovil.Src.Data;
using Microsoft.EntityFrameworkCore;
using Catedra1___WebMovil.Src.Interface;

namespace Catedra1___WebMovil.Src.Repositories
{
    public class UserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> ExistsByCode(string rut)
        {
            //this._dataContext.Products.Any(p => p.Code == code);
            return await _dataContext.Users.AnyAsync(x => x.Rut == rut);
        }

    }
}