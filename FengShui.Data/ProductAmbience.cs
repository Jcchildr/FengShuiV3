using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Data
{
    public class ProductAmbience
    {

        //Link to the Product Data Table
        [Key, Column(Order = 0), ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //Link to the Ambience Data Table
        [Key, Column(Order = 1), ForeignKey(nameof(Ambience))]
        public int AmbienceId { get; set; }
        public Ambience Ambience { get; set; }


    }
}
