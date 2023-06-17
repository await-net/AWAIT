using System.ComponentModel.DataAnnotations;

namespace AWAIT.DAL
{
    public class EventDataModel
    {
        [Key]
        public int Id { get; set; }
        public string? EventType { get; set; }
        public ICollection<TargetModel>? Targets { get; set; }
    }
    public class TargetModel
    {
        [Key]
        public int Id { get; set; }
        public ICollection<ElementProperty> ElementProperties { get; set; }
    }

    public class ElementProperty
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public int TargetModelId { get; set; }
        public TargetModel TargetModel { get; set; }
    }
}