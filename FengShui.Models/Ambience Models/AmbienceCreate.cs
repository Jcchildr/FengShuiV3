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
        public string AmbienceName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Too many characters in this field.")]
        public string AmbienceDesription { get; set; }
    }
}
