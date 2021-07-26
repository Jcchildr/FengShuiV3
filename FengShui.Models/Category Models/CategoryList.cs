using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class CategoryList
    {
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        [Display(Name = "Category Title")]
        public string CategoryName { get; set; }
    }
}
