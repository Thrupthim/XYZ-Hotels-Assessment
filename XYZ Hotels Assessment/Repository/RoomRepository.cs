using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XYZ_Hotels_Assessment.Models;

namespace XYZ_Hotels_Assessment.Repository
{
    public class RoomRepository:IRoomRepository
    {
        private readonly HotelDbContext _context;
        public RoomRepository(HotelDbContext context)
        {
            _context= context;
        }
        public IEnumerable<Room> GetRooms()
        {
            return _context.Rooms.ToList();
        }
        public Room GetRoomById(int id)
        {
            var roomobj=_context.Rooms.Find(id);
            return roomobj;
            
        }
        public void addRooms(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }
        public void removeRoom(int id)
        {
            var del = _context.Rooms.Find(id);
            _context.Rooms.Remove(del);
            _context.SaveChanges();
        }
        public void updateById(int id, Room rooms)
        {
            var res = _context.Rooms.Find(id);
            res.Floor = rooms.Floor;
            res.Availability = rooms.Availability;
            _context.Rooms.Update(res);
            _context.SaveChanges();
        }
        
    }
}
