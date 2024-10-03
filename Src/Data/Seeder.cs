using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra1___WebMovil.Src.Data
{
    public class Seeder
    {
        public static async Task Seed(DataContext context)
        {
	        if (context.Users.Any())
	        {
		        return;
	        }
	        await context.SaveChangesAsync();
        }

    }

}