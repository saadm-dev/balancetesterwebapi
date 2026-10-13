using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class SegmentCenterOfGravity
{
    public int PositionCenterOfGravityId { get; set; }

    public int? SegmentId { get; set; }

    public string? SegmentName { get; set; }

    public double? CenterOfGravity { get; set; }
}
