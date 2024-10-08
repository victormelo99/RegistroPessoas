﻿using Microsoft.AspNetCore.Mvc;
using RegistroPessoas.Data;
using RegistroPessoas.Models;
using RegistroPessoas.Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RegistroPessoas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PersonController : Controller
    {
        private readonly RegistroPessoasDbContext _context;
        private readonly PaymentService _service;

        public PersonController(RegistroPessoasDbContext context, PaymentService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            try
            {
                var result = _context.Person.ToList();
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("Error in listing people. " + e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPeople([FromBody] Person person)
        {
            try
            {
                var dailyPayment = _service.CalculateDailyPayment(person);

                await _context.AddAsync(person);
                var result = await _context.SaveChangesAsync();

                return Ok("Person included");
            }
            catch (Exception e)
            {
                return BadRequest("Error incluiding the person. " + e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutPeople([FromBody] Person person)
        {
            try
            {
                var dailyPayment = _service.CalculateDailyPayment(person);

                _context.Update(person);
                var result = await _context.SaveChangesAsync();

                return Ok("Person updated.");
            }
            catch (Exception e)
            {
                return BadRequest("Error updating the person. " + e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeople([FromRoute] Guid id)
        {
            Person person = await _context.Person.FindAsync(id);
            try
            {
                if (person != null)
                {
                    _context.Person.Remove(person);
                    var result = await _context.SaveChangesAsync();
                    
                    return Ok("Person deleted");
                }
                else
                {
                    return NotFound("Person not found ");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Error deleting the person: " + e.Message);
            }
        }
    }
}
