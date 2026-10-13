using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class BalanceTest
{
    public long BalanceTestId { get; set; }

    public string? BalanceTestDate { get; set; }

    public string? BalanceTestDescription { get; set; }

    public long? PatientId { get; set; }

    public double? BalanceScore { get; set; }
}
