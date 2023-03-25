using System;
using System.Collections.Generic;

namespace Bookstore.Models;

public partial class TOrderLine
{
    public long FOrderId { get; set; }

    public string FIsbn { get; set; } = null!;

    public long FQuantity { get; set; }

    public double FCostEach { get; set; }

    public string FShipped { get; set; } = null!;

    public virtual TBook FIsbnNavigation { get; set; } = null!;

    public virtual TOrder FOrder { get; set; } = null!;
}
