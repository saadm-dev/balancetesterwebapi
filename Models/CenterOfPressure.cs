using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class CenterOfPressure
{
    public long CenterOfPressureId { get; set; }

    public double? Pressure { get; set; }

    public double? Area { get; set; }

    public double? TotalForce { get; set; }

    public string? TotalMoment { get; set; }

    public double? CenterOfPressureValue { get; set; }

    public int? CopmethodId { get; set; }
}
