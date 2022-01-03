using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Check02.Models
{
    public class MdServicos
    {
        [Key]
        public int IdServico { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória")]
        [Display(Name = "Descrição")]
        public string DescricaoProduto { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Tipo { get; set; }
    }
}