using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class CategoryCreate
    {
        [Required]
        [Display (Name = "Category Name")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name = "Category Description")]
        public string CategoryDesc { get; set; }
    }
}
