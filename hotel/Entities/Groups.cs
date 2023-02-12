using System.ComponentModel.DataAnnotations;

namespace zlobek.Entities
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int NOMembers { get; set; }

    }
}
