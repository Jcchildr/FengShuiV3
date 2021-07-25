using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Models
{
    public class AmbienceList
    {
        [Display(Name = "Ambience ID")]
        public int AmbienceId { get; set; }
        [Display(Name = "Ambience Title")]
        public string AmbienceName { get; set; }
    }
}
