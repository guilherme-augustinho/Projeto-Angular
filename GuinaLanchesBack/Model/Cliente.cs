using System;
using System.Collections.Generic;

namespace GuinaLanchesBack.Model;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Salt { get; set; } = null!;
}
