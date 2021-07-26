﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public Guid AdminId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDesc { get; set; }
    }
}