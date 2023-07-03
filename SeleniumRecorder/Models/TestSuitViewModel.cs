using System.Security.Cryptography.X509Certificates;

namespace SeleniumRecorder.Models
{
    public class SuitView
    {
        public string? SuitName { get; set; }
        public string? SuitPlan { get; set; }
    }
    public class RecorderView
    {
        public int RecorderId { get; set; }
        public string? RecorderWebDriver { get; set; }
        public string? RecorderName { get; set; }
        public string? RecorderDescription { get; set; }
        public string? RecorderStartUrl { get; set; }
        
        public int SuitId { get; set;}
        public string? SuitName { get; set; }
    }
    public class SuitRecorderView
    {
        public List<RecorderView>? Recorders { get; set; }
        public List<SuitView>? SuitView { get; set; }
        public RecorderView? TestCreateView { get; set; }
        public SuitView? SuitRegisterView { get; set; }
        public ConsoleViewModel? ConsoleView { get; set; }
    }
}