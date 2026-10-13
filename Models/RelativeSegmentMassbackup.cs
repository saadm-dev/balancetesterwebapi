using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class RelativeSegmentMassbackup
{
    public int SegmentId { get; set; }

    public string? SegmentName { get; set; }

    public string? Investigator { get; set; }

    public double? RelativeSegmentMassValue { get; set; }
}
