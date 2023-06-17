using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeleniumRecorder.Models
{
    public class WebElementEventResult
    {
        [Key]
        public int Id { get; set; }
        public string? EventType { get; set; }
        public object? Target { get; set; }
        public string? Value { get; set; }
    }    
    public class WebElementTarget
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CSS { get; set; }
        public string XPath { get; set;}
        public List<Dictionary<string, object>> Targets { get; set;
        }
    }


}
