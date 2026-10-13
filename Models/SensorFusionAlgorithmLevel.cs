using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalanceTestingWebApi.Models;

[Table("SensorFusionAlgorithmLevel")]
public partial class SensorFusionAlgorithmLevel
{
    [Key]
    public int SensorFusionAlgorithmLevelId { get; set; }

    public string? SensorFusionAlgorithmLevelDescription { get; set; }
}
