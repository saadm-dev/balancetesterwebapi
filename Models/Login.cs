using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BalanceTestingWebApi.Models;

public partial class Login
{
    [Key]
    public long UserId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public long? PatientId { get; set; }
}
