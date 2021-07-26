using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class AmbienceEdit
    {
        public int AmbienceId { get; set; }
        [Display(Name = "Ambience Name")]
        public string AmbienceName { get; set; }
        [Display(Name = "Ambience Description")]
        [MaxLength(200, ErrorMessage = "Too many characters in this field.")]
        public string AmbienceDesription { get; set; }
    }
}
