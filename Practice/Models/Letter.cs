using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class Letter
    {
        public int Id { get; set; }

        public string User { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
