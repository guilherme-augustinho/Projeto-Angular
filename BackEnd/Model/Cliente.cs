using System;
using System.Collections.Generic;

namespace BackEnd.Model;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime DataNasc { get; set; }
}
