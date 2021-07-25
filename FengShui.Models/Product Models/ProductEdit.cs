using FengShui.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class ProductEdit
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Brandname { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int NumberInStock { get; set; }
        public string ProductDescription { get; set; }
        public int ColorId { get; set; }
        public int ProductCategoryId { get; set; }
        public HomeLocationEnum HomeLocation { get; set; }
        public ColorEnum PrimaryColor { get; set; }
        public ColorEnum ?SecondayColor { get; set; }
    }
}
