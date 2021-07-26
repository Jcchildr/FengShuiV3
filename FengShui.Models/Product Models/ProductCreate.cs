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
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Price in US Dollars")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public string Brandname { get; set; }
        [Required]
        [Display(Name = "Height in Inches")]
        public int Height { get; set; }
        [Required]
        [Display(Name = "Length in Inches")]
        public int Length { get; set; }
        [Required]
        [Display(Name = "Width in Inches")]
        public int Width { get; set; }
        [Required]
        [Display(Name = "# in Stock")]
        public int NumberInStock { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string ProductDescription { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Home Location")]
        public HomeLocationEnum HomeLocation { get; set; }
        [Required]
        [Display(Name = "Primary Color")]
        public ColorEnum PrimaryColor { get; set; }
        [Display(Name = "Secondary Color")]
        public ColorEnum ?SecondaryColor { get; set; }
    }
}
