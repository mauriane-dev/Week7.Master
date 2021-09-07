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

    }
}
