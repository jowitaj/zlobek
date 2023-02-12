using System;
using System.ComponentModel.DataAnnotations;

namespace zlobek.Entities
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Data kolacji jest wymagana")]
        public DateTime DinnerDate { get; set; }

        [Required(ErrorMessage = "Typ dania jest wymagany")]
        [StringLength(50, ErrorMessage = "Typ dania nie może być dłuższy niż 50 znaków")]
        public string DishType { get; set; }

        [StringLength(100, ErrorMessage = "Informacje o alergenach nie mogą być dłuższe niż 100 znaków")]
        public string Allergens { get; set; }
    }
}
