using Data.Entities;

namespace Laboratorium3_App.Models
{
    public interface IReservationService
    {
        void Add(Reservation reservation);
        void Update(Reservation reservation);
        void DeleteById(int id);
        Reservation? FindById(int id);
        List<Reservation>? FindAll();
        /* List<OrganizationEntity> FindAllOrganizations();
        OrganizationEntity FindOrganizationById(int organizationId); */
    }
}
