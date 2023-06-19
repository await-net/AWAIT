using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWAIT.DAL
{
    public class TestSuitModel
    {
        [Key]
        public int Id { get; set; }
        public string? SuitName { get; set; }
        public string? SuitType { get; set; }
        public string? SuitDescription { get; set; }

        public int? TestId { get; set; }
        public ICollection<TestModel>? Tests { get; set; }

    }
    public class TestModel
    {
        [Key]
        public int Id { get; set; }
        public string? TestName { get; set; }
        public string? TestUrl { get; set; }

        public int? EventDataModelId { get; set; }
        public ICollection<EventDataModel>? Events { get; set; }

    }
}