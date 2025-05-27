using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;
using Tutorial5.DTOs;
using Tutorial5.Models;

namespace Tutorial5.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly DatabaseContext _context;

    public PrescriptionService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddPrescriptionAsync(PrescriptionDTO prescription)
    {
        
        if (prescription.Medicament.Count > 10)
            throw new Exception("A prescription cannot have more than 10 medications");

        if (prescription.DueDate < prescription.Date)
            throw new Exception("DueDate cannot be greater than Date");

        var medicamentId = prescription.Medicament.Select(e => e.IdMedicament).ToList();
        var ifMedExist = await _context.Medicaments
            .Where(e => medicamentId.Contains(e.IdMedicament))
            .Select(e => e.IdMedicament)
            .ToListAsync();

        if (medicamentId.Except(ifMedExist).Any())
            throw new Exception("Some of passed medicaments do not exist!");

        var patient = await _context.Patients
            .FirstOrDefaultAsync(e => e.IdPatient == prescription.Patient.IdPatient);
        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = prescription.Patient.FirstName,
                LastName = prescription.Patient.LastName,
                BirthDate = prescription.Patient.Birthdate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }
        
        var doctorExists = await _context.Doctors.AnyAsync(d => d.IdDoctor == prescription.IdDoctor);
        if (!doctorExists)
            throw new Exception("The specified doctor does not exist.");

        var newPrescription = new Prescription
        {
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            IdDoctor = prescription.IdDoctor,
            IdPatient = prescription.Patient.IdPatient
        };
        _context.Prescriptions.Add(newPrescription);
        await _context.SaveChangesAsync();

        
        foreach (var m in prescription.Medicament)
        {
            var PresMed = new Prescription_Medicament
            {
                IdMedicament = m.IdMedicament,
                IdPrescription = newPrescription.IdPrescription,
                Dose = m.Dose,
                Details = m.Description
            };
            _context.PrescriptionMedicaments.Add(PresMed);
        }
        
        await _context.SaveChangesAsync();
    }
}