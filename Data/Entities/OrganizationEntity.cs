/* using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Organizations")]
    public class OrganizationEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Regon { get; set; }
        public string Nip { get; set; }
        public Address? Address { get; set; }
        public ISet<ReservationEntity> Reservations { get; set; }
    }
} */