using System;
using System.Collections.Generic;

namespace nvslesson10.Models;

public partial class NvsCategory
{
    public int CateId { get; set; }

    public string? CateName { get; set; }

    public bool? CateStatus { get; set; }
}
