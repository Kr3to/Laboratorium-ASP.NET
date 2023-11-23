using System.Diagnostics;

namespace Laboratorium_3_4.Models
{
    public interface IReservationService
    {
        void Add(Reservation contact);
        void Update(Reservation contact);
        void DeleteById(int id);
        Reservation? FindById(int id);
        List<Reservation>? FindAll();
    }
}
