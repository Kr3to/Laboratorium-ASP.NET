using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("reservation")]
    public class ReservationEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]

        [Column("reservation_date")]
        public DateTime? Date { get; set; }

        public string City { get; set; }
        [MaxLength(50)]
        [Required]

        public string Address { get; set; }
        [MaxLength(50)]
        [Required]

        public string Room { get; set; }
        [MaxLength(50)]
        [Required]
        public string Owner { get; set; }
        [MaxLength(50)]
        [Required]

        public string Price { get; set; }
    }
}