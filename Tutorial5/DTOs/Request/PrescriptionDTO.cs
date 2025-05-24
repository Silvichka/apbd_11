using System.ComponentModel.DataAnnotations;

namespace Tutorial5.DTOs;

public class PrescriptionDTO
{
    [Required] public PatientDTO Patient { get; set; }
    public List<MedicamentDTO> Medicament { get; set; } = new();
    [Required] public DateTime Date { get; set; }
    [Required] public DateTime DueDate { get; set; }
    [Required] public int IdDoctor { get; set; }
}