using System;
using System.Collections.Generic;

namespace Bookstore.Models;

public partial class TCustomer
{
    public long FCustId { get; set; }

    public string FCustFirstName { get; set; } = null!;

    public string FCustLastName { get; set; } = null!;

    public string? FCustStreet { get; set; }

    public string? FCustCity { get; set; }

    public string? FCustState { get; set; }

    public string? FCustZip { get; set; }

    public string? FCustPhone { get; set; }

    public string? FCustEmail { get; set; }

    public virtual ICollection<TOrder> TOrders { get; } = new List<TOrder>();
}
