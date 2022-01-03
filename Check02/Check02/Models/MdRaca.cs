using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Check02.Models
{
    public class MdRaca
    {
        [Key]
        public int IdRaca { get; set; }

        // ########## NOME DA RAÇA ##########
        [Display(Name ="Raça")]
        public String NmRaca { get; set; }
    }
}