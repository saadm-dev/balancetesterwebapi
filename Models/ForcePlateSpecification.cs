using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class ForcePlateSpecification
{
    public long ForcePlateId { get; set; }

    public double? Weight { get; set; }

    public double? SurfaceAreaHeight { get; set; }

    public double? SurfaceAreaDepth { get; set; }

    public double? Capacity { get; set; }
}
