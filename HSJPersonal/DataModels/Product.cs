using System.ComponentModel.DataAnnotations;

namespace HSJPersonal.DataModels
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string? ProductImage { get; set; }

        public int ProductAmmount { get; set; }

        public bool IsActive { get; set; }
    }
}
