

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnosBackNet.EN.DTO
{
    public class CreacionTurnosEN
    {

        public int IdTurno { get; set; }

        public int? IdServicio { get; set; }

        public DateOnly? FechaTurno { get; set; }

        public TimeOnly? HoraInicio { get; set; }

        public TimeOnly? HoraFin { get; set; }
        public bool? Estado { get; set; }
    }
    }
