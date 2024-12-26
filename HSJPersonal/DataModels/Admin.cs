using System.ComponentModel.DataAnnotations;

namespace HSJPersonal.DataModels
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public string? AdminName { get; set; }

        public string? AdminPhone { get; set; }

        public string? AdminEmail { get; set; }

        public string? AdminLocation { get; set; }

    }
}
