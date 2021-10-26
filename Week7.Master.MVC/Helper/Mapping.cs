using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Helper
{
    public static class Mapping
    {
        public static CorsoViewModel ToCorsoViewModel(this Corso corso)
        {
            List<StudenteViewModel> studentiViewModel = new List<StudenteViewModel>();
            foreach (var item in corso.Studenti)
            {
                studentiViewModel.Add(item?.ToStudenteViewModel());
            }

            return new CorsoViewModel
            {
                CorsoCodice = corso.CorsoCodice,
                Nome = corso.Nome,
                Descrizione = corso.Descrizione,
                Studenti= studentiViewModel
            };
        }

        public static Corso ToCorso(this CorsoViewModel corsoViewModel)
        {
            List<Studente> studenti = new List<Studente>();
            foreach (var item in corsoViewModel.Studenti)
            {
                studenti.Add(item?.ToStudente());
            }

            return new Corso
            {
                CorsoCodice = corsoViewModel.CorsoCodice,
                Nome = corsoViewModel.Nome,
                Descrizione = corsoViewModel.Descrizione,
                Studenti = studenti
                //Lezioni = null
            };
        }

        public static StudenteViewModel ToStudenteViewModel (this Studente studente)
        {
            return new StudenteViewModel
            {
                ID = studente.ID,
                Nome = studente.Nome,
                Cognome = studente.Cognome,
                Email = studente.Email,
                TitoloStudio = studente.TitoloStudio,
                DataNascita = studente.DataNascita,
                CorsoCodice = studente.CorsoCodice
            };
        }

        public static Studente ToStudente(this StudenteViewModel studenteViewModel)
        {
            return new Studente
            {
                ID = studenteViewModel.ID,
                Nome = studenteViewModel.Nome,
                Cognome = studenteViewModel.Cognome,
                Email = studenteViewModel.Email,
                TitoloStudio = studenteViewModel.TitoloStudio,
                DataNascita = studenteViewModel.DataNascita,
                CorsoCodice = studenteViewModel.CorsoCodice
            };
        }


    }
}
