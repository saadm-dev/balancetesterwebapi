using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalanceTestingWebApi.Models;

[Table("Patient")]
public partial class Patient
{
    [Key]
    public long PatientId { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Dob { get; set; }

    public string? Ssn { get; set; }

    public string? HomePhone { get; set; }

    public string? MobilePhone { get; set; }

    public string? WorkPhone { get; set; }

    public string? Email { get; set; }

    public string? Fax { get; set; }

    public string? EmergencyContact { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? EmergencyContactEmail { get; set; }

    public string? EmergencyContactRelationship { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? EmergencyContactAddress1 { get; set; }

    public string? EmergencyContactAddress2 { get; set; }

    public string? EmergencyContactCity { get; set; }

    public string? EmergencyContactState { get; set; }

    public string? EmergencyContactZip { get; set; }
}
