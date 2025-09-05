using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TurnosBackNet.AD.Repositorios.Entidades;

public partial class Comercios
{
    [Key]
    [Column("id_comercio")]
    public int IdComercio { get; set; }

    [Column("nom_comercio")]
    [StringLength(100)]
    [Unicode(false)]
    public string? NomComercio { get; set; }

    [Column("aforo_maximo")]
    public int? AforoMaximo { get; set; }

    [InverseProperty("IdComercioNavigation")]
    public virtual ICollection<Servicios> Servicios { get; set; } = new List<Servicios>();
}
