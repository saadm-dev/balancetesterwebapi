using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalanceTestingWebApi.Models;

[Table("ForcePlateManufacturer")]
public partial class ForcePlateManufacturer
{
    public int ForcePlateManufacturerId { get; set; }

    public string? ForcePlateManufacturerName { get; set; }
}
