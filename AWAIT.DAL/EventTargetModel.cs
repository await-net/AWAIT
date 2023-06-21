using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWAIT.DAL
{
    public class EventModel
    {
        [Key]
        public int EventId { get; set; }
        public string? EventType { get; set; }
        public TargetModel? TargetEvent { get; set; }

        public int TestId { get; set; }
        public TestModel? Test { get; set; }
    }
    public class TargetModel
    {
        [Key]
        public int TargetId { get; set; }
        public string? ById { get; set; }
        public string? ByName { get; set; }
        public string? ByCss { get; set; }
        public string? ByXPath { get; set; }
        public TargetTypeModel[]? Targets { get; set; }
    }

    public class TargetTypeModel
    {
        [Key]
        public int TargetTypeId { get; set; }
        public string? Value { get; set; }
        public string? Type { get; set; }
    }

    public class EventPropertyTargetModel
    {
        [Key]
        public int Id { get; set; }
        public EventModel? EventTarget { get; set; }
        public TargetModel? TargetModel { get; set; }
    }
}