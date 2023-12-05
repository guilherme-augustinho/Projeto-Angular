﻿using System;
using System.Collections.Generic;

namespace GuinaLanchesBack.Model;

public partial class Request
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public double Total { get; set; }

    public bool IsRedy { get; set; }

    public bool IsDelivered { get; set; }

    public virtual ICollection<ProductsRequest> ProductsRequests { get; } = new List<ProductsRequest>();

    public virtual User User { get; set; } = null!;
}
