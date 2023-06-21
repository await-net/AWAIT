namespace SeleniumRecorder.Models
{
    public class SuitViewModel
    {
        public string? SuitName { get; set; }
        public string? SuitPlan { get; set; }
    }
    public class TestViewModel
    {
        public string? TestWebDriver { get; set; }
        public string? TestName { get; set; }
        public string? TestType { get; set; }
        public string? TestDescription { get; set; }
        public string? TestUrl { get; set; }
    }

    public class TestSuitViewModel
    {
        public SuitViewModel? Suit { get; set; }
        public TestViewModel? Test { get; set; }
    }
}