using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class ProductAmbienceList
    {
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Ambience ID")]
        public int AmbienceId { get; set; }
        [Display(Name = "Ambience Name")]
        public string AmbienceName { get; set; }
    }
}
