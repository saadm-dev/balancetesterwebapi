using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalanceTestingWebApi.Models;

[Table("SensorSpeed")]
public partial class SensorSpeed
{
    [Key]
    public int SensorSpeedId { get; set; }

    public string? SensorSpeedDescription { get; set; }
}
