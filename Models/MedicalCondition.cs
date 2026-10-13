using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class MedicalCondition
{
    public int MedicalConditionId { get; set; }

    public string? MedicalConditionDescription { get; set; }
}
