using Microsoft.EntityFrameworkCore;
using Tutorial5.Models;

namespace Tutorial5.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor() { IdDoctor = 1, FirstName = "Alice", LastName = "Bennett", Email = "alice.bennett@clinic.com" },
            new Doctor() { IdDoctor = 2, FirstName = "Liam", LastName = "Walker", Email = "liam.walker@health.org" },
        });
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient() { IdPatient = 1, FirstName = "Oliver", LastName = "Stone", BirthDate = new DateTime()},
            new Patient() { IdPatient = 2, FirstName = "Emma", LastName = "Brown", BirthDate = new DateTime()},
        });
        
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament() { IdMedicament = 1, Name = "Ibuprofen", Description = "Anti-inflammatory drug", Type = "Tablet",},
            new Medicament() { IdMedicament = 2, Name = "Cetirizine", Description = "Antihistamine", Type = "Syrup"},
        });
        
        modelBuilder.Entity<Prescription_Medicament>().HasData(new List<Prescription_Medicament>()
        {
            new Prescription_Medicament() { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "",},
        });
        
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new Prescription() { IdPrescription = 1, IdDoctor = 1, IdPatient = 1, Date = new DateTime(), DueDate = new DateTime()},
        });
    }
    
}