using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zlobek.Entities
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ContactNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string BirthDate { get; set; } 
        public string OtherInformations { get; set; }

        public int GroupId { get; set; }
        public virtual Groups Groups { get; set; }
    }
}
