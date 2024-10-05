using Microsoft.EntityFrameworkCore;
using Catedra1___WebMovil.Src.Models;
using Catedra1___WebMovil.Src.Data;
using Catedra1___WebMovil.Src.Repositories;
using Catedra1___WebMovil.Src.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite("Data Source=catedra1.db");
});



builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<DataContext>();

    //Migra la base en caso de no estarlo
	context.Database.Migrate();

    //rellena la base de datos
    Seeder.Initializable(context);
}

app.MapControllers();

app.Run();
