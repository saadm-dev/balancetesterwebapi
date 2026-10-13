using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class Procedure
{
    public long ProcedureId { get; set; }

    public string? ProcedureDescription { get; set; }
}
