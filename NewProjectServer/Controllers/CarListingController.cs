﻿using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewDatabaseModel;






namespace NewProjectServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarListingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarListingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CarListings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarListing>>> GetCarListings()
        {
            return await _context.CarListings.ToListAsync();
        }

        // GET: api/CarListings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarListing>> GetCarListing(int id)
        {
            var carListing = await _context.CarListings.FindAsync(id);

            if (carListing == null)
            {
                return NotFound();
            }

            return carListing;
        }

        // POST: api/CarListings
        [HttpPost]
        public async Task<ActionResult<CarListing>> PostCarListing(CarListing carListing)
        {
            _context.CarListings.Add(carListing);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarListing), new { id = carListing.Id }, carListing);
        }

        // PUT: api/CarListings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarListing(int id, CarListing carListing)
        {
            if (id != carListing.Id)
            {
                return BadRequest();
            }

            _context.Entry(carListing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CarListings.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/CarListings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarListing(int id)
        {
            var carListing = await _context.CarListings.FindAsync(id);
            if (carListing == null)
            {
                return NotFound();
            }

            _context.CarListings.Remove(carListing);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}