using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Laboratorium_3_4.Models
{
    public class Reservation
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please add the name of the city")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please add the address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please add the room type")]
        [Display(Name = "Room")]
        public string Room { get; set; }

        [Display(Name = "Owner")]
        public string Owner { get; set; }

        [Display(Name = "Price")]
        public string Price { get; set; }

    }
}
