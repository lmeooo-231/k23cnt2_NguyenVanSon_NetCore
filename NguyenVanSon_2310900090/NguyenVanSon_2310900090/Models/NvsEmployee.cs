using System;
using System.Collections.Generic;

namespace NguyenVanSon_2310900090.Models;

public partial class NvsEmployee
{
    public int NvsEmpId { get; set; }

    public string NvsEmpName { get; set; } = null!;

    public string NvsEmpLevel { get; set; } = null!;

    public DateOnly NvsEmpStartDate { get; set; }

    public bool NvsEmpStatus { get; set; }
}
