using XYZ_Hotels_Assessment.Models;

namespace XYZ_Hotels_Assessment.Repository
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetRooms();
        void addRooms(Room rooms);
        Room GetRoomById(int id);
        void removeRoom(int id);
        void updateById(int id, Room room);
    }
}
