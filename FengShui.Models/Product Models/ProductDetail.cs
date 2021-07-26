using FengShui.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class ProductDetail
    {
        [Display(Name = "ID")]
        public int ProductId { get; set; }
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        [Display(Name = "Price in US Dollars")]
        public decimal Price { get; set; }
        [Display(Name = "Brand")]
        public string Brandname { get; set; }
        [Display(Name = "Dimension in Inches")]
        public string Dimension { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        [Display(Name = "# of Product in Stock")]
        public int NumberInStock { get; set; }
        [Display(Name = "Discription")]
        public string ProductDescription { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Home Location")]
        public HomeLocationEnum HomeLocation { get; set; }
        [Display(Name = "Primary Color")]
        public ColorEnum PrimaryColor { get; set; }
        [Display(Name = "Secondary Color")]
        public ColorEnum ?SecondaryColor { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
