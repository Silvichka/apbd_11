using System.ComponentModel.DataAnnotations;

namespace Tutorial5.DTOs;

public class MedicamentDTO
{
    [Required] public int IdMedicament { get; set; }
    public int Dose { get; set; }
    [Required, MaxLength(100)] public string Description { get; set; }
}