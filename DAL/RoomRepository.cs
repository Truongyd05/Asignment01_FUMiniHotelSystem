using Models;

namespace DAL
{
    public class RoomRepository : Repository<RoomInformation>, IRoomRepository
    {
        public RoomRepository(InMemoryDatabase database) : base(database)
        {
        }

        public IEnumerable<RoomInformation> GetActiveRooms()
        {
            return _dbSet
                .Where(r => r.RoomStatus == 1)
                .ToList();
        }

        public IEnumerable<RoomInformation> GetRoomsByType(int roomTypeId)
        {
            return _dbSet
                .Where(r => r.RoomTypeID == roomTypeId && r.RoomStatus == 1)
                .ToList();
        }

        public async Task<IEnumerable<RoomInformation>> GetActiveRoomsAsync()
        {
            await Task.CompletedTask;
            return GetActiveRooms();
        }
    }
}
