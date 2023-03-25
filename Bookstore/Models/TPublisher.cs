using System;
using System.Collections.Generic;

namespace Bookstore.Models;

public partial class TPublisher
{
    public long FPubId { get; set; }

    public string FPubName { get; set; } = null!;

    public virtual ICollection<TBook> TBooks { get; } = new List<TBook>();
}
