using System.ComponentModel.DataAnnotations;

namespace MintPsyBlog.Models
{
    public class Blog
    {

        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

[Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
