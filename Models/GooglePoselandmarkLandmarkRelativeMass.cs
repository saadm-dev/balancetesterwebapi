using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class GooglePoselandmarkLandmarkRelativeMass
{
    public int LandmarkId { get; set; }

    public string? LandmarkDescription { get; set; }

    public string? Investigator { get; set; }

    public double? LandmarkRelativeMassPercentage { get; set; }
}
