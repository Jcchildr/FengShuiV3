using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class ProductCategoryCreate
    {
        [Required]
        public string ProductCategoryName { get; set; }
        [Required]
        public string ProductCategoryDesc { get; set; }
    }
}
