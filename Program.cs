using Microsoft.EntityFrameworkCore;
using Catedra1___WebMovil.Src.Models;
using Catedra1___WebMovil.Src.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite("Data Source=catedra1.db");
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<DataContext>();

    //Migra la base en caso de no estarlo
	await context.Database.MigrateAsync();

    //rellena la base de datos
    await Seeder.Seed(context);
}

app.MapControllers();

app.Run();
