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

        public string? AdminAboutUs { get; set; }

        public string? AdminFacebook { get; set; }

        public string? AdminTwitter { get; set; }

        public string? AdminLinkedIn { get; set; }

        public string? AdminInstagram { get; set; }

    }
}
