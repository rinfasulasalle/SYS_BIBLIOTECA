using System;
using System.Collections.Generic;

namespace SYS_BIBLIOTECA.Models;

public partial class Publicacione
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public string Titulo { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public string? Imagen { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
