using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Check02.Models
{
    public class MdCao_Dono
    {
        [Key]
        public int IdCao_Dono { get; set; }

        // ########## ID DONO ##########
        [Display(Name ="ID do dono")]
        public int IdDono { get; set; }

        // ########## ID CAO ##########
        [Display(Name ="ID do Cão")]
        public int IdCao { get; set; }

        // ########## ID RAÇA ##########
        public int IdRaca { get; set; }



        // ########## NOME DO CAO ##########
        [Display(Name = "Nome do Cão")]
        public String NmCao { get; set; }

        // ########## NOME DO DONO ##########
        [Display(Name ="Nome do Dono")]
        public String NmDono { get; set; }

        // ########## NOME DA RAÇA ##########
        [Display(Name = "Raça")]
        public String NmRaca { get; set; }
    }
}