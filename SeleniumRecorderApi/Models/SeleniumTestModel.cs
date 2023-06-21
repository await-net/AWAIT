﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SeleniumRecorderApi.Models
{
    public class SeleniumTestModel
    {

        public SeleniumTestModel() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? TestJson { get; set; }
        
    }
}
