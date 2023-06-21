using System.ComponentModel.DataAnnotations;

namespace AWAIT.DAL
{
    public class SuitModel
    {
        [Key]
        public int SuitId { get; set; }
        public string? SuitName { get; set; }
        public string? SuitPlan { get; set; }
    }
    public class TestModel
    {
        [Key]
        public int TestId { get; set; }
        public string? TestWebDriver { get; set; }
        public string? TestName { get; set; }
        public string? TestType { get; set; }
        public string? TestUrl { get; set; }

        public int SuitId { get; set; }
        public SuitModel? Suit { get; set; }

    }
}