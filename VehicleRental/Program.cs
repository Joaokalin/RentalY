using VehicleRental.Infrastructure;
using VehicleRental.Models.Contracts;
using VehicleRental.Models.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

services.AddControllers();

services.Configure<MongoDBOptions>(options => options.DatabaseName = builder.Configuration["Database:DatabaseMongo"]);
services.Configure<MongoDBOptions>(options => options.ConnnectionString = builder.Configuration["Database:ConnectionStringMongo"]);

services.AddTransient<IVehicleService, VehicleService>();
services.AddTransient<IEstablishmentService, EstablishmentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseAuthorization();

app.MapControllers();

app.Run();
