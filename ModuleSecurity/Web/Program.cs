using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Business.Interface;
using Business.Implements;
<<<<<<< HEAD
using Data.Implements;
using Data.Interface;
using Bussines.Implements;
using Bussines.Interface;
=======
using Data.Interface;
using Data.Implements;
using Bussines.Interface;
using Bussines.Implements;
>>>>>>> 90d74f609e8c07d10b0c9772d81c5c5d745185e0

var builder = WebApplication.CreateBuilder(args);

// Configura DbContext con MySQL Server
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));

// Agrega los servicios al contenedor de servicios
builder.Services.AddControllers();

// Configura Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de servicios personalizados
builder.Services.AddScoped<ICityBusiness, CityBusiness>();
builder.Services.AddScoped<ICityData, CityData>();

builder.Services.AddScoped<ICountriesBusiness, CountriesBusiness>();
builder.Services.AddScoped<ICountriesData, CountriesData>();

<<<<<<< HEAD
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserData, UserData>();  

builder.Services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();
builder.Services.AddScoped<IUserRoleData, UserRoleData>();

builder.Services.AddScoped<IViewBusiness, ViewBusiness>();
builder.Services.AddScoped<IViewData, ViewData>();

=======
>>>>>>> 90d74f609e8c07d10b0c9772d81c5c5d745185e0
builder.Services.AddScoped<IModuloBusiness, ModuloBusiness>();
builder.Services.AddScoped<IModuloData, ModuloData>();

builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
builder.Services.AddScoped<IPersonData, PersonData>();

builder.Services.AddScoped<IRoleBusiness, RoleBusiness>();
builder.Services.AddScoped<IRoleData, RoleData>();

builder.Services.AddScoped<IRoleViewBusiness, RoleViewBusiness>();
builder.Services.AddScoped<IRoleViewData, RoleViewData>();

builder.Services.AddScoped<IStateBusiness, StateBusiness>();
builder.Services.AddScoped<IStateData, StateData>();

<<<<<<< HEAD
=======
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserData, UserData>();

builder.Services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();
builder.Services.AddScoped<IUserRoleData, UserRoleData>();

builder.Services.AddScoped<IViewBusiness, ViewBusiness>();
builder.Services.AddScoped<IViewData, ViewData>();





>>>>>>> 90d74f609e8c07d10b0c9772d81c5c5d745185e0

var app = builder.Build();

// Configura el pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
