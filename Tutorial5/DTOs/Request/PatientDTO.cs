using System.ComponentModel.DataAnnotations;

namespace Tutorial5.DTOs;

public class PatientDTO
{
    [Required] public int IdPatient { get; set; }
    [Required, MaxLength(100)] public string FirstName { get; set; }
    [Required, MaxLength(100)] public string LastName { get; set; }
    [Required] public DateTime Birthdate { get; set; }
}