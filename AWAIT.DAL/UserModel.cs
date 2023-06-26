using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWAIT.DAL
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }
        public int PhoneNumber { get; set; }
        public string? Password { get; set; }

        public ICollection<SuitModel>? Suits { get; set; }

    }
}
