using System;
using System.Collections.Generic;

namespace GestionDeUsuarios.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public int TotalAsignados { get; set; }

    public int Pendientes { get; set; }

    public int AltamenteRelevantes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
