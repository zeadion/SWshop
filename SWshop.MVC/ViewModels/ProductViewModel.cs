using System.ComponentModel.DataAnnotations;

namespace SWshop.MVC.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Max length is 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", maximum: "999999999")]
        public decimal Price { get; set; }
    }
}