using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Data
{
    public class Ambience
    {
        [Key]
        public int AmbienceId { get; set; }
        [Required]
        public Guid AdminId { get; set; }
        [Required]
        public string AmbienceName { get; set; }
        [Required]
        public string AmbienceDesription { get; set; }
        //Allows one to view all the Product of an Adjective (Many to many)
        public virtual ICollection<Product> ListOfProducts { get; set; }

        public Ambience()
        {
            ListOfProducts = new HashSet<Product>();
        }

    }
}
