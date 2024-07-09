﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public short UnitsInStock { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
