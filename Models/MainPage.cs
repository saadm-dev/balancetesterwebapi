using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class MainPage
{
    public long MainPageId { get; set; }

    public double? Weight { get; set; }

    public string? SensorSpeed { get; set; }

    public string? SensorFusionAlgorithmLevel { get; set; }

    public string? Filter { get; set; }

    public string? TestType { get; set; }
}
