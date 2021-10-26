using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week7.Master.MVC.Models
{
    public class StudenteViewModel: PersonaViewModel
    {
        [Required]
        public string TitoloStudio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascita { get; set; }

        //FK
        public string CorsoCodice { get; set; }
        public CorsoViewModel Corso { get; set; }
    }
}
