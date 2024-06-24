



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.NewFolder
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; }
    }
}
