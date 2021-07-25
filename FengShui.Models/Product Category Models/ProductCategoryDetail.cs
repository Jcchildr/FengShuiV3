using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class ProductCategoryDetail
    {
        [Display(Name = "Category ID")]
        public int ProductCategoryId { get; set; }
        [Display(Name = "Category Title")]
        public string ProductCategoryName { get; set; }
        [Display(Name = "Category Description")]
        public string ProductCategoryDesc { get; set; }
    }
}
