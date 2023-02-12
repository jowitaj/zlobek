using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zlobek.Entities
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Surname must be between 2 and 50 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Contact number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public int ContactNumber { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City must be between 2 and 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Street must be between 2 and 50 characters")]
        public string Street { get; set; }

        [Required(ErrorMessage = "House number is required")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "House number must be between 1 and 10 characters")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Postal code must be between 5 and 10 characters")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Birth date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string BirthDate { get; set; }

        public string OtherInformations { get; set; }

        public int? GroupId { get; set; }
        public virtual Groups Groups { get; set; }
    }
}
