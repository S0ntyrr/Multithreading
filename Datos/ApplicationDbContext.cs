using ERPEmpleados.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPEmpleados.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
}
