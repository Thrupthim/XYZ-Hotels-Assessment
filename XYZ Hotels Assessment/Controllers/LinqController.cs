using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Linq;
using XYZ_Hotels_Assessment.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XYZ_Hotels_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        private readonly HotelDbContext _linqContext;
        public LinqController(HotelDbContext context)
        {
            _linqContext = context;
        }
        [HttpGet]
        [Route("Hotel")]
        public ActionResult getHotelsByCity(string city)
        {
            try
            {
                var hotels = _linqContext.Hotels.AsQueryable();
                if (!string.IsNullOrEmpty(city))
                {
                    hotels = hotels.Where(h => h.City == city);
                }
                return Ok(hotels);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }
        [HttpGet]
        [Route("Room")]
        public ActionResult getRoomsByPrice(int minprice,int maxprice)
        {
            try
            {
                var rooms = from temp in _linqContext.Rooms
                            join hotels in _linqContext.Hotels on temp.HotelId equals hotels.HotelId
                            where temp.price >= minprice && temp.price <= maxprice
                            select new
                            {
                                RoomId = temp.RoomId,
                                price = temp.price,
                                HotelName = hotels.HotelName,
                                City = hotels.City,
                                Country = hotels.Country
                            };
                var res = rooms.ToList();
                return Ok(rooms);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Available")]
        public string getCount()
        {
            var count = (from c in _linqContext.Rooms.Where(n => n.Availability == "Available")
                        select c).Count();
            return ("Number of rooms available:" + count);
        }

    }
}
