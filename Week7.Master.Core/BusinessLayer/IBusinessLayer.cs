using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Master.Core.Entities;

namespace Week7.Master.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        //Aggiungere "l'elenco" delle funzionalità richieste dalla traccia

        #region Funzionalità Corsi
        //Visualizza corsi
        public List<Corso> GetAllCorsi();

        //Inserire un nuovo corso
        public string InserisciNuovoCorso(Corso newCorso);

        //Modifica Corso
        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione);
        //Elimina corso
        public string EliminaCorso(string codiceCorsoDaEliminare);

        #endregion

        #region Funzionalità Studenti
        //Visualizza tutti gli studenti
        public List<Studente> GetAllStudenti();

        public string InserisciNuovoStudente(Studente nuovoStudente);
        public string ModificaStudente(int idStudenteDaModificare, string nuovaEmail);
        public string EliminaStudente(int idStudenteDaEliminare);
        public List<Studente> GetStudentiByCorsoCodice(string codiceCorso);

        #endregion

        #region Funzionalità Docenti
        //Visualizza docenti
        public IList<Docente> GetAllDocenti();

        //Inserisci nuovo docente
        public string InserisciNuovoDocente(Docente nuovoDocente);

        //Modifica docente (solo email e telefono)
        public string ModificaDocente(int id, string nuovoTelefono, string nuovaMail);

        //Elimina docente per id
        public string EliminaDocente(int idDocenteDaEliminare);
        #endregion

        #region Funzionalità Lezioni
        //Visualizza ElencoCompleto delle lezioni
        public IList<Lezione> GetAllLezioni();

        //aggiungi lezione
        public string AggiungiLezione(Lezione lezione);

        //modifica lezione
        public string ModificaLezione(int id, string nuovaAula);

        //Elimina Lezione
        string EliminaLezione(int idLezioneDaEliminare);

        //visualizza tutte lezioni di un corso recuperando il corso in base al codiceCorso
        public IList<Lezione> GetLezioniByCodiceCorso(string codiceCorso);

        //visualizza tutte lezioni di un corso recuperando il corso in base al nome
        public IList<Lezione> GetLezioniByNomeCorso(string nomeCorso);
        #endregion

        public Utente GetAccount(string username);

    }
}
