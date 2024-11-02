using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ganaderia_API.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Ciudad { get; set; }

    public int RolId { get; set; }

    public DateTime FechaCreacion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Animale> Animales { get; set; } = new List<Animale>();

    [JsonIgnore]
    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();
    [JsonIgnore]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    [JsonIgnore]
    public virtual ICollection<Remate> Remates { get; set; } = new List<Remate>();

    public virtual Rol Rol { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
