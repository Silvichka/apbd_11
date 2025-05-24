using Tutorial5.DTOs;
using Tutorial5.Models;

namespace Tutorial5.Services;

public interface IPrescriptionService
{
    Task AddPrescriptionAsync(PrescriptionDTO prescription);
}