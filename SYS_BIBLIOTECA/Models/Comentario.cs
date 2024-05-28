using System;
using System.Collections.Generic;

namespace SYS_BIBLIOTECA.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdPublicacion { get; set; }

    public string Comentario1 { get; set; } = null!;

    public virtual Publicacione? IdPublicacionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
