using FengShui.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class ProductEdit
    {
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Price in US Dollars")]
        public decimal Price { get; set; }
        [Display(Name = "Brand")]
        public string Brandname { get; set; }
        [Display(Name = "Height in Inches")]
        public int Height { get; set; }
        [Display(Name = "Length in Inches")]
        public int Length { get; set; }
        [Display(Name = "Width in Inches")]
        public int Width { get; set; }
        [Display(Name = "# in Stock")]
        public int NumberInStock { get; set; }
        [Display(Name = "Description")]
        public string ProductDescription { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Home Location")]
        public HomeLocationEnum HomeLocation { get; set; }
        [Display(Name = "Primary Color")]
        public ColorEnum PrimaryColor { get; set; }
        [Display(Name = "Secondary Color")]
        public ColorEnum? SecondaryColor { get; set; }
    }
}
