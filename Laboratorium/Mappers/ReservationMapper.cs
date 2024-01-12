using Data.Entities;
using Laboratorium_3_4.Models;

namespace Laboratorium_3_4.Mappers
{
    public class ReservationMapper
    {
        public static Reservation FromEntity(ReservationEntity entity)
        {
            return new Reservation()
            {
                Id = entity.Id,
                Date = (DateTime)entity.Date,
                City = entity.City,
                Address = entity.Address,
                Room = entity.Room,
                Owner = entity.Owner,
                Price = entity.Price
            };
        }

        public static ReservationEntity ToEntity(Reservation model)
        {
            return new ReservationEntity()
            {
                Id = model.Id,
                Date = model.Date,
                City = model.City,
                Address = model.Address,
                Room = model.Room,
                Owner = model.Owner,
                Price = model.Price
            };
        }
    }
}
