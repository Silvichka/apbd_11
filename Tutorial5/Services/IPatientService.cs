using Tutorial5.DTOs.Response;
using Tutorial5.Models;

namespace Tutorial5.Services;

public interface IPatientService
{
    Task<PatientResponseDTO?> GetPatientDetailsAsync(int idPatient);
}