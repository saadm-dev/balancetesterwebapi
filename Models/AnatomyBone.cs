using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class AnatomyBone
{
    public long BoneId { get; set; }

    public string? BoneName { get; set; }

    public string? BoneDescription { get; set; }
}
