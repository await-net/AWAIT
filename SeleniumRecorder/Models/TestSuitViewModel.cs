using System.Security.Cryptography.X509Certificates;

namespace SeleniumRecorder.Models
{
    public class SuitView
    {
        public string? SuitName { get; set; }
        public string? SuitPlan { get; set; }
    }
    public class TestView
    {
        public string? TestWebDriver { get; set; }
        public string? TestName { get; set; }
        public string? TestType { get; set; }
        public string? TestDescription { get; set; }
        public string? TestUrl { get; set; }
        public string? SuitName { get; set;}
    }
    public class SuitTestView
    {
        public List<TestView>? TestView { get; set; }
        public List<SuitView>? SuitView { get; set; }
        public TestView? TestCreateView { get; set; }
        public SuitView? SuitRegisterView { get; set; }
        public ConsoleViewModel? ConsoleView { get; set; }
    }
}