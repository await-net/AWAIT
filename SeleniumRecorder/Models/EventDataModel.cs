namespace SeleniumRecorder.Models
{
    public class WebElementDataModel
    {
        public int Id { get; set; }
        public string? EventType { get; set; }
        public string? ElementId { get; set; }
        public string? ElementXPath { get; set; }
        public string? ElementTag { get; set; }
        public string? ElementClassName { get; set; }
        public string? ElementCSSPath { get; set; }
        public string? ElementWindowLocation { get; set; }
    }

}
