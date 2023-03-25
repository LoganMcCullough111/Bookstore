using System;
using System.Collections.Generic;

namespace Bookstore.Models;

public partial class TOrder
{
    public long FOrderId { get; set; }

    public long FCustId { get; set; }

    public string FOrderDate { get; set; } = null!;

    public string FCreditCardNum { get; set; } = null!;

    public string FCreditCardExpDate { get; set; } = null!;

    public string? FOrderFilled { get; set; }

    public virtual TCustomer FCust { get; set; } = null!;

    public virtual ICollection<TOrderLine> TOrderLines { get; } = new List<TOrderLine>();
}
