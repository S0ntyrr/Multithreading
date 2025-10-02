using ERPEmpleados.Data;
using ERPEmpleados.Models;
using ERPEmpleados.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPEmpleados.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpleadosController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ProcesadorEmpleadosService _procesador;

    public EmpleadosController(ApplicationDbContext context, ProcesadorEmpleadosService procesador)
    {
        _context = context;
        _procesador = procesador;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
    {
        return await _context.Empleados.Include(e => e.Cargo).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var cargo = await _context.Cargos.FindAsync(empleado.CargoId);
            if (cargo == null) return BadRequest("El cargo especificado no existe.");

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            Console.WriteLine($"AUDITORÍA: Se ha creado el empleado {empleado.Nombre}");

            await transaction.CommitAsync();
            return CreatedAtAction(nameof(GetEmpleados), new { id = empleado.Id }, empleado);
        }
        catch
        {
            await transaction.RollbackAsync();
            return StatusCode(500, "Ocurrió un error al crear el empleado.");
        }
    }

    [HttpPost("cargamasiva")]
    public IActionResult CargaMasivaEmpleados([FromBody] List<Empleado> empleados)
    {
        if (empleados == null || !empleados.Any())
            return BadRequest("La lista de empleados no puede estar vacía.");

        _procesador.ProcesarCargaMasiva(empleados);
        return Ok("El proceso de carga masiva ha comenzado en segundo plano.");
    }
}
