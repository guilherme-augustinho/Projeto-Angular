using System;
using System.Collections.Generic;

namespace GuinaLanchesBack.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsAdm { get; set; }

    public string Salt { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
