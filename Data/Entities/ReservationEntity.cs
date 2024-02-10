using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("reservations")]
    public class ReservationEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]

        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        [Required]

        public string City { get; set; }
        [MaxLength(50)]
        [Required]

        public string Address { get; set; }
        
        [Required]
        public string Room { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Owner { get; set; }

        
        [MaxLength(50)]
        [Required]
        public string Price { get; set; }

        /* public int OrganizationId{ get; set; }
        public OrganizationEntity? Organization { get; set; } */
    }
}
