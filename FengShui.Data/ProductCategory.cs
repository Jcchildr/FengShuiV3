using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Data
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        [Required]
        public Guid AdminId { get; set; }
        [Required]
        public string ProductCategoryName { get; set; }
        [Required]
        public string ProductCategoryDesc { get; set; }
    }
}
