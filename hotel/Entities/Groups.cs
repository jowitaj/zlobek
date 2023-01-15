using System.ComponentModel.DataAnnotations;

namespace zlobek.Entities
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int NOMembers { get; set; }
        public int ChildId { get; set; }
        public virtual Child Child { get; set; }

        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
