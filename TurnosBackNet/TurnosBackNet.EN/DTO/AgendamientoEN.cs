using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnosBackNet.EN.DTO
{
    public class AgendamientoEN
    {
    public DateOnly FechaInicio { get; set; }
	public DateOnly FechaFin    { get; set; }
	public int IdServicio { get; set; }
    }
}
