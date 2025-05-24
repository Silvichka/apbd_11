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
    private readonly DatabaseContext _context;

    public PrescriptionController(IPrescriptionService prescriptionService, DatabaseContext context)
    {
        _prescriptionService = prescriptionService;
        _context = context;
    }

    [HttpGet("get")]
    public async Task<IActionResult> get()
    {
        var res = await _context.Patients.ToListAsync();
        return Ok(res);
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