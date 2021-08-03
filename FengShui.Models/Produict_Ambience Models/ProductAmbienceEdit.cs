using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class ProductAmbienceEdit
    {
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [Display(Name = "Ambience")]
        public int AmbienceId { get; set; }
    }
}
