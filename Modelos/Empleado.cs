namespace ERPEmpleados.Models;

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Documento { get; set; }
    public DateTime FechaContratacion { get; set; }
    public decimal Salario { get; set; }

    public int CargoId { get; set; }
    public Cargo Cargo { get; set; }
}
