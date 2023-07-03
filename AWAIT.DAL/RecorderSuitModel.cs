using System.ComponentModel.DataAnnotations;

namespace AWAIT.DAL
{
    public class SuitModel
    {
        [Key]
        public int Id { get; set; }
        public string? SuitName { get; set; }
        public string? SuitPlan { get; set; }

        public int UserId { get; set; }
        public UserModel? User { get; set; }
    }
    public class RecorderModel
    {
        [Key]
        public int Id { get; set; }
        public string? RecorderWebDriver { get; set; }
        public string? RecorderName { get; set; }
        public string? RecorderDescription { get; set; }

        public int SuitId { get; set; }

    }
}