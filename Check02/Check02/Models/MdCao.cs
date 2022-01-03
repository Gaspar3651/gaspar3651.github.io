using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Check02.Models
{
    public class MdCao
    {
        [Key]
        public int IdCao { get; set; }

        // ########## NOME DO CAO ##########
        [Display(Name = "Nome do cão")]
        [Required]
        public string NmCao { get; set; }

        // ########## ID RAÇA ##########
        [Display(Name = "Raça")]
        public int IdRaca { get; set; }

        // ########## NOME DA RAÇA ##########
        [Display(Name = "Raça do Cão")]
        public string NmRaca { get; set; }


        public string NmRacasfa { get; set; }
    }
}