using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AWAIT.DAL
{
    public class SuitModel
    {
        [Key]
        public int SuitId { get; set; }
        public string? SuitName { get; set; }
        public string? SuitPlan { get; set; }

        public int UserId { get; set; }
        public UserModel? User { get; set; }
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

    }
}