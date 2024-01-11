using System.Diagnostics;

namespace Laboratorium_3_4.Models
{
    public class MemoryReservationService : IReservationService
    {
        private readonly Dictionary<int, Reservation> _reservations = new Dictionary<int, Reservation>()
        {
            { 1, new Reservation() { Id = 1, Date=new DateTime(2015, 11, 21), City="New York", Address="Brooklyn 43 avenue", Room="Standard", Owner="Rooms inc", Price="1200"} },
            { 2, new Reservation() { Id = 2, Date=new DateTime(2016, 10, 31), City="San Francisco", Address="Twin peaks 12", Room="Deluxe", Owner="Rooms inc", Price="850"} },
        };

        private int _id = 3;
        public void Add(Reservation reservation)
        {
            reservation.Id = _id++;
            _reservations[reservation.Id] = reservation;
        }
        public List<Reservation>? FindAll()
        {
            return _reservations.Values.ToList();
        }
        public Reservation? FindById(int id)
        {
            return _reservations[id];
        }
        public void Update(Reservation reservation)
        {
            _reservations[reservation.Id] = reservation;
        }
        public void DeleteById(int id)
        {
            _reservations.Remove(id);
        }
    }
}
