using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Business.Interface;
using Business.Implements;

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
