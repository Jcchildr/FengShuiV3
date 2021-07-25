using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class ProductList
    {
        [Display(Name = "Product ID Number")]
        public int ProductId { get; set; }
        [Display(Name = "Title")]
        public string ProductName { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Brand")]
        public string Brandname { get; set; }
    }
}
