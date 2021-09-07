using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;
using Week7.Master.Core.InterfaceRepositories;

namespace Week7.Master.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        //Dichiaro quali sono i repository che ho a disposizione.
        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryDocenti docentiRepo;
        private readonly IRepositoryStudenti studentiRepo;
        private readonly IRepositoryLezioni lezioniRepo;

        public MainBusinessLayer(IRepositoryCorsi corsi, IRepositoryDocenti docenti, IRepositoryLezioni lezioni, IRepositoryStudenti studenti)
        {
            corsiRepo = corsi;
            docentiRepo = docenti;
            lezioniRepo = lezioni;
            studentiRepo = studenti;
        }

        

        #region Funzionalità Corsi
        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.GetAll();
        }

        public string InserisciNuovoCorso(Corso newCorso)
        {
            //controllo input
            //non deve esistere un altro corso con lo stesso codice
            Corso corsoEsistente=corsiRepo.GetByCode(newCorso.CorsoCodice);
            if (corsoEsistente != null)
            {
                return "Errore: Codice corso già presente";
            }
            corsiRepo.Add(newCorso);
            return "Corso aggiunto correttamente";
        }

        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione)
        {
            //controllo i dati
            Corso corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaModificare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice errato.";
            }
            corsoEsistente.Nome = nuovoNome;
            corsoEsistente.Descrizione = nuovaDescrizione;
            corsiRepo.Update(corsoEsistente);
            return "Il corso è stato modificato con successo";
        }

        public string EliminaCorso(string codiceCorsoDaEliminare)
        {
            Corso corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaEliminare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice errato.";
            }

            //TODO:non deve essere possibile cancellare un corso che ha almeno una lezione associata
            //nè un corso che ha almeno uno studente iscritto.

            corsiRepo.Delete(corsoEsistente);
            return "Corso eliminato correttamente";

        }

        #endregion

        #region funzionalità Studenti
        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.GetAll();
        }

        public string InserisciNuovoStudente(Studente nuovoStudente)
        {
            //controllo input
            Corso corsoEsistente = corsiRepo.GetByCode(nuovoStudente.CorsoCodice);
            if (corsoEsistente == null)
            {
                return "Codice corso errato";
            }
            studentiRepo.Add(nuovoStudente);
            return "studente inserito correttamente";
        }

        public string ModificaStudente(int idStudenteDaModificare, string nuovaEmail)
        {
            //controllo input
            //controllo se id esiste
            var studente = studentiRepo.GetById(idStudenteDaModificare);
            if (studente == null)
            {
                return "Id Studente errato o inesistente";
            }
            studentiRepo.Update(studente);
            return "Email Studente aggiornata correttamente";
        }
        public string EliminaStudente(int idStudenteDaEliminare)
        {
            //controllo input
            //controllo se id esiste
            var studente = studentiRepo.GetById(idStudenteDaEliminare);
            if (studente == null)
            {
                return "Id Studente errato o inesistente";
            }
            studentiRepo.Delete(studente);
            return "Studente eliminato correttamente";
        }

        public List<Studente> GetStudentiByCorsoCodice(string codiceCorso)
        {
            //controllo input
            //controllo se codice corso esiste. Se non esiste allora restituisco null
            //se il corso esiste, allora recupero dalla repo degli studenti la lista di quelli che hanno quel corsoCodice
            var corso = corsiRepo.GetByCode(codiceCorso);
            if (corso == null)
            {
                return null;
            }            
            return studentiRepo.GetAll().Where(s => s.CorsoCodice == corso.CorsoCodice).ToList();
        }
        #endregion
    }
}
