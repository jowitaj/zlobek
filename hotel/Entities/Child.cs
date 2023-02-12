using Microsoft.AspNetCore.Authorization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace zlobek.Entities
{
    public class Child
    {
        [Key]
        public int ChildID { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name can not be longer than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50, ErrorMessage = "Surname can not be longer than 50 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Mother's name is required.")]
        [StringLength(50, ErrorMessage = "Mother's name can not be longer than 50 characters.")]
        public string MotherName { get; set; }

        [Required(ErrorMessage = "Mother's surname is required.")]
        [StringLength(50, ErrorMessage = "Mother's surname can not be longer than 50 characters.")]
        public string MotherSurname { get; set; }

        [Required(ErrorMessage = "Father's name is required.")]
        [StringLength(50, ErrorMessage = "Father's name can not be longer than 50 characters.")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Father's surname is required.")]
        [StringLength(50, ErrorMessage = "Father's surname can not be longer than 50 characters.")]
        public string FatherSurname { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Contact number should have 9 digits.")]
        public int ContactNumber { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City can not be longer than 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [StringLength(50, ErrorMessage = "Street can not be longer than 50 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "House number is required.")]
        [StringLength(10, ErrorMessage = "House number can not be longer than 10 characters.")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Postal code should have format XX-XXX.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CustomValidation(typeof(Child), "BirthDateValidation")]
        public string BirthDate { get; set; }

        public string Allergies { get; set; }
        public string OtherInformations { get; set; }

        public int? GroupId { get; set; }
        public virtual Groups Groups { get; set; }

        public static ValidationResult BirthDateValidation(string birthDate, ValidationContext context)
        {
            if (string.IsNullOrEmpty(birthDate))
            {
                return new ValidationResult("Birth date is required.");
            }

            if (!DateTime.TryParse(birthDate, out DateTime date))
            {
                return new ValidationResult("Invalid birth date.");
            }

            if (date > DateTime.Now)
            {
                return new ValidationResult("Birth date can not be in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
