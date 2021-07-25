using FengShui.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class ProductCreate
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Brandname { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int NumberInStock { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        [Required]
        public HomeLocationEnum HomeLocation { get; set; }
        [Required]
        public ColorEnum PrimaryColor { get; set; }
        [Required]
        public ColorEnum ?SecondaryColor { get; set; }
    }
}
