using System.ComponentModel.DataAnnotations;

namespace HSJPersonal.DataModels
{
    public class Social
    {
        [Key]
        public int SocialId { get; set; }

        public string? SocialName { get; set; }

        public string? SocialIcon { get; set; }

        public string? SocialLink { get; set; }
    }
}