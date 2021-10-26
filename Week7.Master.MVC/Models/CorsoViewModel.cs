using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MVC.Models
{
    public class CorsoViewModel
    {
        [Required]
        [DisplayName("Codice Corso")]
        public string CorsoCodice { get; set; }

        [Required]
        [DisplayName("Nome Corso")]
        public string Nome { get; set; }

        public string Descrizione { get; set; }
    }
}
