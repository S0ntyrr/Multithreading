using ERPEmpleados.Data;
using ERPEmpleados.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ERPEmpleados.Services;

public class ProcesadorEmpleadosService
{
    private readonly IServiceProvider _serviceProvider;

    public ProcesadorEmpleadosService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void ProcesarCargaMasiva(List<Empleado> empleadosAProcesar)
    {
        Thread hiloDeProceso = new(() =>
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            using var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var empleado in empleadosAProcesar)
                {
                    context.Empleados.Add(empleado);
                    Console.WriteLine($"Procesando en hilo secundario: {empleado.Nombre}");
                    Thread.Sleep(100);
                }

                context.SaveChanges();
                transaction.Commit();
                Console.WriteLine("¡Carga masiva completada exitosamente en hilo secundario!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($"Error en la carga masiva: {ex.Message}");
            }
        });

        hiloDeProceso.Start();
 
    }
}
