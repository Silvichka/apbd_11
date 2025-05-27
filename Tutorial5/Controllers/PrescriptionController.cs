using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutorial5.Data;
using Tutorial5.DTOs;
using Tutorial5.Models;
using Tutorial5.Services;

namespace Tutorial5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService, DatabaseContext context)
    {
        _prescriptionService = prescriptionService;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDTO prescription)
    {
        try
        {
            await _prescriptionService.AddPrescriptionAsync(prescription);
            return Ok(new { message = "Prescription created successfully." });
        }
        catch (Exception e)
        {
            return BadRequest(new { error = e.Message });
        }
    }
}