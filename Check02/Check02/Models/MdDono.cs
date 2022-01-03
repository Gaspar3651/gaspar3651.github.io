using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Check02.Models
{
    public class MdDono
    {
        [Key]
        public int IdDono { get; set; }

        // ########## NOME ##########
        [Display(Name ="Nome do Dono")]
        [Required(ErrorMessage ="O {0} é obrigatório")]
        public String NmDono { get; set; }


        // ########## TELEFONE ##########
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Telefone { get; set; }


        // ########## DATA DE NASCIMENTO ##########
        [Display(Name ="Data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A {0} é obrigatório")]
        public string Nascimento { get; set; }


        // ########## CPF ##########
        [Display(Name ="CPF")]
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Cpf { get; set; }


        public List<MdServicos> Oferta { get; set; }
    }

}