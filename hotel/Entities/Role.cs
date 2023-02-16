using System;

namespace zlobek.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator Role(string v)
        {
            throw new NotImplementedException();
        }
    }
}
