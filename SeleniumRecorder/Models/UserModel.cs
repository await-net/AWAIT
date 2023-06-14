using System.ComponentModel.DataAnnotations;

namespace SeleniumRecorder.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
