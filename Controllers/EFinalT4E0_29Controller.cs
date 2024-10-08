﻿using InstrumentoT4E0_29.Data;
using InstrumentoT4E0_29.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InstrumentoT4E0_29_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFInalT4E0Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public EFInalT4E0Controller(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostEncuesta([FromBody] EFinalBDT4E0_29 entrevistas)
        {
            if (entrevistas == null)
            {
                return BadRequest("Encuesta no puede ser nula.");
            }

            _context.EFinalBDT4E0_29.Add(entrevistas);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostEncuesta), new { id = entrevistas.id }, entrevistas);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EFinalBDT4E0_29>>> GetEntrevistas()
        {
            return await _context.EFinalBDT4E0_29.ToListAsync();
        }

        [HttpGet("exists")]
        public async Task<IActionResult> CheckNombreMadreExists([FromQuery] string nombreMadre)
        {
            var entrevistas = await _context.EFinalBDT4E0_29.FirstOrDefaultAsync(e => e.participante == nombreMadre);
            if (entrevistas != null)
            {
                return Ok(entrevistas.id);
            }
            return NotFound();
        }

    }
}
