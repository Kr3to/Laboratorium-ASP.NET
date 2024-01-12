using Data.Entities;
using Data;
using Laboratorium_3_4.Mappers;

namespace Laboratorium_3_4.Models
{
    public class EFReservationService : IReservationService
    {
        private readonly AppDbContext _context;
        public EFReservationService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Reservation reservation)
        {
            _context.Reservations.Add(ReservationMapper.ToEntity(reservation));
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = _context.Reservations.Find(id);
            if (entity != null)
            {
                _context.Reservations.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<Reservation>? FindAll()
        {
            return _context.Reservations.Select(e => ReservationMapper.FromEntity(e)).ToList();
        }

        public Reservation? FindById(int id)
        {
            var entity = _context.Reservations.Find(id);
            if (entity != null)
            {
                return ReservationMapper.FromEntity(entity);
            }
            else { return null; }

        }

        public void Update(Reservation reservation)
        {
            _context.Reservations.Update(ReservationMapper.ToEntity(reservation));
            _context.SaveChanges();
        }
    }
}
