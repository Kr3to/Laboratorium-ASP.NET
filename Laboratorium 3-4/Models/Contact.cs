using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Laboratorium_3_4.Models
{
    public enum Priority
    {
        [Display(Name = "Low")] Low = 1,
        [Display(Name = "Normal")] Normal = 2,
        [Display(Name = "High")] High = 3,
        [Display(Name = "Urgent")] Urgent = 4
    }
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must provide your Name!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Name is too long, you have exceeded the maximum of 50 characters!")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Phone]
        public string Phone { get; set; }
        [Display(Name = "Email address")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Birth { get; set; }
        [Display(Name = "Priority")]
        public Priority Priority { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }
    }
}
