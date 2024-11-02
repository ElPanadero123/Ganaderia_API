using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ganaderia_API.Models;

public partial class CarritoItem
{
    public int Id { get; set; }

    public int CarritoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    [JsonIgnore]
    public virtual Carrito Carrito { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
