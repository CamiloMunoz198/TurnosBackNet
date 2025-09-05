using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TurnosBackNet.AD.Repositorios.Entidades;

public partial class Servicios
{
    [Key]
    [Column("id_servicio")]
    public int IdServicio { get; set; }

    [Column("id_comercio")]
    public int? IdComercio { get; set; }

    [Column("nom_servicio")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NomServicio { get; set; }

    [Column("hora_apertura")]
    [Precision(0)]
    public TimeOnly? HoraApertura { get; set; }

    [Column("hora_cierre")]
    [Precision(0)]
    public TimeOnly? HoraCierre { get; set; }

    [Column("duracion")]
    public int? Duracion { get; set; }

    [ForeignKey("IdComercio")]
    [InverseProperty("Servicios")]
    public virtual Comercios? IdComercioNavigation { get; set; }

    [InverseProperty("IdServicioNavigation")]
    public virtual ICollection<Turnos> Turnos { get; set; } = new List<Turnos>();
}
