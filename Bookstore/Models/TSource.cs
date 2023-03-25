using System;
using System.Collections.Generic;

namespace Bookstore.Models;

public partial class TSource
{
    public long FSourceId { get; set; }

    public string FSourceName { get; set; } = null!;

    public string? FSourceStreet { get; set; }

    public string? FSourceCity { get; set; }

    public string? FSourceState { get; set; }

    public string? FSourceZip { get; set; }

    public string? FSourcePhone { get; set; }

    public virtual ICollection<TBook> TBooks { get; } = new List<TBook>();
}
