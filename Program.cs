using ERPEmpleados.Data;
using ERPEmpleados.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar DbContext con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar servicios
builder.Services.AddScoped<ProcesadorEmpleadosService>();

// Agregar controladores
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
