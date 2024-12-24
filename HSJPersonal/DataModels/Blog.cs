using System.ComponentModel.DataAnnotations;

namespace HSJPersonal.DataModels
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        public string? BlogTitle { get; set; }

        public string? BlogContent { get; set; }

        public string? BlogThumbnail { get; set; }
    }
}
