using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class AmbienceCreate
    {
        [Required]
        [Display(Name = "Ambience Name")]
        public string AmbienceName { get; set; }
        [Required]
        [Display(Name = "Ambience Description")]
        [MaxLength(200, ErrorMessage = "Too many characters in this field.")]
        public string AmbienceDesription { get; set; }
    }
}
