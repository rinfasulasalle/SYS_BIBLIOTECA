using System;
using System.Collections.Generic;

namespace SYS_BIBLIOTECA.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Publicacione> Publicaciones { get; set; } = new List<Publicacione>();
}
