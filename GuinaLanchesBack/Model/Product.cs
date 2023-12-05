using System;
using System.Collections.Generic;

namespace GuinaLanchesBack.Model;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Type { get; set; }

    public double Price { get; set; }

    public double? OffersPrice { get; set; }

    public bool IsOffers { get; set; }

    public virtual ICollection<ProductsRequest> ProductsRequests { get; } = new List<ProductsRequest>();
}
