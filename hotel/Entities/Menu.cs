using System;
using System.ComponentModel.DataAnnotations;

namespace zlobek.Entities
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public DateTime DinnerDate { get; set; }
        public string DishType { get; set; }
        public string Allergens { get; set; }
    }
}
