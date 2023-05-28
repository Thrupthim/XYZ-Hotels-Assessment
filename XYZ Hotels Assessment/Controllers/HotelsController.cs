using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XYZ_Hotels_Assessment.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XYZ_Hotels_Assessment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelDbContext _context;

        public HotelsController(HotelDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            return await _context.Hotels.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }
        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id, Hotel updatedHotel)
        {
            var existingHotel = _context.Hotels.Find(id);

            if (existingHotel == null)
            {
                return NotFound(); 
            }
            existingHotel.HotelName = updatedHotel.HotelName;
            existingHotel.City = updatedHotel.City;
            existingHotel.Country = updatedHotel.Country;
            existingHotel.Phone = updatedHotel.Phone;
            existingHotel.Email = updatedHotel.Email;
            _context.Entry(existingHotel).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(existingHotel); 
        }
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            if (_context.Hotels == null)
            {
                return Problem("Entity set 'HotelDbContext.Hotels'  is null.");
            }
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.HotelId }, hotel);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> deleteHotel(int id)
        {
            var h = await _context.Hotels.FindAsync(id);
            if (h == null)
            {
                return NotFound($"Record{id} not found");
            }
            _context.Hotels.Remove(h);
            await _context.SaveChangesAsync();
            return Ok("Data deleted");
        }
    }
}

