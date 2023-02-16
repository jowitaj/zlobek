using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zlobek.Entities
{
    public class Child
    {
        [Key]
        public int ChildID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MotherName { get; set; }
        public string MotherSurname { get; set; }
        public string FatherName { get; set; }
        public string FatherSurname { get; set; }
        public int ContactNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string BirthDate { get; set; }
        public string Allergies { get; set; }
        public string OtherInformations { get; set; }
       
        public int? GroupId { get; set; }
        public virtual Groups Groups { get; set; }
    }
}
