using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BalanceTestingWebApi.Models;

public partial class ForcePlateManufacturerXref
{
    public long ForcePlateId { get; set; }

    public int ForcePlateManufacturerId { get; set; }
}
