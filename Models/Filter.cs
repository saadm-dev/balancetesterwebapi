using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalanceTestingWebApi.Models;

[Table("Filter")]
public partial class Filter
{
    [Key]
    public int FilterId { get; set; }

    public string? FilterName { get; set; }
}
