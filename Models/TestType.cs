using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalanceTestingWebApi.Models;

[Table("TestType")]
public partial class TestType
{
    [Key]
    public int TestTypeId { get; set; }

    public string? TestTypeDescription { get; set; }
}
