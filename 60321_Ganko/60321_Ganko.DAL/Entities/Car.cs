using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _60321_Ganko.DAL.Entities
{
    public class Car
    {
        [HiddenInput]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Введите модель")]        
        [Display(Name = "Модель авто")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Введите марку")]
        [Display(Name = "Марка авто")]
        public string Manufacturer { get; set; }

        [Required]
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Класс авто")]
        public string ClassType { get; set; }

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; }

        [ScaffoldColumn(false)]
        public string MimeType { get; set; }
    }
}
