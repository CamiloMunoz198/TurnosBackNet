using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TurnosBackNet.AD.Repositorios.Entidades;

public partial class Turnos
{
    [Key]
    [Column("id_turno")]
    public int IdTurno { get; set; }

    [Column("id_servicio")]
    public int? IdServicio { get; set; }

    [Column("fecha_turno")]
    public DateOnly? FechaTurno { get; set; }

    [Column("hora_inicio")]
    [Precision(0)]
    public TimeOnly? HoraInicio { get; set; }

    [Column("hora_fin")]
    [Precision(0)]
    public TimeOnly? HoraFin { get; set; }

    [Column("estado")]
    public bool? Estado { get; set; }

    [ForeignKey("IdServicio")]
    [InverseProperty("Turnos")]
    public virtual Servicios? IdServicioNavigation { get; set; }
}
