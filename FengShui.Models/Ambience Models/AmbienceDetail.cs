using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class AmbienceDetail
    {
        [Display(Name = "Ambience ID")]
        public int AmbienceId { get; set; }
        [Display(Name = "Title")]
        public string AmbienceName { get; set; }
        [Display(Name = "Description")]
        public string AmbienceDesription { get; set; }
    }
}
